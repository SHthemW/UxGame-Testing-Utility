namespace UxGame_Testing_Utility
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CENTER_PANEL = new Panel();
            _enableSeqChkbox = new CheckBox();
            TIP_2 = new Label();
            _infoBox = new TextBox();
            _refreshBtn = new Button();
            TIP = new Label();
            _skillIdBox = new TextBox();
            _applyAndDeployBtn = new Button();
            _logBox = new TextBox();
            TITLE = new Label();
            AUTHOR = new Label();
            _configBtn = new Button();
            _cleanBtn = new Button();
            CENTER_PANEL.SuspendLayout();
            SuspendLayout();
            // 
            // CENTER_PANEL
            // 
            CENTER_PANEL.BorderStyle = BorderStyle.FixedSingle;
            CENTER_PANEL.Controls.Add(_enableSeqChkbox);
            CENTER_PANEL.Controls.Add(TIP_2);
            CENTER_PANEL.Controls.Add(_infoBox);
            CENTER_PANEL.Controls.Add(_refreshBtn);
            CENTER_PANEL.Controls.Add(TIP);
            CENTER_PANEL.Controls.Add(_skillIdBox);
            CENTER_PANEL.Controls.Add(_applyAndDeployBtn);
            CENTER_PANEL.Location = new Point(22, 98);
            CENTER_PANEL.Name = "CENTER_PANEL";
            CENTER_PANEL.Size = new Size(248, 240);
            CENTER_PANEL.TabIndex = 0;
            // 
            // _enableSeqChkbox
            // 
            _enableSeqChkbox.AutoSize = true;
            _enableSeqChkbox.Location = new Point(59, 82);
            _enableSeqChkbox.Name = "_enableSeqChkbox";
            _enableSeqChkbox.Size = new Size(123, 21);
            _enableSeqChkbox.TabIndex = 6;
            _enableSeqChkbox.Text = "启用自动测试序列";
            _enableSeqChkbox.UseVisualStyleBackColor = true;
            _enableSeqChkbox.CheckedChanged += EnbaleSeqChkbox_CheckedChanged;
            // 
            // TIP_2
            // 
            TIP_2.AutoSize = true;
            TIP_2.Location = new Point(47, 157);
            TIP_2.Name = "TIP_2";
            TIP_2.Size = new Size(32, 17);
            TIP_2.TabIndex = 5;
            TIP_2.Text = "信息";
            // 
            // _infoBox
            // 
            _infoBox.BackColor = SystemColors.ButtonHighlight;
            _infoBox.BorderStyle = BorderStyle.None;
            _infoBox.Font = new Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point);
            _infoBox.ForeColor = SystemColors.GrayText;
            _infoBox.Location = new Point(40, 177);
            _infoBox.Multiline = true;
            _infoBox.Name = "_infoBox";
            _infoBox.ReadOnly = true;
            _infoBox.Size = new Size(166, 38);
            _infoBox.TabIndex = 4;
            // 
            // _refreshBtn
            // 
            _refreshBtn.Location = new Point(124, 113);
            _refreshBtn.Name = "_refreshBtn";
            _refreshBtn.Size = new Size(88, 28);
            _refreshBtn.TabIndex = 3;
            _refreshBtn.Text = "刷新(仅部署)";
            _refreshBtn.UseVisualStyleBackColor = true;
            _refreshBtn.Click += RefreshBtn_Click;
            // 
            // TIP
            // 
            TIP.AutoSize = true;
            TIP.Location = new Point(47, 28);
            TIP.Name = "TIP";
            TIP.Size = new Size(153, 17);
            TIP.TabIndex = 2;
            TIP.Text = "输入待测试技能的ID或名称";
            // 
            // _skillIdBox
            // 
            _skillIdBox.Location = new Point(40, 48);
            _skillIdBox.Name = "_skillIdBox";
            _skillIdBox.Size = new Size(166, 23);
            _skillIdBox.TabIndex = 1;
            // 
            // _applyAndDeployBtn
            // 
            _applyAndDeployBtn.Location = new Point(27, 113);
            _applyAndDeployBtn.Name = "_applyAndDeployBtn";
            _applyAndDeployBtn.Size = new Size(89, 28);
            _applyAndDeployBtn.TabIndex = 0;
            _applyAndDeployBtn.Text = "应用并部署";
            _applyAndDeployBtn.UseVisualStyleBackColor = true;
            _applyAndDeployBtn.Click += ApplyAndDeployBtn_Click;
            // 
            // _logBox
            // 
            _logBox.BackColor = SystemColors.ButtonHighlight;
            _logBox.BorderStyle = BorderStyle.None;
            _logBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
            _logBox.ForeColor = SystemColors.WindowFrame;
            _logBox.Location = new Point(23, 358);
            _logBox.Multiline = true;
            _logBox.Name = "_logBox";
            _logBox.ReadOnly = true;
            _logBox.ScrollBars = ScrollBars.Vertical;
            _logBox.Size = new Size(247, 132);
            _logBox.TabIndex = 3;
            _logBox.Text = "Welcome.";
            _logBox.TextChanged += LogBox_TextChanged;
            // 
            // TITLE
            // 
            TITLE.AutoSize = true;
            TITLE.Font = new Font("Lucida Sans Unicode", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            TITLE.Location = new Point(50, 26);
            TITLE.Name = "TITLE";
            TITLE.Size = new Size(185, 17);
            TITLE.TabIndex = 1;
            TITLE.Text = "UXGAME TESTING UTILITY";
            // 
            // AUTHOR
            // 
            AUTHOR.AutoSize = true;
            AUTHOR.Font = new Font("Trebuchet MS", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            AUTHOR.ForeColor = SystemColors.ButtonShadow;
            AUTHOR.Location = new Point(88, 56);
            AUTHOR.Name = "AUTHOR";
            AUTHOR.Size = new Size(109, 18);
            AUTHOR.TabIndex = 2;
            AUTHOR.Text = "designed by SHW";
            // 
            // _configBtn
            // 
            _configBtn.ForeColor = SystemColors.ControlText;
            _configBtn.Location = new Point(114, 506);
            _configBtn.Name = "_configBtn";
            _configBtn.Size = new Size(75, 23);
            _configBtn.TabIndex = 3;
            _configBtn.Text = "设置";
            _configBtn.UseVisualStyleBackColor = true;
            _configBtn.Click += ConfigBtn_Click;
            // 
            // _cleanBtn
            // 
            _cleanBtn.Location = new Point(195, 506);
            _cleanBtn.Name = "_cleanBtn";
            _cleanBtn.Size = new Size(75, 23);
            _cleanBtn.TabIndex = 4;
            _cleanBtn.Text = "清除";
            _cleanBtn.UseVisualStyleBackColor = true;
            _cleanBtn.Click += CleanBtn_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 562);
            Controls.Add(_cleanBtn);
            Controls.Add(_logBox);
            Controls.Add(_configBtn);
            Controls.Add(AUTHOR);
            Controls.Add(TITLE);
            Controls.Add(CENTER_PANEL);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "测试工具";
            CENTER_PANEL.ResumeLayout(false);
            CENTER_PANEL.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel CENTER_PANEL;
        private TextBox _skillIdBox;
        private Button _applyAndDeployBtn;
        private Label TITLE;
        private Label AUTHOR;
        private Button _configBtn;
        private Label TIP;
        private TextBox _logBox;
        private Button _cleanBtn;
        private Button _refreshBtn;
        private Label TIP_2;
        private TextBox _infoBox;
        private CheckBox _enableSeqChkbox;
    }
}