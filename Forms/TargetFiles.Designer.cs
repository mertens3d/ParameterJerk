namespace Parameter_Jerk_2018.Forms
{
    partial class TargetFiles
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label1 = new System.Windows.Forms.Label();
            this.ListBoxTargetFiles = new System.Windows.Forms.ListBox();
            this.ButtonSelectFiles = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(13, 120);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(68, 13);
            this.Label1.TabIndex = 23;
            this.Label1.Text = "Target File(s)";
            // 
            // ListBoxTargetFiles
            // 
            this.ListBoxTargetFiles.Enabled = false;
            this.ListBoxTargetFiles.FormattingEnabled = true;
            this.ListBoxTargetFiles.HorizontalScrollbar = true;
            this.ListBoxTargetFiles.Location = new System.Drawing.Point(16, 145);
            this.ListBoxTargetFiles.Name = "ListBoxTargetFiles";
            this.ListBoxTargetFiles.Size = new System.Drawing.Size(844, 160);
            this.ListBoxTargetFiles.TabIndex = 22;
            // 
            // ButtonSelectFiles
            // 
            this.ButtonSelectFiles.Enabled = false;
            this.ButtonSelectFiles.Location = new System.Drawing.Point(197, 20);
            this.ButtonSelectFiles.Name = "ButtonSelectFiles";
            this.ButtonSelectFiles.Size = new System.Drawing.Size(125, 34);
            this.ButtonSelectFiles.TabIndex = 21;
            this.ButtonSelectFiles.Text = "Select Files";
            this.ButtonSelectFiles.UseVisualStyleBackColor = true;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.RadioButton2);
            this.Panel1.Controls.Add(this.RadioButton1);
            this.Panel1.Location = new System.Drawing.Point(16, 11);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(163, 58);
            this.Panel1.TabIndex = 20;
            // 
            // RadioButton2
            // 
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(12, 32);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(120, 17);
            this.RadioButton2.TabIndex = 15;
            this.RadioButton2.Text = "Apply to Select Files";
            this.RadioButton2.UseVisualStyleBackColor = true;
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            this.RadioButton1.Location = new System.Drawing.Point(12, 9);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(115, 17);
            this.RadioButton1.TabIndex = 14;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "Apply to Active File";
            this.RadioButton1.UseVisualStyleBackColor = true;
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // TargetFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ListBoxTargetFiles);
            this.Controls.Add(this.ButtonSelectFiles);
            this.Controls.Add(this.Panel1);
            this.Name = "TargetFiles";
            this.Size = new System.Drawing.Size(1156, 598);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox ListBoxTargetFiles;
        internal System.Windows.Forms.Button ButtonSelectFiles;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.RadioButton RadioButton2;
        internal System.Windows.Forms.RadioButton RadioButton1;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
    }
}
