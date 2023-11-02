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
            _testResSavePathBox = new TextBox();
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
            TIT_E2J = new Label();
            label1 = new Label();
            _rfsWaitTImeBox = new TextBox();
            TIT_ACTCONF = new Label();
            TIT_REC = new Label();
            TIT_SCOPE = new Label();
            _recScopeLBox = new TextBox();
            _recScopeTBox = new TextBox();
            TIT_L = new Label();
            TIT_T = new Label();
            TIT_H = new Label();
            TIT_W = new Label();
            _recScopeHBox = new TextBox();
            _recScopeWBox = new TextBox();
            TIT_RECDURATION = new Label();
            _recPropDuBox = new TextBox();
            TIT_D = new Label();
            TIT_Q = new Label();
            _recPropQlBox = new TextBox();
            SuspendLayout();
            // 
            // TIP_DATASRC
            // 
            TIP_DATASRC.AutoSize = true;
            TIP_DATASRC.Location = new Point(23, 66);
            TIP_DATASRC.Name = "TIP_DATASRC";
            TIP_DATASRC.Size = new Size(175, 17);
            TIP_DATASRC.TabIndex = 0;
            TIP_DATASRC.Text = "数据源表路径(落实到具体文件):";
            // 
            // _dataSrcPathBox
            // 
            _dataSrcPathBox.Location = new Point(23, 86);
            _dataSrcPathBox.Name = "_dataSrcPathBox";
            _dataSrcPathBox.Size = new Size(207, 23);
            _dataSrcPathBox.TabIndex = 1;
            // 
            // _testResSavePathBox
            // 
            _testResSavePathBox.Location = new Point(23, 142);
            _testResSavePathBox.Name = "_testResSavePathBox";
            _testResSavePathBox.Size = new Size(207, 23);
            _testResSavePathBox.TabIndex = 3;
            // 
            // TIP_PROG
            // 
            TIP_PROG.AutoSize = true;
            TIP_PROG.Location = new Point(23, 122);
            TIP_PROG.Name = "TIP_PROG";
            TIP_PROG.Size = new Size(131, 17);
            TIP_PROG.TabIndex = 2;
            TIP_PROG.Text = "测试产出资源存放路径:";
            // 
            // TIP
            // 
            TIP.AutoSize = true;
            TIP.ForeColor = SystemColors.ControlDark;
            TIP.Location = new Point(90, 32);
            TIP.Name = "TIP";
            TIP.Size = new Size(140, 17);
            TIP.TabIndex = 4;
            TIP.Text = "点击确定将自动保存设置";
            // 
            // _okBtn
            // 
            _okBtn.DialogResult = DialogResult.OK;
            _okBtn.Location = new Point(89, 540);
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
            TITLE_2.Location = new Point(23, 397);
            TITLE_2.Name = "TITLE_2";
            TITLE_2.Size = new Size(56, 17);
            TITLE_2.TabIndex = 8;
            TITLE_2.Text = "功能设置";
            // 
            // _enableShowSkillDetailsChkBox
            // 
            _enableShowSkillDetailsChkBox.AutoSize = true;
            _enableShowSkillDetailsChkBox.Location = new Point(23, 427);
            _enableShowSkillDetailsChkBox.Name = "_enableShowSkillDetailsChkBox";
            _enableShowSkillDetailsChkBox.Size = new Size(171, 21);
            _enableShowSkillDetailsChkBox.TabIndex = 9;
            _enableShowSkillDetailsChkBox.Text = "加载技能后打印其详细信息";
            _enableShowSkillDetailsChkBox.UseVisualStyleBackColor = true;
            // 
            // _autoCloseChkBox
            // 
            _autoCloseChkBox.AutoSize = true;
            _autoCloseChkBox.Location = new Point(23, 466);
            _autoCloseChkBox.Name = "_autoCloseChkBox";
            _autoCloseChkBox.Size = new Size(159, 21);
            _autoCloseChkBox.TabIndex = 10;
            _autoCloseChkBox.Text = "进程占用时自动关闭文件";
            _autoCloseChkBox.UseVisualStyleBackColor = true;
            // 
            // _autoOpenChkBox
            // 
            _autoOpenChkBox.AutoSize = true;
            _autoOpenChkBox.Location = new Point(23, 493);
            _autoOpenChkBox.Name = "_autoOpenChkBox";
            _autoOpenChkBox.Size = new Size(159, 21);
            _autoOpenChkBox.TabIndex = 11;
            _autoOpenChkBox.Text = "完成修改后自动打开文件";
            _autoOpenChkBox.UseVisualStyleBackColor = true;
            // 
            // _E2JWaitTimeBox
            // 
            _E2JWaitTimeBox.Location = new Point(59, 236);
            _E2JWaitTimeBox.Name = "_E2JWaitTimeBox";
            _E2JWaitTimeBox.Size = new Size(29, 23);
            _E2JWaitTimeBox.TabIndex = 13;
            // 
            // TITLE_3
            // 
            TITLE_3.AutoSize = true;
            TITLE_3.Location = new Point(23, 216);
            TITLE_3.Name = "TITLE_3";
            TITLE_3.Size = new Size(132, 17);
            TITLE_3.TabIndex = 12;
            TITLE_3.Text = "部署行为等待时间(ms):";
            // 
            // _J2BWaitTimeBox
            // 
            _J2BWaitTimeBox.Location = new Point(131, 236);
            _J2BWaitTimeBox.Name = "_J2BWaitTimeBox";
            _J2BWaitTimeBox.Size = new Size(29, 23);
            _J2BWaitTimeBox.TabIndex = 14;
            // 
            // TITLE_4
            // 
            TITLE_4.AutoSize = true;
            TITLE_4.Location = new Point(94, 239);
            TITLE_4.Name = "TITLE_4";
            TITLE_4.Size = new Size(31, 17);
            TITLE_4.TabIndex = 15;
            TITLE_4.Text = "J2B:";
            // 
            // TIT_E2J
            // 
            TIT_E2J.AutoSize = true;
            TIT_E2J.Location = new Point(23, 239);
            TIT_E2J.Name = "TIT_E2J";
            TIT_E2J.Size = new Size(30, 17);
            TIT_E2J.TabIndex = 16;
            TIT_E2J.Text = "E2J:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 239);
            label1.Name = "label1";
            label1.Size = new Size(29, 17);
            label1.TabIndex = 18;
            label1.Text = "Rfs:";
            // 
            // _rfsWaitTImeBox
            // 
            _rfsWaitTImeBox.Location = new Point(201, 236);
            _rfsWaitTImeBox.Name = "_rfsWaitTImeBox";
            _rfsWaitTImeBox.Size = new Size(29, 23);
            _rfsWaitTImeBox.TabIndex = 17;
            // 
            // TIT_ACTCONF
            // 
            TIT_ACTCONF.AutoSize = true;
            TIT_ACTCONF.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TIT_ACTCONF.Location = new Point(23, 185);
            TIT_ACTCONF.Name = "TIT_ACTCONF";
            TIT_ACTCONF.Size = new Size(56, 17);
            TIT_ACTCONF.TabIndex = 19;
            TIT_ACTCONF.Text = "行为设置";
            // 
            // TIT_REC
            // 
            TIT_REC.AutoSize = true;
            TIT_REC.Location = new Point(23, 273);
            TIT_REC.Name = "TIT_REC";
            TIT_REC.Size = new Size(59, 17);
            TIT_REC.TabIndex = 20;
            TIT_REC.Text = "自动录制:";
            // 
            // TIT_SCOPE
            // 
            TIT_SCOPE.AutoSize = true;
            TIT_SCOPE.Location = new Point(23, 299);
            TIT_SCOPE.Name = "TIT_SCOPE";
            TIT_SCOPE.Size = new Size(35, 17);
            TIT_SCOPE.TabIndex = 21;
            TIT_SCOPE.Text = "范围:";
            // 
            // _recScopeLBox
            // 
            _recScopeLBox.Location = new Point(110, 296);
            _recScopeLBox.Name = "_recScopeLBox";
            _recScopeLBox.Size = new Size(50, 23);
            _recScopeLBox.TabIndex = 22;
            // 
            // _recScopeTBox
            // 
            _recScopeTBox.Location = new Point(180, 296);
            _recScopeTBox.Name = "_recScopeTBox";
            _recScopeTBox.Size = new Size(50, 23);
            _recScopeTBox.TabIndex = 23;
            // 
            // TIT_L
            // 
            TIT_L.AutoSize = true;
            TIT_L.Location = new Point(94, 299);
            TIT_L.Name = "TIT_L";
            TIT_L.Size = new Size(14, 17);
            TIT_L.TabIndex = 24;
            TIT_L.Text = "L";
            // 
            // TIT_T
            // 
            TIT_T.AutoSize = true;
            TIT_T.Location = new Point(163, 299);
            TIT_T.Name = "TIT_T";
            TIT_T.Size = new Size(15, 17);
            TIT_T.TabIndex = 25;
            TIT_T.Text = "T";
            // 
            // TIT_H
            // 
            TIT_H.AutoSize = true;
            TIT_H.Location = new Point(162, 328);
            TIT_H.Name = "TIT_H";
            TIT_H.Size = new Size(17, 17);
            TIT_H.TabIndex = 29;
            TIT_H.Text = "H";
            // 
            // TIT_W
            // 
            TIT_W.AutoSize = true;
            TIT_W.Location = new Point(88, 328);
            TIT_W.Name = "TIT_W";
            TIT_W.Size = new Size(20, 17);
            TIT_W.TabIndex = 28;
            TIT_W.Text = "W";
            // 
            // _recScopeHBox
            // 
            _recScopeHBox.Location = new Point(180, 325);
            _recScopeHBox.Name = "_recScopeHBox";
            _recScopeHBox.Size = new Size(50, 23);
            _recScopeHBox.TabIndex = 27;
            // 
            // _recScopeWBox
            // 
            _recScopeWBox.Location = new Point(110, 325);
            _recScopeWBox.Name = "_recScopeWBox";
            _recScopeWBox.Size = new Size(50, 23);
            _recScopeWBox.TabIndex = 26;
            // 
            // TIT_RECDURATION
            // 
            TIT_RECDURATION.AutoSize = true;
            TIT_RECDURATION.Location = new Point(23, 357);
            TIT_RECDURATION.Name = "TIT_RECDURATION";
            TIT_RECDURATION.Size = new Size(35, 17);
            TIT_RECDURATION.TabIndex = 30;
            TIT_RECDURATION.Text = "属性:";
            // 
            // _recPropDuBox
            // 
            _recPropDuBox.Location = new Point(110, 354);
            _recPropDuBox.Name = "_recPropDuBox";
            _recPropDuBox.Size = new Size(50, 23);
            _recPropDuBox.TabIndex = 31;
            // 
            // TIT_D
            // 
            TIT_D.AutoSize = true;
            TIT_D.Location = new Point(91, 357);
            TIT_D.Name = "TIT_D";
            TIT_D.Size = new Size(17, 17);
            TIT_D.TabIndex = 32;
            TIT_D.Text = "D";
            // 
            // TIT_Q
            // 
            TIT_Q.AutoSize = true;
            TIT_Q.Location = new Point(161, 357);
            TIT_Q.Name = "TIT_Q";
            TIT_Q.Size = new Size(18, 17);
            TIT_Q.TabIndex = 34;
            TIT_Q.Text = "Q";
            // 
            // _recPropQlBox
            // 
            _recPropQlBox.Location = new Point(180, 354);
            _recPropQlBox.Name = "_recPropQlBox";
            _recPropQlBox.Size = new Size(50, 23);
            _recPropQlBox.TabIndex = 33;
            // 
            // ConfigWindow
            // 
            AcceptButton = _okBtn;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 599);
            Controls.Add(TIT_Q);
            Controls.Add(_recPropQlBox);
            Controls.Add(TIT_D);
            Controls.Add(_recPropDuBox);
            Controls.Add(TIT_RECDURATION);
            Controls.Add(TIT_H);
            Controls.Add(TIT_W);
            Controls.Add(_recScopeHBox);
            Controls.Add(_recScopeWBox);
            Controls.Add(TIT_T);
            Controls.Add(TIT_L);
            Controls.Add(_recScopeTBox);
            Controls.Add(_recScopeLBox);
            Controls.Add(TIT_SCOPE);
            Controls.Add(TIT_REC);
            Controls.Add(TIT_ACTCONF);
            Controls.Add(label1);
            Controls.Add(_rfsWaitTImeBox);
            Controls.Add(TIT_E2J);
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
            Controls.Add(_testResSavePathBox);
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
        private TextBox _testResSavePathBox;
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
        private Label TIT_E2J;
        private Label label1;
        private TextBox _rfsWaitTImeBox;
        private Label TIT_ACTCONF;
        private Label TIT_REC;
        private Label TIT_SCOPE;
        private TextBox _recScopeLBox;
        private TextBox _recScopeTBox;
        private Label TIT_L;
        private Label TIT_T;
        private Label TIT_H;
        private Label TIT_W;
        private TextBox _recScopeHBox;
        private TextBox _recScopeWBox;
        private Label TIT_RECDURATION;
        private TextBox _recPropDuBox;
        private Label TIT_D;
        private Label TIT_Q;
        private TextBox _recPropQlBox;
    }
}