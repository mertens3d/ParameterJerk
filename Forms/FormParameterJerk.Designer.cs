using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    partial class FormParameterJerk : System.Windows.Forms.Form
    {

        //// Form overrides dispose to clean up the component list.
        //[System.Diagnostics.DebuggerNonUserCode()]
        //protected override void Dispose(bool disposing)
        //{
        //    try
        //    {
        //        if ((disposing && components))
        //        {
        //            IsNot;
        //            null;
        //            components.Dispose();
        //        }

        //    }
        //    finally
        //    {
        //        base.Dispose(disposing);
        //    }

        //}

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.FirstTabChildControl = new Parameter_Jerk_2018.Forms.FirstTabControl();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.TabTarget = new System.Windows.Forms.TabPage();
            this.targetFiles1 = new Parameter_Jerk_2018.Forms.TargetFiles();
            this.TabEditSets = new System.Windows.Forms.TabPage();
            this.editSetsChild = new Parameter_Jerk_2018.Forms.EditSetsChild();
            this.TabPageFirst = new System.Windows.Forms.TabPage();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.tabCurrentFile = new System.Windows.Forms.TabPage();
            this.currentFamilyChild = new Parameter_Jerk_2018.Forms.ActiveFileChildControl();
            this.TabPageDebug = new System.Windows.Forms.TabPage();
            this.debugChild = new Parameter_Jerk_2018.Forms.DebugChild();
            this.Button4 = new System.Windows.Forms.Button();
            this.bottomButtons1 = new Parameter_Jerk_2018.Forms.BottomButtons();
            this.TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.TabTarget.SuspendLayout();
            this.TabEditSets.SuspendLayout();
            this.TabPageFirst.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.tabCurrentFile.SuspendLayout();
            this.TabPageDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // FirstTabChildControl
            // 
            this.FirstTabChildControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FirstTabChildControl.Location = new System.Drawing.Point(0, 0);
            this.FirstTabChildControl.Name = "FirstTabChildControl";
            this.FirstTabChildControl.Size = new System.Drawing.Size(1432, 560);
            this.FirstTabChildControl.TabIndex = 0;
            // 
            // TabPage2
            // 
            this.TabPage2.Controls.Add(this.dataGridResults);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(1432, 560);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Log";
            this.TabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToResizeRows = false;
            this.dataGridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridResults.Location = new System.Drawing.Point(3, 3);
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.Size = new System.Drawing.Size(1426, 554);
            this.dataGridResults.TabIndex = 23;
            // 
            // TabTarget
            // 
            this.TabTarget.Controls.Add(this.targetFiles1);
            this.TabTarget.Location = new System.Drawing.Point(4, 22);
            this.TabTarget.Name = "TabTarget";
            this.TabTarget.Size = new System.Drawing.Size(1432, 560);
            this.TabTarget.TabIndex = 3;
            this.TabTarget.Text = "Target Files";
            this.TabTarget.UseVisualStyleBackColor = true;
            // 
            // targetFiles1
            // 
            this.targetFiles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetFiles1.Location = new System.Drawing.Point(0, 0);
            this.targetFiles1.Name = "targetFiles1";
            this.targetFiles1.Size = new System.Drawing.Size(1432, 560);
            this.targetFiles1.TabIndex = 0;
            // 
            // TabEditSets
            // 
            this.TabEditSets.Controls.Add(this.editSetsChild);
            this.TabEditSets.Location = new System.Drawing.Point(4, 22);
            this.TabEditSets.Name = "TabEditSets";
            this.TabEditSets.Padding = new System.Windows.Forms.Padding(3);
            this.TabEditSets.Size = new System.Drawing.Size(1432, 560);
            this.TabEditSets.TabIndex = 2;
            this.TabEditSets.Text = "Edit Sets";
            this.TabEditSets.UseVisualStyleBackColor = true;
            // 
            // editSetsChild
            // 
            this.editSetsChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editSetsChild.Location = new System.Drawing.Point(3, 3);
            this.editSetsChild.Name = "editSetsChild";
            this.editSetsChild.Size = new System.Drawing.Size(1426, 554);
            this.editSetsChild.TabIndex = 0;
            // 
            // TabPageFirst
            // 
            this.TabPageFirst.Controls.Add(this.FirstTabChildControl);
            this.TabPageFirst.Location = new System.Drawing.Point(4, 22);
            this.TabPageFirst.Margin = new System.Windows.Forms.Padding(0);
            this.TabPageFirst.Name = "TabPageFirst";
            this.TabPageFirst.Size = new System.Drawing.Size(1432, 560);
            this.TabPageFirst.TabIndex = 0;
            this.TabPageFirst.Text = "Main";
            this.TabPageFirst.UseVisualStyleBackColor = true;
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.tabCurrentFile);
            this.MainTabControl.Controls.Add(this.TabPageFirst);
            this.MainTabControl.Controls.Add(this.TabEditSets);
            this.MainTabControl.Controls.Add(this.TabTarget);
            this.MainTabControl.Controls.Add(this.TabPage2);
            this.MainTabControl.Controls.Add(this.TabPageDebug);
            this.MainTabControl.Location = new System.Drawing.Point(5, 7);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1117, 586);
            this.MainTabControl.TabIndex = 24;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            this.MainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.CurrentFileTabSelected);
            // 
            // tabCurrentFile
            // 
            this.tabCurrentFile.Controls.Add(this.currentFamilyChild);
            this.tabCurrentFile.Location = new System.Drawing.Point(4, 22);
            this.tabCurrentFile.Name = "tabCurrentFile";
            this.tabCurrentFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabCurrentFile.Size = new System.Drawing.Size(1109, 560);
            this.tabCurrentFile.TabIndex = 5;
            this.tabCurrentFile.Text = "Current File";
            this.tabCurrentFile.UseVisualStyleBackColor = true;
            // 
            // currentFamilyChild
            // 
            this.currentFamilyChild.Location = new System.Drawing.Point(0, 0);
            this.currentFamilyChild.Name = "currentFamilyChild";
            this.currentFamilyChild.Size = new System.Drawing.Size(1289, 593);
            this.currentFamilyChild.TabIndex = 0;
            this.currentFamilyChild.Load += new System.EventHandler(this.currentFamilyFile1_Load);
            // 
            // TabPageDebug
            // 
            this.TabPageDebug.Controls.Add(this.debugChild);
            this.TabPageDebug.Location = new System.Drawing.Point(4, 22);
            this.TabPageDebug.Name = "TabPageDebug";
            this.TabPageDebug.Size = new System.Drawing.Size(1432, 560);
            this.TabPageDebug.TabIndex = 4;
            this.TabPageDebug.Text = "DebugChild";
            this.TabPageDebug.UseVisualStyleBackColor = true;
            // 
            // debugChild
            // 
            this.debugChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debugChild.Location = new System.Drawing.Point(0, 0);
            this.debugChild.Name = "debugChild";
            this.debugChild.Size = new System.Drawing.Size(1432, 560);
            this.debugChild.TabIndex = 0;
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(972, 689);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(136, 23);
            this.Button4.TabIndex = 6;
            this.Button4.Text = "Feedback";
            this.Button4.UseVisualStyleBackColor = true;
            // 
            // bottomButtons1
            // 
            this.bottomButtons1.Location = new System.Drawing.Point(12, 609);
            this.bottomButtons1.Name = "bottomButtons1";
            this.bottomButtons1.Size = new System.Drawing.Size(1177, 450);
            this.bottomButtons1.TabIndex = 25;
            // 
            // FormParameterJerk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 716);
            this.Controls.Add(this.bottomButtons1);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.Button4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(980, 39);
            this.Name = "FormParameterJerk";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Parameter Jerk b";
            this.Shown += new System.EventHandler(this.NewDog);
            this.TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.TabTarget.ResumeLayout(false);
            this.TabEditSets.ResumeLayout(false);
            this.TabPageFirst.ResumeLayout(false);
            this.MainTabControl.ResumeLayout(false);
            this.tabCurrentFile.ResumeLayout(false);
            this.TabPageDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.TabPage TabPage2;

        internal System.Windows.Forms.DataGridView dataGridResults;

        internal System.Windows.Forms.TabPage TabTarget;

        internal System.Windows.Forms.TabPage TabEditSets;


        internal System.Windows.Forms.TabPage TabPageFirst;

        internal System.Windows.Forms.TabControl MainTabControl;

        internal System.Windows.Forms.TabPage TabPageDebug;

        private TabPage tabCurrentFile;
        private ActiveFileChildControl currentFamilyChild;
        private FirstTabControl FirstTabChildControl;
        private TargetFiles targetFiles1;
        private DebugChild debugChild;
        private EditSetsChild editSetsChild;
        internal Button Button4;
        private BottomButtons bottomButtons1;
    }
}