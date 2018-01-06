namespace Parameter_Jerk_2018.Forms
{
    partial class FirstTabControl
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
            this.components = new System.ComponentModel.Container();
            this.ContextMenuStripInstance = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FalseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortCutsChildControl1 = new Parameter_Jerk_2018.Forms.ShortCutsChildControl();
            this.firstTabCenterChildControl1 = new Parameter_Jerk_2018.Forms.FirstTabCenterChildControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.selectedParametersChlldControl1 = new Parameter_Jerk_2018.Forms.SelectedParametersChlldControl();
            this.ContextMenuStripInstance.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContextMenuStripInstance
            // 
            this.ContextMenuStripInstance.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrueToolStripMenuItem,
            this.FalseToolStripMenuItem});
            this.ContextMenuStripInstance.Name = "ContextMenuStripInstance";
            this.ContextMenuStripInstance.ShowImageMargin = false;
            this.ContextMenuStripInstance.Size = new System.Drawing.Size(176, 48);
            // 
            // TrueToolStripMenuItem
            // 
            this.TrueToolStripMenuItem.Name = "TrueToolStripMenuItem";
            this.TrueToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.TrueToolStripMenuItem.Text = "Instance (true, checked)";
            // 
            // FalseToolStripMenuItem
            // 
            this.FalseToolStripMenuItem.Name = "FalseToolStripMenuItem";
            this.FalseToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.FalseToolStripMenuItem.Text = "Type (false, unchecked)";
            // 
            // shortCutsChildControl1
            // 
            this.shortCutsChildControl1.Location = new System.Drawing.Point(3, 3);
            this.shortCutsChildControl1.Name = "shortCutsChildControl1";
            this.shortCutsChildControl1.Size = new System.Drawing.Size(264, 599);
            this.shortCutsChildControl1.TabIndex = 40;
            this.shortCutsChildControl1.Load += new System.EventHandler(this.shortCutsChildControl1_Load);
            // 
            // firstTabCenterChildControl1
            // 
            this.firstTabCenterChildControl1.Location = new System.Drawing.Point(273, 3);
            this.firstTabCenterChildControl1.Name = "firstTabCenterChildControl1";
            this.firstTabCenterChildControl1.Size = new System.Drawing.Size(705, 571);
            this.firstTabCenterChildControl1.TabIndex = 41;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.shortCutsChildControl1);
            this.flowLayoutPanel1.Controls.Add(this.firstTabCenterChildControl1);
            this.flowLayoutPanel1.Controls.Add(this.selectedParametersChlldControl1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1270, 592);
            this.flowLayoutPanel1.TabIndex = 42;
            // 
            // selectedParametersChlldControl1
            // 
            this.selectedParametersChlldControl1.Location = new System.Drawing.Point(984, 3);
            this.selectedParametersChlldControl1.Name = "selectedParametersChlldControl1";
            this.selectedParametersChlldControl1.Size = new System.Drawing.Size(279, 608);
            this.selectedParametersChlldControl1.TabIndex = 42;
            // 
            // FirstTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FirstTabControl";
            this.Size = new System.Drawing.Size(1270, 592);
            this.ContextMenuStripInstance.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStripInstance;
        internal System.Windows.Forms.ToolStripMenuItem TrueToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem FalseToolStripMenuItem;
        private ShortCutsChildControl shortCutsChildControl1;
        private FirstTabCenterChildControl firstTabCenterChildControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private SelectedParametersChlldControl selectedParametersChlldControl1;
    }
}
