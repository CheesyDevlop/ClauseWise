namespace ClauseWise
{
    partial class ClauseWise
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClauseWise));
            panel1 = new Panel();
            lblAppName = new Label();
            picLogo = new PictureBox();
            btnMinimize = new Button();
            btnClose = new Button();
            panel2 = new Panel();
            btnHome = new Button();
            btnAnalyse = new Button();
            btnHistory = new Button();
            pnlAnalysis = new Panel();
            txtFilePath = new TextBox();
            btnUpload = new Button();
            btnAnalyze = new Button();
            pnlResultPanel = new Panel();
            lblAnalysisTitle = new Label();
            lblMissingClauses = new Label();
            pnlMissingClauses = new Panel();
            lblRiskyClauses = new Label();
            pnlRiskyClauses = new Panel();
            lblAmbiguousLanguage = new Label();
            pnlAmbiguousLanguage = new Panel();
            lblSummary = new Label();
            pnlSummary = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            panel2.SuspendLayout();
            pnlAnalysis.SuspendLayout();
            pnlResultPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(35, 44, 65);
            panel1.Controls.Add(lblAppName);
            panel1.Controls.Add(picLogo);
            panel1.Controls.Add(btnMinimize);
            panel1.Controls.Add(btnClose);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1150, 50);
            panel1.TabIndex = 2;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Microsoft Sans Serif", 16F);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(70, 12);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(100, 23);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "ClauseWise";
            // 
            // picLogo
            // 
            picLogo.Image = (Image)resources.GetObject("picLogo.Image");
            picLogo.Location = new Point(10, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(50, 50);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 1;
            picLogo.TabStop = false;
            // 
            // btnMinimize
            // 
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Microsoft Sans Serif", 16F);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(1050, 8);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(35, 35);
            btnMinimize.TabIndex = 2;
            btnMinimize.Text = "-";
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnClose
            // 
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Microsoft Sans Serif", 12F);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1100, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(35, 35);
            btnClose.TabIndex = 3;
            btnClose.Text = "X";
            btnClose.Click += btnClose_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(35, 44, 65);
            panel2.Controls.Add(btnHome);
            panel2.Controls.Add(btnAnalyse);
            panel2.Controls.Add(btnHistory);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 50);
            panel2.Name = "panel2";
            panel2.Size = new Size(150, 680);
            panel2.TabIndex = 1;
            // 
            // btnHome
            // 
            btnHome.BackgroundImage = (Image)resources.GetObject("btnHome.BackgroundImage");
            btnHome.BackgroundImageLayout = ImageLayout.Zoom;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Location = new Point(0, 40);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(150, 120);
            btnHome.TabIndex = 0;
            btnHome.Click += btnHome_Click;
            // 
            // btnAnalyse
            // 
            btnAnalyse.BackgroundImage = (Image)resources.GetObject("btnAnalyse.BackgroundImage");
            btnAnalyse.BackgroundImageLayout = ImageLayout.Zoom;
            btnAnalyse.FlatAppearance.BorderSize = 0;
            btnAnalyse.FlatStyle = FlatStyle.Flat;
            btnAnalyse.ForeColor = SystemColors.Control;
            btnAnalyse.Location = new Point(0, 200);
            btnAnalyse.Name = "btnAnalyse";
            btnAnalyse.Size = new Size(150, 120);
            btnAnalyse.TabIndex = 1;
            btnAnalyse.Text = "Analyze";
            btnAnalyse.TextAlign = ContentAlignment.BottomCenter;
            btnAnalyse.Click += btnAnalyse_Click;
            // 
            // btnHistory
            // 
            btnHistory.BackgroundImage = (Image)resources.GetObject("btnHistory.BackgroundImage");
            btnHistory.BackgroundImageLayout = ImageLayout.Zoom;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.ForeColor = SystemColors.Control;
            btnHistory.Location = new Point(0, 360);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(150, 120);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "History";
            btnHistory.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pnlAnalysis
            // 
            pnlAnalysis.Controls.Add(txtFilePath);
            pnlAnalysis.Controls.Add(btnUpload);
            pnlAnalysis.Controls.Add(btnAnalyze);
            pnlAnalysis.Controls.Add(pnlResultPanel);
            pnlAnalysis.Dock = DockStyle.Fill;
            pnlAnalysis.Location = new Point(150, 50);
            pnlAnalysis.Name = "pnlAnalysis";
            pnlAnalysis.Size = new Size(1000, 680);
            pnlAnalysis.TabIndex = 0;
            pnlAnalysis.Visible = false;
            // 
            // txtFilePath
            // 
            txtFilePath.Font = new Font("Microsoft Sans Serif", 12F);
            txtFilePath.Location = new Point(40, 40);
            txtFilePath.Multiline = true;
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(550, 50);
            txtFilePath.TabIndex = 0;
            txtFilePath.TextAlign = HorizontalAlignment.Center;
            // 
            // btnUpload
            // 
            btnUpload.Font = new Font("Microsoft Sans Serif", 14F);
            btnUpload.Location = new Point(40, 110);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(180, 55);
            btnUpload.TabIndex = 1;
            btnUpload.Text = "Upload Contract";
            btnUpload.Click += btnUpload_Click;
            // 
            // btnAnalyze
            // 
            btnAnalyze.Font = new Font("Microsoft Sans Serif", 14F);
            btnAnalyze.Location = new Point(250, 110);
            btnAnalyze.Name = "btnAnalyze";
            btnAnalyze.Size = new Size(200, 55);
            btnAnalyze.TabIndex = 2;
            btnAnalyze.Text = "Analyze Contract";
            btnAnalyze.Click += btnAnalyze_Click_1;
            // 
            // pnlResultPanel
            // 
            pnlResultPanel.AutoScroll = true;
            pnlResultPanel.Controls.Add(lblAnalysisTitle);
            pnlResultPanel.Controls.Add(lblMissingClauses);
            pnlResultPanel.Controls.Add(pnlMissingClauses);
            pnlResultPanel.Controls.Add(lblRiskyClauses);
            pnlResultPanel.Controls.Add(pnlRiskyClauses);
            pnlResultPanel.Controls.Add(lblAmbiguousLanguage);
            pnlResultPanel.Controls.Add(pnlAmbiguousLanguage);
            pnlResultPanel.Controls.Add(lblSummary);
            pnlResultPanel.Controls.Add(pnlSummary);
            pnlResultPanel.Location = new Point(0, 190);
            pnlResultPanel.Name = "pnlResultPanel";
            pnlResultPanel.Size = new Size(1000, 480);
            pnlResultPanel.TabIndex = 3;
            pnlResultPanel.Visible = false;
            // 
            // lblAnalysisTitle
            // 
            lblAnalysisTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAnalysisTitle.Location = new Point(20, 10);
            lblAnalysisTitle.Name = "lblAnalysisTitle";
            lblAnalysisTitle.Size = new Size(100, 23);
            lblAnalysisTitle.TabIndex = 0;
            lblAnalysisTitle.Text = "Analysis Report";
            // 
            // lblMissingClauses
            // 
            lblMissingClauses.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblMissingClauses.Location = new Point(20, 70);
            lblMissingClauses.Name = "lblMissingClauses";
            lblMissingClauses.Size = new Size(100, 23);
            lblMissingClauses.TabIndex = 1;
            lblMissingClauses.Text = "🔹 Missing Clauses";
            // 
            // pnlMissingClauses
            // 
            pnlMissingClauses.BorderStyle = BorderStyle.FixedSingle;
            pnlMissingClauses.Location = new Point(20, 100);
            pnlMissingClauses.Name = "pnlMissingClauses";
            pnlMissingClauses.Size = new Size(950, 80);
            pnlMissingClauses.TabIndex = 2;
            // 
            // lblRiskyClauses
            // 
            lblRiskyClauses.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblRiskyClauses.Location = new Point(20, 200);
            lblRiskyClauses.Name = "lblRiskyClauses";
            lblRiskyClauses.Size = new Size(100, 23);
            lblRiskyClauses.TabIndex = 3;
            lblRiskyClauses.Text = "🔹 Risky Clauses";
            // 
            // pnlRiskyClauses
            // 
            pnlRiskyClauses.BorderStyle = BorderStyle.FixedSingle;
            pnlRiskyClauses.Location = new Point(20, 230);
            pnlRiskyClauses.Name = "pnlRiskyClauses";
            pnlRiskyClauses.Size = new Size(950, 80);
            pnlRiskyClauses.TabIndex = 4;
            // 
            // lblAmbiguousLanguage
            // 
            lblAmbiguousLanguage.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAmbiguousLanguage.Location = new Point(20, 330);
            lblAmbiguousLanguage.Name = "lblAmbiguousLanguage";
            lblAmbiguousLanguage.Size = new Size(100, 23);
            lblAmbiguousLanguage.TabIndex = 5;
            lblAmbiguousLanguage.Text = "🔹 Ambiguous Language";
            // 
            // pnlAmbiguousLanguage
            // 
            pnlAmbiguousLanguage.BorderStyle = BorderStyle.FixedSingle;
            pnlAmbiguousLanguage.Location = new Point(20, 360);
            pnlAmbiguousLanguage.Name = "pnlAmbiguousLanguage";
            pnlAmbiguousLanguage.Size = new Size(950, 80);
            pnlAmbiguousLanguage.TabIndex = 6;
            // 
            // lblSummary
            // 
            lblSummary.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSummary.Location = new Point(20, 460);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(100, 23);
            lblSummary.TabIndex = 7;
            lblSummary.Text = "🔹 Summary";
            // 
            // pnlSummary
            // 
            pnlSummary.BorderStyle = BorderStyle.FixedSingle;
            pnlSummary.Location = new Point(20, 490);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(950, 80);
            pnlSummary.TabIndex = 8;
            // 
            // ClauseWise
            // 
            ClientSize = new Size(1150, 730);
            Controls.Add(pnlAnalysis);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ClauseWise";
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            panel2.ResumeLayout(false);
            pnlAnalysis.ResumeLayout(false);
            pnlAnalysis.PerformLayout();
            pnlResultPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btnHome;
        private Button btnAnalyse;
        private Button btnHistory;
        private Button btnClose;
        private Button btnMinimize;
        private PictureBox picLogo;
        private Label lblAppName;

        private Panel pnlAnalysis;
        private TextBox txtFilePath;
        private Button btnUpload;
        private Button btnAnalyze;

        private Panel pnlResultPanel;
        private Label lblAnalysisTitle;
        private Label lblMissingClauses;
        private Panel pnlMissingClauses;
        private Label lblRiskyClauses;
        private Panel pnlRiskyClauses;
        private Label lblAmbiguousLanguage;
        private Panel pnlAmbiguousLanguage;
        private Label lblSummary;
        private Panel pnlSummary;
    }
}
