namespace SkLockApiTest
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
            this.btnSetEdition = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tbnGetLock = new System.Windows.Forms.Button();
            this.textBoxShow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnLock1 = new System.Windows.Forms.RadioButton();
            this.rbtnLock2 = new System.Windows.Forms.RadioButton();
            this.rbtnLed1 = new System.Windows.Forms.RadioButton();
            this.rbtnLed2 = new System.Windows.Forms.RadioButton();
            this.rbtnLed3 = new System.Windows.Forms.RadioButton();
            this.rbtnLed4 = new System.Windows.Forms.RadioButton();
            this.btnSetLock = new System.Windows.Forms.Button();
            this.btnSetLed = new System.Windows.Forms.Button();
            this.btnSetAddr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.rbtnON = new System.Windows.Forms.RadioButton();
            this.rbtnOFF = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSetEdition
            // 
            this.btnSetEdition.Location = new System.Drawing.Point(473, 204);
            this.btnSetEdition.Name = "btnSetEdition";
            this.btnSetEdition.Size = new System.Drawing.Size(157, 57);
            this.btnSetEdition.TabIndex = 0;
            this.btnSetEdition.Text = "获取设备版本信息";
            this.btnSetEdition.UseVisualStyleBackColor = true;
            this.btnSetEdition.Click += new System.EventHandler(this.btnGetEdition_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(541, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "1";
            // 
            // tbnGetLock
            // 
            this.tbnGetLock.Location = new System.Drawing.Point(636, 204);
            this.tbnGetLock.Name = "tbnGetLock";
            this.tbnGetLock.Size = new System.Drawing.Size(157, 57);
            this.tbnGetLock.TabIndex = 2;
            this.tbnGetLock.Text = "查询电磁锁状态";
            this.tbnGetLock.UseVisualStyleBackColor = true;
            this.tbnGetLock.Click += new System.EventHandler(this.btnGetLock_Click);
            // 
            // textBoxShow
            // 
            this.textBoxShow.Location = new System.Drawing.Point(12, 12);
            this.textBoxShow.Multiline = true;
            this.textBoxShow.Name = "textBoxShow";
            this.textBoxShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxShow.Size = new System.Drawing.Size(440, 362);
            this.textBoxShow.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "设备源地址：";
            // 
            // rbtnLock1
            // 
            this.rbtnLock1.AutoSize = true;
            this.rbtnLock1.Location = new System.Drawing.Point(15, 12);
            this.rbtnLock1.Name = "rbtnLock1";
            this.rbtnLock1.Size = new System.Drawing.Size(53, 16);
            this.rbtnLock1.TabIndex = 5;
            this.rbtnLock1.TabStop = true;
            this.rbtnLock1.Text = "Lock1";
            this.rbtnLock1.UseVisualStyleBackColor = true;
            // 
            // rbtnLock2
            // 
            this.rbtnLock2.AutoSize = true;
            this.rbtnLock2.Location = new System.Drawing.Point(100, 12);
            this.rbtnLock2.Name = "rbtnLock2";
            this.rbtnLock2.Size = new System.Drawing.Size(53, 16);
            this.rbtnLock2.TabIndex = 6;
            this.rbtnLock2.TabStop = true;
            this.rbtnLock2.Text = "Lock2";
            this.rbtnLock2.UseVisualStyleBackColor = true;
            // 
            // rbtnLed1
            // 
            this.rbtnLed1.AutoSize = true;
            this.rbtnLed1.Location = new System.Drawing.Point(15, 8);
            this.rbtnLed1.Name = "rbtnLed1";
            this.rbtnLed1.Size = new System.Drawing.Size(47, 16);
            this.rbtnLed1.TabIndex = 7;
            this.rbtnLed1.TabStop = true;
            this.rbtnLed1.Text = "Led1";
            this.rbtnLed1.UseVisualStyleBackColor = true;
            // 
            // rbtnLed2
            // 
            this.rbtnLed2.AutoSize = true;
            this.rbtnLed2.Location = new System.Drawing.Point(103, 8);
            this.rbtnLed2.Name = "rbtnLed2";
            this.rbtnLed2.Size = new System.Drawing.Size(47, 16);
            this.rbtnLed2.TabIndex = 8;
            this.rbtnLed2.TabStop = true;
            this.rbtnLed2.Text = "Led2";
            this.rbtnLed2.UseVisualStyleBackColor = true;
            // 
            // rbtnLed3
            // 
            this.rbtnLed3.AutoSize = true;
            this.rbtnLed3.Location = new System.Drawing.Point(15, 31);
            this.rbtnLed3.Name = "rbtnLed3";
            this.rbtnLed3.Size = new System.Drawing.Size(47, 16);
            this.rbtnLed3.TabIndex = 9;
            this.rbtnLed3.TabStop = true;
            this.rbtnLed3.Text = "Led3";
            this.rbtnLed3.UseVisualStyleBackColor = true;
            // 
            // rbtnLed4
            // 
            this.rbtnLed4.AutoSize = true;
            this.rbtnLed4.Location = new System.Drawing.Point(103, 32);
            this.rbtnLed4.Name = "rbtnLed4";
            this.rbtnLed4.Size = new System.Drawing.Size(47, 16);
            this.rbtnLed4.TabIndex = 10;
            this.rbtnLed4.TabStop = true;
            this.rbtnLed4.Text = "Led4";
            this.rbtnLed4.UseVisualStyleBackColor = true;
            // 
            // btnSetLock
            // 
            this.btnSetLock.Location = new System.Drawing.Point(636, 278);
            this.btnSetLock.Name = "btnSetLock";
            this.btnSetLock.Size = new System.Drawing.Size(157, 57);
            this.btnSetLock.TabIndex = 12;
            this.btnSetLock.Text = "设置电磁锁状态";
            this.btnSetLock.UseVisualStyleBackColor = true;
            this.btnSetLock.Click += new System.EventHandler(this.btnSetLock_Click);
            // 
            // btnSetLed
            // 
            this.btnSetLed.Location = new System.Drawing.Point(473, 278);
            this.btnSetLed.Name = "btnSetLed";
            this.btnSetLed.Size = new System.Drawing.Size(157, 57);
            this.btnSetLed.TabIndex = 11;
            this.btnSetLed.Text = "设置LED灯状态";
            this.btnSetLed.UseVisualStyleBackColor = true;
            this.btnSetLed.Click += new System.EventHandler(this.btnSetLed_Click);
            // 
            // btnSetAddr
            // 
            this.btnSetAddr.Location = new System.Drawing.Point(636, 351);
            this.btnSetAddr.Name = "btnSetAddr";
            this.btnSetAddr.Size = new System.Drawing.Size(157, 57);
            this.btnSetAddr.TabIndex = 15;
            this.btnSetAddr.Text = "设置控制板地址";
            this.btnSetAddr.UseVisualStyleBackColor = true;
            this.btnSetAddr.Click += new System.EventHandler(this.btnSetAddr_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(634, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "目标地址：";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox2.Location = new System.Drawing.Point(705, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(80, 20);
            this.comboBox2.TabIndex = 17;
            this.comboBox2.Text = "1";
            // 
            // rbtnON
            // 
            this.rbtnON.AutoSize = true;
            this.rbtnON.Location = new System.Drawing.Point(18, 14);
            this.rbtnON.Name = "rbtnON";
            this.rbtnON.Size = new System.Drawing.Size(35, 16);
            this.rbtnON.TabIndex = 18;
            this.rbtnON.TabStop = true;
            this.rbtnON.Text = "ON";
            this.rbtnON.UseVisualStyleBackColor = true;
            // 
            // rbtnOFF
            // 
            this.rbtnOFF.AutoSize = true;
            this.rbtnOFF.Location = new System.Drawing.Point(18, 39);
            this.rbtnOFF.Name = "rbtnOFF";
            this.rbtnOFF.Size = new System.Drawing.Size(41, 16);
            this.rbtnOFF.TabIndex = 19;
            this.rbtnOFF.TabStop = true;
            this.rbtnOFF.Text = "OFF";
            this.rbtnOFF.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnON);
            this.panel1.Controls.Add(this.rbtnOFF);
            this.panel1.Location = new System.Drawing.Point(689, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(72, 68);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnLed1);
            this.panel2.Controls.Add(this.rbtnLed2);
            this.panel2.Controls.Add(this.rbtnLed3);
            this.panel2.Controls.Add(this.rbtnLed4);
            this.panel2.Location = new System.Drawing.Point(473, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(168, 65);
            this.panel2.TabIndex = 21;
            //this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbtnLock1);
            this.panel3.Controls.Add(this.rbtnLock2);
            this.panel3.Location = new System.Drawing.Point(473, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(168, 36);
            this.panel3.TabIndex = 22;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(357, 384);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 54);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSetAddr);
            this.Controls.Add(this.btnSetLock);
            this.Controls.Add(this.btnSetLed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxShow);
            this.Controls.Add(this.tbnGetLock);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSetEdition);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetEdition;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button tbnGetLock;
        private System.Windows.Forms.TextBox textBoxShow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnLock1;
        private System.Windows.Forms.RadioButton rbtnLock2;
        private System.Windows.Forms.RadioButton rbtnLed1;
        private System.Windows.Forms.RadioButton rbtnLed2;
        private System.Windows.Forms.RadioButton rbtnLed3;
        private System.Windows.Forms.RadioButton rbtnLed4;
        private System.Windows.Forms.Button btnSetLock;
        private System.Windows.Forms.Button btnSetLed;
        private System.Windows.Forms.Button btnSetAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.RadioButton rbtnON;
        private System.Windows.Forms.RadioButton rbtnOFF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClear;
    }
}

