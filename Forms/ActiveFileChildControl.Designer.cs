namespace Parameter_Jerk_2018.Forms
{
    partial class ActiveFileChildControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelParameterCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ElementId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupUnder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelParameterCount);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1289, 593);
            this.splitContainer1.SplitterDistance = 53;
            this.splitContainer1.TabIndex = 6;
            // 
            // labelParameterCount
            // 
            this.labelParameterCount.AutoSize = true;
            this.labelParameterCount.Location = new System.Drawing.Point(40, 17);
            this.labelParameterCount.Name = "labelParameterCount";
            this.labelParameterCount.Size = new System.Drawing.Size(35, 13);
            this.labelParameterCount.TabIndex = 5;
            this.labelParameterCount.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ElementId,
            this.NameDog,
            this.GroupUnder});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1289, 536);
            this.dataGridView1.TabIndex = 2;
            // 
            // ElementId
            // 
            this.ElementId.DataPropertyName = "ElementId";
            this.ElementId.HeaderText = "ID";
            this.ElementId.Name = "ElementId";
            this.ElementId.ReadOnly = true;
            this.ElementId.Width = 43;
            // 
            // NameDog
            // 
            this.NameDog.DataPropertyName = "ParameterDefinitionName";
            this.NameDog.HeaderText = "Parameter Name";
            this.NameDog.Name = "NameDog";
            this.NameDog.Width = 102;
            // 
            // GroupUnder
            // 
            this.GroupUnder.DataPropertyName = "GroupUnder";
            this.GroupUnder.HeaderText = "GroupUnder Under";
            this.GroupUnder.Name = "GroupUnder";
            this.GroupUnder.Width = 112;
            // 
            // ActiveFileChildControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ActiveFileChildControl";
            this.Size = new System.Drawing.Size(1289, 593);
            this.Load += new System.EventHandler(this.ActiveFileChildControl_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelParameterCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDog;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupUnder;
    }
}
