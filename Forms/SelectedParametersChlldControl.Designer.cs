namespace Parameter_Jerk_2018.Forms
{
    partial class SelectedParametersChlldControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewToInsert = new System.Windows.Forms.DataGridView();
            this.thisParameterName2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelSelectParamsToInsert = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewToInsert)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewToInsert
            // 
            this.DataGridViewToInsert.AllowUserToAddRows = false;
            this.DataGridViewToInsert.AllowUserToDeleteRows = false;
            this.DataGridViewToInsert.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewToInsert.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewToInsert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewToInsert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thisParameterName2});
            this.DataGridViewToInsert.Location = new System.Drawing.Point(16, 61);
            this.DataGridViewToInsert.Name = "DataGridViewToInsert";
            this.DataGridViewToInsert.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewToInsert.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewToInsert.RowHeadersVisible = false;
            this.DataGridViewToInsert.Size = new System.Drawing.Size(210, 503);
            this.DataGridViewToInsert.TabIndex = 39;
            // 
            // thisParameterName2
            // 
            this.thisParameterName2.DataPropertyName = "thisParameterName";
            this.thisParameterName2.HeaderText = "Parameter ParameterDefinitionName";
            this.thisParameterName2.MinimumWidth = 150;
            this.thisParameterName2.Name = "thisParameterName2";
            this.thisParameterName2.ReadOnly = true;
            // 
            // LabelSelectParamsToInsert
            // 
            this.LabelSelectParamsToInsert.AutoSize = true;
            this.LabelSelectParamsToInsert.Location = new System.Drawing.Point(44, 12);
            this.LabelSelectParamsToInsert.Name = "LabelSelectParamsToInsert";
            this.LabelSelectParamsToInsert.Size = new System.Drawing.Size(105, 13);
            this.LabelSelectParamsToInsert.TabIndex = 38;
            this.LabelSelectParamsToInsert.Text = "Selected Parameters";
            // 
            // SelectedParametersChlldControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DataGridViewToInsert);
            this.Controls.Add(this.LabelSelectParamsToInsert);
            this.Name = "SelectedParametersChlldControl";
            this.Size = new System.Drawing.Size(279, 608);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewToInsert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.DataGridView DataGridViewToInsert;
        internal System.Windows.Forms.DataGridViewTextBoxColumn thisParameterName2;
        internal System.Windows.Forms.Label LabelSelectParamsToInsert;
    }
}
