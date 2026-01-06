using System;

namespace ClauseWise.Core
{
    /// <summary>
    /// Centralized configuration for the application.
    /// These constants define the external dependencies and AI parameters.
    /// </summary>
    public static class AppConfig
    {
        // 🚨 IMPORTANT: Replace this placeholder with your actual HuggingFace API key.
        // It is recommended to use environment variables in a production setup.
        public const string HuggingFaceApiKey = "API KEY HERE";

        // Model and API settings
        // NOTE: The base URL has been updated from 'api-inference.huggingface.co' to 'router.huggingface.co' 
        // to address the 410 Gone error.
        public const string HuggingFaceApiBaseUrl = "https://api-inference.huggingface.co";


        // Using Mistral, the preferred model for high-quality analysis.
        public const string HuggingFaceModelId = "mistralai/Mistral-7B-Instruct-v0.2";
        //public const string HuggingFaceModelId = "gpt2";

        // Final URL: https://api-inference.huggingface.co/models/mistralai/Mistral-7B-Instruct-v0.2
        public static readonly string HuggingFaceApiUrl = $"{HuggingFaceApiBaseUrl}/models/{HuggingFaceModelId}";

        // AI Generation Parameters
        public const int MaxContractTextLimit = 10000; // Character limit sent to the model
        public const int MaxNewTokens = 1500; // Max output length for detailed analysis
        public const double Temperature = 0.7;
        public const double TopP = 0.9;

        // Increased timeout to accommodate the large model loading time on the free tier.
        public const int ApiTimeoutSeconds = 180;
    }

    /// <summary>
    /// Custom exception for when the API key is not configured.
    /// </summary>
    public class MissingApiKeyException : Exception
    {
        public MissingApiKeyException()
            : base("The HuggingFace API key is not configured in AppConfig. Please configure the key to run AI analysis.")
        {
        }
    }
}