namespace WindowsFormsSimulate
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_mouse = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_key = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_hkey = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_time = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "鼠标类型";
            // 
            // cbo_mouse
            // 
            this.cbo_mouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_mouse.FormattingEnabled = true;
            this.cbo_mouse.Location = new System.Drawing.Point(85, 16);
            this.cbo_mouse.Name = "cbo_mouse";
            this.cbo_mouse.Size = new System.Drawing.Size(215, 23);
            this.cbo_mouse.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "键盘类型";
            // 
            // cbo_key
            // 
            this.cbo_key.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_key.FormattingEnabled = true;
            this.cbo_key.Location = new System.Drawing.Point(85, 52);
            this.cbo_key.Name = "cbo_key";
            this.cbo_key.Size = new System.Drawing.Size(215, 23);
            this.cbo_key.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "监控按键";
            // 
            // cbo_hkey
            // 
            this.cbo_hkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_hkey.FormattingEnabled = true;
            this.cbo_hkey.Location = new System.Drawing.Point(85, 90);
            this.cbo_hkey.Name = "cbo_hkey";
            this.cbo_hkey.Size = new System.Drawing.Size(215, 23);
            this.cbo_hkey.TabIndex = 5;
            this.cbo_hkey.SelectedIndexChanged += new System.EventHandler(this.cbo_hkey_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "间隔时间";
            // 
            // cbo_time
            // 
            this.cbo_time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_time.FormattingEnabled = true;
            this.cbo_time.Location = new System.Drawing.Point(85, 127);
            this.cbo_time.Name = "cbo_time";
            this.cbo_time.Size = new System.Drawing.Size(215, 23);
            this.cbo_time.TabIndex = 7;
            this.cbo_time.SelectedIndexChanged += new System.EventHandler(this.cbo_time_SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 163);
            this.Controls.Add(this.cbo_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbo_hkey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_mouse);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模拟点击";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_mouse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_hkey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_time;
        private System.Windows.Forms.Timer timer1;
    }
}

