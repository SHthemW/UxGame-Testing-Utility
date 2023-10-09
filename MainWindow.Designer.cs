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
            TIP = new Label();
            _skillIdBox = new TextBox();
            _startBtn = new Button();
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
            CENTER_PANEL.Controls.Add(TIP);
            CENTER_PANEL.Controls.Add(_skillIdBox);
            CENTER_PANEL.Controls.Add(_startBtn);
            CENTER_PANEL.Location = new Point(22, 98);
            CENTER_PANEL.Name = "CENTER_PANEL";
            CENTER_PANEL.Size = new Size(248, 154);
            CENTER_PANEL.TabIndex = 0;
            // 
            // TIP
            // 
            TIP.AutoSize = true;
            TIP.Location = new Point(53, 28);
            TIP.Name = "TIP";
            TIP.Size = new Size(141, 17);
            TIP.TabIndex = 2;
            TIP.Text = "在此输入待测试技能的ID";
            // 
            // _skillIdBox
            // 
            _skillIdBox.Location = new Point(40, 48);
            _skillIdBox.Name = "_skillIdBox";
            _skillIdBox.Size = new Size(166, 23);
            _skillIdBox.TabIndex = 1;
            // 
            // _startBtn
            // 
            _startBtn.Location = new Point(71, 92);
            _startBtn.Name = "_startBtn";
            _startBtn.Size = new Size(105, 32);
            _startBtn.TabIndex = 0;
            _startBtn.Text = "应用测试并部署";
            _startBtn.UseVisualStyleBackColor = true;
            // 
            // _logBox
            // 
            _logBox.BackColor = SystemColors.ButtonHighlight;
            _logBox.BorderStyle = BorderStyle.None;
            _logBox.ForeColor = SystemColors.WindowFrame;
            _logBox.Location = new Point(23, 275);
            _logBox.Multiline = true;
            _logBox.Name = "_logBox";
            _logBox.Size = new Size(247, 94);
            _logBox.TabIndex = 3;
            _logBox.Text = "Welcome.";
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
            AUTHOR.ForeColor = SystemColors.ButtonShadow;
            AUTHOR.Location = new Point(94, 56);
            AUTHOR.Name = "AUTHOR";
            AUTHOR.Size = new Size(97, 17);
            AUTHOR.TabIndex = 2;
            AUTHOR.Text = "design by SHW";
            // 
            // _configBtn
            // 
            _configBtn.ForeColor = SystemColors.ControlText;
            _configBtn.Location = new Point(114, 385);
            _configBtn.Name = "_configBtn";
            _configBtn.Size = new Size(75, 23);
            _configBtn.TabIndex = 3;
            _configBtn.Text = "配置";
            _configBtn.UseVisualStyleBackColor = true;
            // 
            // _cleanBtn
            // 
            _cleanBtn.Location = new Point(195, 385);
            _cleanBtn.Name = "_cleanBtn";
            _cleanBtn.Size = new Size(75, 23);
            _cleanBtn.TabIndex = 4;
            _cleanBtn.Text = "清除";
            _cleanBtn.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 434);
            Controls.Add(_cleanBtn);
            Controls.Add(_logBox);
            Controls.Add(_configBtn);
            Controls.Add(AUTHOR);
            Controls.Add(TITLE);
            Controls.Add(CENTER_PANEL);
            MaximizeBox = false;
            Name = "MainWindow";
            Text = "测试工具";
            Load += MainWindow_Load;
            CENTER_PANEL.ResumeLayout(false);
            CENTER_PANEL.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel CENTER_PANEL;
        private TextBox _skillIdBox;
        private Button _startBtn;
        private Label TITLE;
        private Label AUTHOR;
        private Button _configBtn;
        private Label TIP;
        private TextBox _logBox;
        private Button _cleanBtn;
    }
}