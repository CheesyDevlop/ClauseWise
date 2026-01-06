using ClauseWise.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClauseWise.Services
{
    // Class to deserialize HuggingFace response
    public class HuggingFaceResponse
    {
        [JsonProperty("generated_text")]
        public string GeneratedText { get; set; }
    }

    /// <summary>
    /// Dedicated service for handling AI contract analysis via the HuggingFace Inference API.
    /// This ensures clean separation of concerns.
    /// </summary>
    public class AiContractAnalyzerService
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public AiContractAnalyzerService()
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(AppConfig.ApiTimeoutSeconds);
        }

        /// <summary>
        /// Analyzes the contract text by calling the configured HuggingFace model.
        /// </summary>
        /// <param name="contractText">The full text of the contract to analyze.</param>
        /// <returns>The raw, structured analysis string from the AI.</returns>
        /// <exception cref="MissingApiKeyException">Thrown if the API key is not configured.</exception>
        /// <exception cref="HttpRequestException">Thrown for network or API errors.</exception>
        public async Task<string> AnalyzeContractAsync(string contractText)
        {
            if (string.IsNullOrEmpty(AppConfig.HuggingFaceApiKey))
            {
                throw new MissingApiKeyException();
            }

            string limitedText = contractText.Length > AppConfig.MaxContractTextLimit
                ? contractText.Substring(0, AppConfig.MaxContractTextLimit) + "..."
                : contractText;

            string prompt = CreateAnalysisPrompt(limitedText);
            string aiResponse = await CallHuggingFaceAPI(prompt);

            return FormatAIResponse(aiResponse, prompt);
        }

        private string CreateAnalysisPrompt(string contractText)
        {
            // Professional prompt engineering for better results from a capable model
            return $@"You are a highly specialized and expert contract law AI. Your task is to perform a detailed risk assessment and clause check on the provided contract.

Output your comprehensive findings STRICTLY in the exact, case-sensitive format provided below. Do not include any introductory text, concluding remarks, or surrounding code blocks.
For all list items, provide a concise but full-sentence explanation.

MISSING CLAUSES:
- [List critical missing clauses like Governing Law, Arbitration, IP Assignment, or write ""None""]
RISKY CLAUSES:
- [List unfair or imbalanced terms like unilateral termination rights, uncapped liability, or write ""None""]
UNCLEAR LANGUAGE:
- [List ambiguous phrases or sections that lack objective definition, or write ""None""]
SUMMARY:
[Provide a brief, comprehensive, one-paragraph overall assessment and a clear recommendation (e.g., 'Requires legal review,' 'Low risk, proceed').]

Contract to Analyze:
---
{contractText}
---";
        }

        private async Task<string> CallHuggingFaceAPI(string prompt)
        {
            // Use local variable to avoid thread-safety issues with headers if HttpClient was shared differently
            using var client = _httpClient;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {AppConfig.HuggingFaceApiKey}");

            var requestData = new
            {
                inputs = prompt,
                parameters = new
                {
                    max_new_tokens = AppConfig.MaxNewTokens,
                    temperature = AppConfig.Temperature,
                    top_p = AppConfig.TopP,
                    do_sample = true
                },
                options = new
                {
                    wait_for_model = true
                }
            };

            string json = JsonConvert.SerializeObject(requestData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(AppConfig.HuggingFaceApiUrl, content);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                var resultArray = JsonConvert.DeserializeObject<List<HuggingFaceResponse>>(responseJson);

                if (resultArray?.Count > 0 && !string.IsNullOrEmpty(resultArray[0].GeneratedText))
                {
                    return resultArray[0].GeneratedText.Trim();
                }

                // Handle success but empty/unparsable response
                throw new InvalidOperationException("API response was successful but contained no generated text. Raw response: " + responseJson);
            }
            else
            {
                // Professional error message extraction
                string error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"AI Service Failed. Status: {response.StatusCode}. Details: {error}");
            }
        }

        private string FormatAIResponse(string aiResponse, string prompt)
        {
            // Clean-up logic for instruct models that may repeat the prompt
            string cleaned = aiResponse.Replace("```", "").Trim();

            // Attempt to strip the input prompt from the output
            if (cleaned.StartsWith(prompt, StringComparison.OrdinalIgnoreCase))
            {
                cleaned = cleaned.Substring(prompt.Length).Trim();
            }

            // Remove the contract text if the model accidentally included it in the output.
            int contractIndex = cleaned.IndexOf("Contract to Analyze:", StringComparison.OrdinalIgnoreCase);
            if (contractIndex > 0)
            {
                cleaned = cleaned.Substring(0, contractIndex).Trim();
            }

            // Ensure the main headers are present for parsing, even if the model was slightly off
            if (!cleaned.Contains("MISSING CLAUSES:") || !cleaned.Contains("SUMMARY:"))
            {
                // We don't want to use a mock, so we wrap the AI text to force parsing if it missed headers.
                return $"MISSING CLAUSES:\n- See summary\nRISKY CLAUSES:\n- See summary\nUNCLEAR LANGUAGE:\n- See summary\nSUMMARY:\n" + cleaned;
            }

            return cleaned;
        }
    }
}