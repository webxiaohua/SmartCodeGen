namespace SmartCodeGen
{
    partial class Form_About
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
            this.label1 = new System.Windows.Forms.Label();
            this.smartButton1 = new SmartWinControls.SmartControls.Button.SmartButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "SmartCodeGen是一个.NET三层架构代码生成器!该软件旨在简化开发人员的\r\n\r\n一些简单而重复的代码书写过程，使开发人员有更多的时间则重于业务逻辑的实现" +
    "。";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // smartButton1
            // 
            this.smartButton1.ForeImage = null;
            this.smartButton1.ForeImageSize = new System.Drawing.Size(0, 0);
            this.smartButton1.ForePathAlign = SmartWinControls.Common.ButtonImageAlignment.Left;
            this.smartButton1.ForePathGetter = null;
            this.smartButton1.ForePathSize = new System.Drawing.Size(0, 0);
            this.smartButton1.Image = null;
            this.smartButton1.Location = new System.Drawing.Point(194, 159);
            this.smartButton1.Name = "smartButton1";
            this.smartButton1.Size = new System.Drawing.Size(64, 29);
            this.smartButton1.SpaceBetweenPathAndText = 0;
            this.smartButton1.TabIndex = 3;
            this.smartButton1.Text = "确定";
            this.smartButton1.UseVisualStyleBackColor = true;
            this.smartButton1.Click += new System.EventHandler(this.smartButton1_Click);
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 279);
            this.Controls.Add(this.smartButton1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconLeftMargin = 0;
            this.IconSize = new System.Drawing.Size(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_About";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于SmartCodeGen代码生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private SmartWinControls.SmartControls.Button.SmartButton smartButton1;
    }
}