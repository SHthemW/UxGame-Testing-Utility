namespace UxGame_Testing_Utility
{
    partial class ConfigWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TIP_DATASRC = new Label();
            _dataSrcPathBox = new TextBox();
            _deployProgPathBox = new TextBox();
            TIP_PROG = new Label();
            TIP = new Label();
            _okBtn = new Button();
            TITLE_1 = new Label();
            TITLE_2 = new Label();
            _enableShowSkillDetailsChkBox = new CheckBox();
            _autoCloseChkBox = new CheckBox();
            _autoOpenChkBox = new CheckBox();
            _E2JWaitTimeBox = new TextBox();
            TITLE_3 = new Label();
            _J2BWaitTimeBox = new TextBox();
            TITLE_4 = new Label();
            SuspendLayout();
            // 
            // TIP_DATASRC
            // 
            TIP_DATASRC.AutoSize = true;
            TIP_DATASRC.Location = new Point(23, 66);
            TIP_DATASRC.Name = "TIP_DATASRC";
            TIP_DATASRC.Size = new Size(71, 17);
            TIP_DATASRC.TabIndex = 0;
            TIP_DATASRC.Text = "数据源路径:";
            // 
            // _dataSrcPathBox
            // 
            _dataSrcPathBox.Location = new Point(23, 86);
            _dataSrcPathBox.Name = "_dataSrcPathBox";
            _dataSrcPathBox.Size = new Size(207, 23);
            _dataSrcPathBox.TabIndex = 1;
            // 
            // _deployProgPathBox
            // 
            _deployProgPathBox.Location = new Point(23, 142);
            _deployProgPathBox.Name = "_deployProgPathBox";
            _deployProgPathBox.Size = new Size(207, 23);
            _deployProgPathBox.TabIndex = 3;
            // 
            // TIP_PROG
            // 
            TIP_PROG.AutoSize = true;
            TIP_PROG.Location = new Point(23, 122);
            TIP_PROG.Name = "TIP_PROG";
            TIP_PROG.Size = new Size(83, 17);
            TIP_PROG.TabIndex = 2;
            TIP_PROG.Text = "部署程序路径:";
            // 
            // TIP
            // 
            TIP.AutoSize = true;
            TIP.ForeColor = SystemColors.ControlDark;
            TIP.Location = new Point(102, 32);
            TIP.Name = "TIP";
            TIP.Size = new Size(128, 17);
            TIP.TabIndex = 4;
            TIP.Text = "路径请落实到具体文件";
            // 
            // _okBtn
            // 
            _okBtn.DialogResult = DialogResult.OK;
            _okBtn.Location = new Point(89, 389);
            _okBtn.Name = "_okBtn";
            _okBtn.Size = new Size(75, 23);
            _okBtn.TabIndex = 5;
            _okBtn.Text = "确定";
            _okBtn.UseVisualStyleBackColor = true;
            // 
            // TITLE_1
            // 
            TITLE_1.AutoSize = true;
            TITLE_1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TITLE_1.Location = new Point(23, 32);
            TITLE_1.Name = "TITLE_1";
            TITLE_1.Size = new Size(56, 17);
            TITLE_1.TabIndex = 6;
            TITLE_1.Text = "资产配置";
            // 
            // TITLE_2
            // 
            TITLE_2.AutoSize = true;
            TITLE_2.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TITLE_2.Location = new Point(23, 246);
            TITLE_2.Name = "TITLE_2";
            TITLE_2.Size = new Size(56, 17);
            TITLE_2.TabIndex = 8;
            TITLE_2.Text = "功能设置";
            // 
            // _enableShowSkillDetailsChkBox
            // 
            _enableShowSkillDetailsChkBox.AutoSize = true;
            _enableShowSkillDetailsChkBox.Location = new Point(23, 276);
            _enableShowSkillDetailsChkBox.Name = "_enableShowSkillDetailsChkBox";
            _enableShowSkillDetailsChkBox.Size = new Size(171, 21);
            _enableShowSkillDetailsChkBox.TabIndex = 9;
            _enableShowSkillDetailsChkBox.Text = "加载技能后打印其详细信息";
            _enableShowSkillDetailsChkBox.UseVisualStyleBackColor = true;
            // 
            // _autoCloseChkBox
            // 
            _autoCloseChkBox.AutoSize = true;
            _autoCloseChkBox.Location = new Point(23, 315);
            _autoCloseChkBox.Name = "_autoCloseChkBox";
            _autoCloseChkBox.Size = new Size(159, 21);
            _autoCloseChkBox.TabIndex = 10;
            _autoCloseChkBox.Text = "进程占用时自动关闭文件";
            _autoCloseChkBox.UseVisualStyleBackColor = true;
            // 
            // _autoOpenChkBox
            // 
            _autoOpenChkBox.AutoSize = true;
            _autoOpenChkBox.Location = new Point(23, 342);
            _autoOpenChkBox.Name = "_autoOpenChkBox";
            _autoOpenChkBox.Size = new Size(159, 21);
            _autoOpenChkBox.TabIndex = 11;
            _autoOpenChkBox.Text = "完成修改后自动打开文件";
            _autoOpenChkBox.UseVisualStyleBackColor = true;
            // 
            // _E2JWaitTimeBox
            // 
            _E2JWaitTimeBox.Location = new Point(23, 200);
            _E2JWaitTimeBox.Name = "_E2JWaitTimeBox";
            _E2JWaitTimeBox.Size = new Size(91, 23);
            _E2JWaitTimeBox.TabIndex = 13;
            // 
            // TITLE_3
            // 
            TITLE_3.AutoSize = true;
            TITLE_3.Location = new Point(23, 180);
            TITLE_3.Name = "TITLE_3";
            TITLE_3.Size = new Size(95, 17);
            TITLE_3.TabIndex = 12;
            TITLE_3.Text = "E2J等待时间ms:";
            // 
            // _J2BWaitTimeBox
            // 
            _J2BWaitTimeBox.Location = new Point(138, 200);
            _J2BWaitTimeBox.Name = "_J2BWaitTimeBox";
            _J2BWaitTimeBox.Size = new Size(92, 23);
            _J2BWaitTimeBox.TabIndex = 14;
            // 
            // TITLE_4
            // 
            TITLE_4.AutoSize = true;
            TITLE_4.Location = new Point(138, 180);
            TITLE_4.Name = "TITLE_4";
            TITLE_4.Size = new Size(96, 17);
            TITLE_4.TabIndex = 15;
            TITLE_4.Text = "J2B等待时间ms:";
            // 
            // ConfigWindow
            // 
            AcceptButton = _okBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 441);
            Controls.Add(TITLE_4);
            Controls.Add(_J2BWaitTimeBox);
            Controls.Add(_E2JWaitTimeBox);
            Controls.Add(TITLE_3);
            Controls.Add(_autoOpenChkBox);
            Controls.Add(_autoCloseChkBox);
            Controls.Add(_enableShowSkillDetailsChkBox);
            Controls.Add(TITLE_2);
            Controls.Add(TITLE_1);
            Controls.Add(_okBtn);
            Controls.Add(TIP);
            Controls.Add(_deployProgPathBox);
            Controls.Add(TIP_PROG);
            Controls.Add(_dataSrcPathBox);
            Controls.Add(TIP_DATASRC);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConfigWindow";
            Text = "设置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TIP_DATASRC;
        private TextBox _dataSrcPathBox;
        private TextBox _deployProgPathBox;
        private Label TIP_PROG;
        private Label TIP;
        private Button _okBtn;
        private Label TITLE_1;
        private Label TITLE_2;
        private CheckBox _enableShowSkillDetailsChkBox;
        private CheckBox _autoCloseChkBox;
        private CheckBox _autoOpenChkBox;
        private TextBox _E2JWaitTimeBox;
        private Label TITLE_3;
        private TextBox _J2BWaitTimeBox;
        private Label TITLE_4;
    }
}