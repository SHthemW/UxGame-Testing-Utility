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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            TIP_PROG = new Label();
            TIP = new Label();
            _okBtn = new Button();
            SuspendLayout();
            // 
            // TIP_DATASRC
            // 
            TIP_DATASRC.AutoSize = true;
            TIP_DATASRC.Location = new Point(23, 26);
            TIP_DATASRC.Name = "TIP_DATASRC";
            TIP_DATASRC.Size = new Size(71, 17);
            TIP_DATASRC.TabIndex = 0;
            TIP_DATASRC.Text = "数据源路径:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(23, 46);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(23, 102);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 23);
            textBox2.TabIndex = 3;
            // 
            // TIP_PROG
            // 
            TIP_PROG.AutoSize = true;
            TIP_PROG.Location = new Point(23, 82);
            TIP_PROG.Name = "TIP_PROG";
            TIP_PROG.Size = new Size(83, 17);
            TIP_PROG.TabIndex = 2;
            TIP_PROG.Text = "部署程序路径:";
            // 
            // TIP
            // 
            TIP.AutoSize = true;
            TIP.ForeColor = SystemColors.ControlDark;
            TIP.Location = new Point(62, 153);
            TIP.Name = "TIP";
            TIP.Size = new Size(128, 17);
            TIP.TabIndex = 4;
            TIP.Text = "路径请落实到具体文件";
            // 
            // _okBtn
            // 
            _okBtn.Location = new Point(89, 196);
            _okBtn.Name = "_okBtn";
            _okBtn.Size = new Size(75, 23);
            _okBtn.TabIndex = 5;
            _okBtn.Text = "确定";
            _okBtn.UseVisualStyleBackColor = true;
            // 
            // ConfigWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(255, 247);
            Controls.Add(_okBtn);
            Controls.Add(TIP);
            Controls.Add(textBox2);
            Controls.Add(TIP_PROG);
            Controls.Add(textBox1);
            Controls.Add(TIP_DATASRC);
            Name = "ConfigWindow";
            Text = "配置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TIP_DATASRC;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label TIP_PROG;
        private Label TIP;
        private Button _okBtn;
    }
}