namespace Parameter_Jerk_2018.Forms
{
    partial class FirstTabCenterChildControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label6 = new System.Windows.Forms.Label();
            this.DataGridViewFromFile = new System.Windows.Forms.DataGridView();
            this.parameterGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thisParameterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isInstance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelAvailableParams = new System.Windows.Forms.Label();
            this.ContextMenuStripGroupUnder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFromFile)).BeginInit();
            this.ContextMenuStripGroupUnder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(203, 17);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(237, 13);
            this.Label6.TabIndex = 42;
            this.Label6.Text = "Right pick to edit multiple (group under, instance)";
            // 
            // DataGridViewFromFile
            // 
            this.DataGridViewFromFile.AllowUserToAddRows = false;
            this.DataGridViewFromFile.AllowUserToDeleteRows = false;
            this.DataGridViewFromFile.AllowUserToResizeRows = false;
            this.DataGridViewFromFile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFromFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewFromFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewFromFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterGroupColumn,
            this.thisParameterName,
            this.isInstance,
            this.comment});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFromFile.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridViewFromFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewFromFile.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewFromFile.Name = "DataGridViewFromFile";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFromFile.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGridViewFromFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewFromFile.Size = new System.Drawing.Size(1165, 587);
            this.DataGridViewFromFile.TabIndex = 40;
            // 
            // parameterGroupColumn
            // 
            this.parameterGroupColumn.DataPropertyName = "parameterGroup";
            this.parameterGroupColumn.HeaderText = "GroupUnder ParameterDefinitionName";
            this.parameterGroupColumn.MinimumWidth = 100;
            this.parameterGroupColumn.Name = "parameterGroupColumn";
            this.parameterGroupColumn.ReadOnly = true;
            this.parameterGroupColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.parameterGroupColumn.Width = 194;
            // 
            // thisParameterName
            // 
            this.thisParameterName.DataPropertyName = "thisParameterName";
            this.thisParameterName.FillWeight = 150F;
            this.thisParameterName.HeaderText = "Parameter ParameterDefinitionName";
            this.thisParameterName.MinimumWidth = 150;
            this.thisParameterName.Name = "thisParameterName";
            this.thisParameterName.ReadOnly = true;
            this.thisParameterName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.thisParameterName.Width = 185;
            // 
            // isInstance
            // 
            this.isInstance.DataPropertyName = "isInstance";
            this.isInstance.HeaderText = "Instance?";
            this.isInstance.MinimumWidth = 86;
            this.isInstance.Name = "isInstance";
            this.isInstance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isInstance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.isInstance.Width = 86;
            // 
            // comment
            // 
            this.comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.comment.DataPropertyName = "comment";
            this.comment.HeaderText = "Comment";
            this.comment.MinimumWidth = 200;
            this.comment.Name = "comment";
            this.comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // LabelAvailableParams
            // 
            this.LabelAvailableParams.AutoSize = true;
            this.LabelAvailableParams.Location = new System.Drawing.Point(-3, 17);
            this.LabelAvailableParams.Name = "LabelAvailableParams";
            this.LabelAvailableParams.Size = new System.Drawing.Size(106, 13);
            this.LabelAvailableParams.TabIndex = 41;
            this.LabelAvailableParams.Text = "Available Parameters";
            // 
            // ContextMenuStripGroupUnder
            // 
            this.ContextMenuStripGroupUnder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripComboBox1});
            this.ContextMenuStripGroupUnder.Name = "ContextMenuStripGroupUnder";
            this.ContextMenuStripGroupUnder.Size = new System.Drawing.Size(182, 31);
            // 
            // ToolStripComboBox1
            // 
            this.ToolStripComboBox1.Name = "ToolStripComboBox1";
            this.ToolStripComboBox1.Size = new System.Drawing.Size(121, 23);
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
            this.splitContainer1.Panel1.Controls.Add(this.LabelAvailableParams);
            this.splitContainer1.Panel1.Controls.Add(this.Label6);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DataGridViewFromFile);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1165, 622);
            this.splitContainer1.SplitterDistance = 31;
            this.splitContainer1.TabIndex = 43;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // FirstTabCenterChildControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "FirstTabCenterChildControl";
            this.Size = new System.Drawing.Size(1165, 622);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFromFile)).EndInit();
            this.ContextMenuStripGroupUnder.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DataGridView DataGridViewFromFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn parameterGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn thisParameterName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isInstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        internal System.Windows.Forms.Label LabelAvailableParams;
        internal System.Windows.Forms.ContextMenuStrip ContextMenuStripGroupUnder;
        internal System.Windows.Forms.ToolStripComboBox ToolStripComboBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
