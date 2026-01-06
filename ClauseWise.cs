using ClauseWise.Core;
using ClauseWise.Services; // New namespace for the service layer
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http; // Still needed for HttpRequestException
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClauseWise
{
    // The main class should only handle UI logic and delegate business logic to services.
    public partial class ClauseWise : Form
    {
        private readonly AiContractAnalyzerService _analyzerService = new AiContractAnalyzerService();
        private string activeTab = "Home";

        // Removed: public class HuggingFaceResponse (moved to AiContractAnalyzerService.cs)
        // Removed: private string filePath (not needed, only txtFilePath.Text is used)
        // Removed: private string fileContent (not needed, read in Analyze method)

        public ClauseWise()
        {
            InitializeComponent();
            activeTab = "Home";
            UpdateNavigationColors();
            HideAnalysisInterface();
            btnHome.BackColor = Color.FromArgb(101, 52, 172);
        }

        private void btnClose_Click(object sender, EventArgs e) => Application.Exit();
        private void btnMinimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        // ---------------------------
        // TAB NAVIGATION (No Changes)
        // ---------------------------

        private void btnAnalyse_Click(object sender, EventArgs e)
        {
            if (activeTab == "Analyse") return;
            activeTab = "Analyse";
            UpdateNavigationColors();
            ShowAnalysisInterface();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (activeTab == "Home") return;
            activeTab = "Home";
            UpdateNavigationColors();
            HideAnalysisInterface();
        }

        private void UpdateNavigationColors()
        {
            btnHome.BackColor = activeTab == "Home" ? Color.FromArgb(101, 52, 172) : Color.FromArgb(54, 26, 104);
            btnAnalyse.BackColor = activeTab == "Analyse" ? Color.FromArgb(101, 52, 172) : Color.FromArgb(54, 26, 104);
        }

        // ---------------------------
        // SHOW / HIDE PANELS (No Changes)
        // ---------------------------

        private void ShowAnalysisInterface()
        {
            pnlAnalysis.Visible = true;
            pnlAnalysis.Dock = DockStyle.Fill;
            pnlAnalysis.BringToFront();

            if (Controls.ContainsKey("pnlHome"))
                Controls["pnlHome"].Visible = false;

            pnlResultPanel.Visible = false;
            txtFilePath.Text = "";

            btnAnalyze.Visible = true;
            btnUpload.Visible = true;
            txtFilePath.Visible = true;

            pnlAnalysis.Parent?.BringToFront();
        }

        private void HideAnalysisInterface()
        {
            pnlAnalysis.Visible = false;
            pnlAnalysis.Dock = DockStyle.None;

            if (Controls.ContainsKey("pnlHome"))
                Controls["pnlHome"].Visible = true;
        }

        // ---------------------------
        // FILE UPLOAD + ANALYSIS (Updated to use async file I/O and service)
        // ---------------------------

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|Word Documents (*.doc;*.docx)|*.doc;*.docx|PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*",
                Title = "Select Contract File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private async void btnAnalyze_Click_1(object sender, EventArgs e)
        {
            // Use a using statement to ensure the cursor is reset, even on crash
            using (new CursorScope(Cursors.WaitCursor))
            {
                btnAnalyze.Text = "Analyzing...";
                btnAnalyze.Enabled = false;

                try
                {
                    string filePath = txtFilePath.Text;
                    if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                    {
                        MessageBox.Show("Please upload a contract file first!", "Upload Required",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Use modern, asynchronous file reading
                    string contractText = await File.ReadAllTextAsync(filePath);

                    // Delegate the core logic to the service layer
                    string result = await _analyzerService.AnalyzeContractAsync(contractText);

                    DisplayAnalysisResults(result);
                    pnlResultPanel.Visible = true;
                }
                catch (MissingApiKeyException ex)
                {
                    // Professional, specific handling for configuration errors
                    MessageBox.Show($"Configuration Error: {ex.Message}\n\nPlease update the HuggingFaceApiKey in AppConfig.cs.", "API Key Missing",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (HttpRequestException ex)
                {
                    // Professional handling for network/API errors
                    MessageBox.Show($"AI Service Failure: The AI model could not be reached or returned an error. This usually indicates a problem with the API key, model loading, or network. Details: {ex.Message}", "AI Connection Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // General error for anything else
                    MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Analysis Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnAnalyze.Text = "Analyze Contract";
                    btnAnalyze.Enabled = true;
                }
            }
        }

        // Helper class to manage cursor state professionally (like a using statement)
        private class CursorScope : IDisposable
        {
            private readonly Cursor _originalCursor;

            public CursorScope(Cursor newCursor)
            {
                _originalCursor = Cursor.Current;
                Cursor.Current = newCursor;
            }

            public void Dispose()
            {
                Cursor.Current = _originalCursor;
            }
        }

        // ---------------------------
        // CORE AI LOGIC (REMOVED)
        // ---------------------------
        // The following functions have been removed to ensure Separation of Concerns (SoC)
        // and have been moved to the AiContractAnalyzerService.cs file:
        // - AnalyzeContractWithAI
        // - CreateAnalysisPrompt
        // - CallHuggingFaceAPI
        // - FormatAIResponse
        // - GetSmartMockAnalysis (removed completely as per request)

        // ---------------------------
        // RENDERING ANALYSIS OUTPUT (Minor color and text updates)
        // ---------------------------

        private void DisplayAnalysisResults(string analysisResult)
        {
            ClearAllPanels();
            var sections = ParseAnalysisSections(analysisResult);

            DisplaySection(pnlMissingClauses, "⚠️ Missing Clauses", sections.MissingClauses, Color.FromArgb(255, 230, 230)); // Stronger warning color
            DisplaySection(pnlRiskyClauses, "🚨 Risky Clauses", sections.RiskyClauses, Color.FromArgb(255, 243, 205)); // Stronger warning color
            DisplaySection(pnlAmbiguousLanguage, "❓ Ambiguous Language", sections.AmbiguousLanguage, Color.FromArgb(228, 240, 255));
            DisplaySection(pnlSummary, "✅ Summary & Recommendations", sections.Summary, Color.FromArgb(230, 245, 230));
        }

        private void ClearAllPanels()
        {
            pnlMissingClauses.Controls.Clear();
            pnlRiskyClauses.Controls.Clear();
            pnlAmbiguousLanguage.Controls.Clear();
            pnlSummary.Controls.Clear();

            Panel[] all = { pnlMissingClauses, pnlRiskyClauses, pnlAmbiguousLanguage, pnlSummary };

            foreach (Panel p in all)
            {
                p.Padding = new Padding(10);
                p.AutoScroll = true;
            }
        }

        private (List<string> MissingClauses, List<string> RiskyClauses,
                 List<string> AmbiguousLanguage, List<string> Summary)
                 ParseAnalysisSections(string result)
        {
            var missing = new List<string>();
            var risky = new List<string>();
            var ambiguous = new List<string>();
            var summary = new List<string>();

            string current = "";
            var lines = result.Split('\n');

            foreach (var lineRaw in lines)
            {
                string line = lineRaw.Trim();

                if (line.StartsWith("MISSING CLAUSES:", StringComparison.OrdinalIgnoreCase)) current = "missing";
                else if (line.StartsWith("RISKY CLAUSES:", StringComparison.OrdinalIgnoreCase)) current = "risky";
                else if (line.StartsWith("UNCLEAR LANGUAGE:", StringComparison.OrdinalIgnoreCase)) current = "ambiguous";
                else if (line.StartsWith("SUMMARY:", StringComparison.OrdinalIgnoreCase))
                {
                    current = "summary";
                    // Take the remainder of the line after "SUMMARY:" as the start of the summary
                    string firstSummary = line.Substring("SUMMARY:".Length).Trim();
                    if (firstSummary.Length > 0) summary.Add(firstSummary);
                }
                else if (line.StartsWith("- "))
                {
                    string item = line.Substring(2).Trim();
                    if (current == "missing") missing.Add(item);
                    else if (current == "risky") risky.Add(item);
                    else if (current == "ambiguous") ambiguous.Add(item);
                }
                else if (current == "summary" && !string.IsNullOrWhiteSpace(line))
                {
                    summary.Add(line);
                }
            }

            return (missing, risky, ambiguous, summary);
        }

        private void DisplaySection(Panel panel, string title, List<string> items, Color cardColor)
        {
            int y = 10;

            Label header = new Label
            {
                Text = title,
                Font = new Font("Segoe UI Semibold", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(35, 44, 65),
                AutoSize = true,
                Location = new Point(0, y)
            };
            panel.Controls.Add(header);

            y += 35;

            // Filter out 'None' entries before checking if the list is empty
            items = items.Where(i => !i.Equals("None", StringComparison.OrdinalIgnoreCase)).ToList();

            if (items.Count == 0)
            {
                Label emptyLabel = new Label
                {
                    Text = "No issues detected in this category",
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(0, y)
                };
                panel.Controls.Add(emptyLabel);
                return;
            }

            if (title.Contains("Summary"))
            {
                Panel summaryCard = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = cardColor,
                    Size = new Size(panel.ClientSize.Width - 20, 120),
                    Location = new Point(0, y),
                    Padding = new Padding(12)
                };

                Label summaryLabel = new Label
                {
                    Text = string.Join(" ", items),
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(50, 50, 50),
                    AutoSize = false,
                    Size = new Size(summaryCard.ClientSize.Width - 24, 96),
                    Location = new Point(6, 6),
                    TextAlign = ContentAlignment.TopLeft,
                    BackColor = cardColor
                };

                summaryCard.Controls.Add(summaryLabel);
                panel.Controls.Add(summaryCard);
                return;
            }

            foreach (string item in items)
            {
                Panel card = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = cardColor,
                    Size = new Size(panel.ClientSize.Width - 20, 70),
                    Location = new Point(0, y),
                    Padding = new Padding(10)
                };

                Label label = new Label
                {
                    Text = $"• {item}",
                    Font = new Font("Segoe UI", 10),
                    AutoSize = false,
                    Size = new Size(card.ClientSize.Width - 20, 50),
                    Location = new Point(5, 5),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = cardColor
                };

                card.Controls.Add(label);
                panel.Controls.Add(card);

                y += 75;
            }
        }
    }
}