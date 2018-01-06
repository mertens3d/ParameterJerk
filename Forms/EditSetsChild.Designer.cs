namespace Parameter_Jerk_2018.Forms
{
    partial class EditSetsChild
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
            this.Label9 = new System.Windows.Forms.Label();
            this.Button6 = new System.Windows.Forms.Button();
            this.Button5 = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.ButtonAddNewSet = new System.Windows.Forms.Button();
            this.DataGridViewEditSetsAssignedParameters = new System.Windows.Forms.DataGridView();
            this.memberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEditSetsRemoveMember = new System.Windows.Forms.Button();
            this.DataGridViewEditAvailableParams = new System.Windows.Forms.DataGridView();
            this.parameterGroupb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnEditSetsAddMember = new System.Windows.Forms.Button();
            this.DataGridViewSetEdit = new System.Windows.Forms.DataGridView();
            this.Sets = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEditSetsAssignedParameters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEditAvailableParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSetEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(298, 27);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(106, 13);
            this.Label9.TabIndex = 38;
            this.Label9.Text = "Available Parameters";
            // 
            // Button6
            // 
            this.Button6.Location = new System.Drawing.Point(181, 58);
            this.Button6.Name = "Button6";
            this.Button6.Size = new System.Drawing.Size(104, 23);
            this.Button6.TabIndex = 37;
            this.Button6.Text = "Rename";
            this.Button6.UseVisualStyleBackColor = true;
            // 
            // Button5
            // 
            this.Button5.Location = new System.Drawing.Point(103, 58);
            this.Button5.Name = "Button5";
            this.Button5.Size = new System.Drawing.Size(72, 23);
            this.Button5.TabIndex = 36;
            this.Button5.Text = "Delete";
            this.Button5.UseVisualStyleBackColor = true;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(16, 26);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(28, 13);
            this.Label8.TabIndex = 35;
            this.Label8.Text = "Sets";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(884, 21);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(106, 13);
            this.Label7.TabIndex = 34;
            this.Label7.Text = "Assigned Parameters";
            // 
            // ButtonAddNewSet
            // 
            this.ButtonAddNewSet.Location = new System.Drawing.Point(19, 58);
            this.ButtonAddNewSet.Name = "ButtonAddNewSet";
            this.ButtonAddNewSet.Size = new System.Drawing.Size(78, 23);
            this.ButtonAddNewSet.TabIndex = 33;
            this.ButtonAddNewSet.Text = "NewDog";
            this.ButtonAddNewSet.UseVisualStyleBackColor = true;
            // 
            // DataGridViewEditSetsAssignedParameters
            // 
            this.DataGridViewEditSetsAssignedParameters.AllowUserToAddRows = false;
            this.DataGridViewEditSetsAssignedParameters.AllowUserToDeleteRows = false;
            this.DataGridViewEditSetsAssignedParameters.AllowUserToResizeRows = false;
            this.DataGridViewEditSetsAssignedParameters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEditSetsAssignedParameters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.memberName});
            this.DataGridViewEditSetsAssignedParameters.Location = new System.Drawing.Point(887, 90);
            this.DataGridViewEditSetsAssignedParameters.Name = "DataGridViewEditSetsAssignedParameters";
            this.DataGridViewEditSetsAssignedParameters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewEditSetsAssignedParameters.Size = new System.Drawing.Size(294, 501);
            this.DataGridViewEditSetsAssignedParameters.TabIndex = 32;
            // 
            // memberName
            // 
            this.memberName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.memberName.DataPropertyName = "memberName";
            this.memberName.HeaderText = "Member ParameterDefinitionName";
            this.memberName.Name = "memberName";
            // 
            // BtnEditSetsRemoveMember
            // 
            this.BtnEditSetsRemoveMember.Location = new System.Drawing.Point(887, 58);
            this.BtnEditSetsRemoveMember.Name = "BtnEditSetsRemoveMember";
            this.BtnEditSetsRemoveMember.Size = new System.Drawing.Size(144, 23);
            this.BtnEditSetsRemoveMember.TabIndex = 31;
            this.BtnEditSetsRemoveMember.Text = "<-  Remove";
            this.BtnEditSetsRemoveMember.UseVisualStyleBackColor = true;
            // 
            // DataGridViewEditAvailableParams
            // 
            this.DataGridViewEditAvailableParams.AllowUserToResizeRows = false;
            this.DataGridViewEditAvailableParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewEditAvailableParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.parameterGroupb,
            this.DataGridViewTextBoxColumn2});
            this.DataGridViewEditAvailableParams.Location = new System.Drawing.Point(301, 90);
            this.DataGridViewEditAvailableParams.Name = "DataGridViewEditAvailableParams";
            this.DataGridViewEditAvailableParams.RowHeadersVisible = false;
            this.DataGridViewEditAvailableParams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewEditAvailableParams.Size = new System.Drawing.Size(567, 501);
            this.DataGridViewEditAvailableParams.TabIndex = 30;
            // 
            // parameterGroupb
            // 
            this.parameterGroupb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.parameterGroupb.DataPropertyName = "parameterGroup";
            this.parameterGroupb.HeaderText = "GroupUnder ParameterDefinitionName";
            this.parameterGroupb.Name = "parameterGroupb";
            this.parameterGroupb.Width = 194;
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewTextBoxColumn2.DataPropertyName = "thisParameterName";
            this.DataGridViewTextBoxColumn2.HeaderText = "Parameter ParameterDefinitionName";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            // 
            // BtnEditSetsAddMember
            // 
            this.BtnEditSetsAddMember.Location = new System.Drawing.Point(708, 58);
            this.BtnEditSetsAddMember.Name = "BtnEditSetsAddMember";
            this.BtnEditSetsAddMember.Size = new System.Drawing.Size(160, 23);
            this.BtnEditSetsAddMember.TabIndex = 29;
            this.BtnEditSetsAddMember.Text = "Add ->";
            this.BtnEditSetsAddMember.UseVisualStyleBackColor = true;
            // 
            // DataGridViewSetEdit
            // 
            this.DataGridViewSetEdit.AllowUserToAddRows = false;
            this.DataGridViewSetEdit.AllowUserToDeleteRows = false;
            this.DataGridViewSetEdit.AllowUserToResizeRows = false;
            this.DataGridViewSetEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewSetEdit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sets});
            this.DataGridViewSetEdit.Location = new System.Drawing.Point(19, 90);
            this.DataGridViewSetEdit.MultiSelect = false;
            this.DataGridViewSetEdit.Name = "DataGridViewSetEdit";
            this.DataGridViewSetEdit.ReadOnly = true;
            this.DataGridViewSetEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewSetEdit.Size = new System.Drawing.Size(264, 501);
            this.DataGridViewSetEdit.TabIndex = 28;
            // 
            // Sets
            // 
            this.Sets.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sets.DataPropertyName = "setName";
            this.Sets.HeaderText = "Set ParameterDefinitionName";
            this.Sets.Name = "Sets";
            this.Sets.ReadOnly = true;
            // 
            // EditSetsChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Button6);
            this.Controls.Add(this.Button5);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.ButtonAddNewSet);
            this.Controls.Add(this.DataGridViewEditSetsAssignedParameters);
            this.Controls.Add(this.BtnEditSetsRemoveMember);
            this.Controls.Add(this.DataGridViewEditAvailableParams);
            this.Controls.Add(this.BtnEditSetsAddMember);
            this.Controls.Add(this.DataGridViewSetEdit);
            this.Name = "EditSetsChild";
            this.Size = new System.Drawing.Size(1379, 700);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEditSetsAssignedParameters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewEditAvailableParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewSetEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Button Button6;
        internal System.Windows.Forms.Button Button5;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Button ButtonAddNewSet;
        internal System.Windows.Forms.DataGridView DataGridViewEditSetsAssignedParameters;
        internal System.Windows.Forms.DataGridViewTextBoxColumn memberName;
        internal System.Windows.Forms.Button BtnEditSetsRemoveMember;
        internal System.Windows.Forms.DataGridView DataGridViewEditAvailableParams;
        internal System.Windows.Forms.DataGridViewTextBoxColumn parameterGroupb;
        internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal System.Windows.Forms.Button BtnEditSetsAddMember;
        internal System.Windows.Forms.DataGridView DataGridViewSetEdit;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Sets;
    }
}
