using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class FirstTabCenterChildControl : ChildControl
    {
        #region Methods

        public FirstTabCenterChildControl()
        {
            InitializeComponent();
        }

     


        private void DataGridViewSetShortCut_SelectionChanged(object sender, System.EventArgs e)
        {
            ClassOneSet thisData;
            DataGridViewFromFile.ClearSelection();
            //TODO PUT BACK
            //foreach (DataGridViewRow oRow in DataGridViewSetShortCut.SelectedRows)
            //{
            //    thisData = oRow.DataBoundItem as ClassOneSet;
            //    this.ToggleSet(thisData.SetName, true);
            //}

        }
        public override void build_FormData()
        {
            if (this.DataGridViewFromFile != null)
            {
                this.DataGridViewFromFile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //    JerkHub.Ptr2Debug.addToDebug("s) DataGridViewFromFile - bbbb")
                DataGridViewFromFile.AutoGenerateColumns = false;

                if (ParentFormParameterJerk.FirstTime)
                {
                    DataGridViewComboBoxColumn columnToAdd = JerkHub.ParameterGroupParameterUnderManagerListObj.CreateComboBoxWithEnums();

                    columnToAdd.ContextMenuStrip = ContextMenuStripGroupUnder;

                    DataGridViewFromFile.Columns.Add(columnToAdd);

                    DataGridViewFromFile.DataSource = JerkHub.AllAssociationArrayList;
                    LabelAvailableParams.Text = ("Available Parameters (" + (JerkHub.AllAssociationArrayList.Count.ToString() + ")"));

                    JerkHub.Ptr2Debug.AddToDebug("e) DataGridViewFromFile - datasource");
                    DataGridViewFromFile.Refresh();

                    // create the column
                    JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewFromFile - add column");


                    JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewFromFile - groupParameterUnderlabelList");
                    foreach (string oneItem in ParentFormParameterJerk.JerkHub.ParameterGroupParameterUnderManagerListObj.GroupParameterUnderlabelList)
                    {
                        ToolStripComboBox1.Items.Add(oneItem);
                    }

                    JerkHub.Ptr2Debug.AddToDebug("e) DataGridViewFromFile - groupParameterUnderlabelList");
                    // ToolStripComboBox1.
                }
            }
        }

        public void BuildSelectedParamsToInsertList()
        {
            foreach (DataGridViewRow oRow in DataGridViewFromFile.Rows)
            {
                ClassOneParamAssociation thisData = oRow.DataBoundItem as ClassOneParamAssociation;
                //   nameToAdd = thisData.thisParameterName.ToString()
                if (oRow.Selected)
                {
                    JerkHub.AllParametersSelectedToBeInserted.Add(thisData);
                }
            }
        }


        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // get the first line that is selected
            ClassOneParamAssociation lastOne = null;
            foreach (DataGridViewRow oRow in DataGridViewFromFile.SelectedRows)
            {
                lastOne = oRow.DataBoundItem as ClassOneParamAssociation;
                // Exit For
            }
            //    MessageBox.Show(lastOne.ToString())
            if (!(lastOne == null))
            {
                string firstValue = lastOne.GroupParameterUnderAsLabelStr;
                // MessageBox.Show(firstValue)
                // assign that to the combobox
                int itemIndex = JerkHub.ParameterGroupParameterUnderManagerListObj.GetItemIndex(firstValue);
                // MessageBox.Show(itemIndex)
                JerkHub.Flags.ReactToChangesInComboBoxGroupUnder = false;
                ToolStripComboBox1.SelectedIndex = itemIndex;
                JerkHub.Flags.ReactToChangesInComboBoxGroupUnder = true;
            }
        }

        public void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridViewFromFile.Columns[e.ColumnIndex].Name == "isInstance")
                 || ((DataGridViewFromFile.Columns[e.ColumnIndex].Name == "GroupParameterUnderAsLabelStr")
                     || (DataGridViewFromFile.Columns[e.ColumnIndex].Name == "comment"))))
            {
                // Dim checkCell As DataGridViewCheckBoxCell = CType(DataGridViewFromFile.Rows(e.RowIndex).Cells("CheckBoxes"), DataGridViewCheckBoxCell)
                if ((DataGridViewFromFile.Columns[e.ColumnIndex].Name == "comment"))
                {
                    // check to make sure it's legal
                    DataGridViewRow thisCell = DataGridViewFromFile.Rows[e.RowIndex];
                    ClassOneParamAssociation thisData = thisCell.DataBoundItem as ClassOneParamAssociation;
                    // in case they use right pick-> clear/ cut

                    if (thisData != null)
                    {
                        if ((thisData.Comment == null))
                        {
                            thisData.Comment = "";
                        }

                        int maxLength = 128;
                        if ((thisData.Comment.Length > maxLength))
                        {
                            thisData.Comment = thisData.Comment.Substring(0, maxLength);
                            MessageBox.Show(("comment is too long. I shortened it for ya. "
                                             + (maxLength + " characters max")));
                        }

                        if (!Regex.IsMatch(thisData.Comment, "^[A-Za-z0-9]"))
                        {
                            thisData.Comment = thisData.Comment.Replace("^[A-Za-z0-9]", "");
                        }
                    }
                }

                //  DataGridViewFromFile.Invalidate()
                JerkHub.Flags.MarkFileToBeSaved();
            }
        }

        private void groupUnderSelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (JerkHub.Flags.ReactToChangesInComboBoxGroupUnder)
            {
                this.MarkAllSelectedAsGroupedUnder(ToolStripComboBox1.SelectedItem as string);
            }
        }

        private void MarkAllInstance(bool newValue)
        {
            foreach (DataGridViewRow oRow in DataGridViewFromFile.SelectedRows)
            {
                ClassOneParamAssociation thisItem = oRow.DataBoundItem as ClassOneParamAssociation;
                if (thisItem != null)
                {
                    thisItem.IsInstance = newValue;
                }
            }

            JerkHub.Flags.MarkFileToBeSaved();
            DataGridViewFromFile.Refresh();
        }

        private void MarkAllSelectedAsGroupedUnder(string newValue)
        {
            foreach (DataGridViewRow oRow in DataGridViewFromFile.SelectedRows)
            {
                ClassOneParamAssociation thisItem = oRow.DataBoundItem as ClassOneParamAssociation;
                thisItem.GroupParameterUnderAsLabelStr = newValue;
            }

            ContextMenuStripGroupUnder.Close();
            DataGridViewFromFile.Refresh();
            JerkHub.Flags.MarkFileToBeSaved();
        }

        private void markAllSelectedFalse(object sender, System.EventArgs e)
        {
            this.MarkAllInstance(false);
        }

        private void markAllSelectedTrue(object sender, System.EventArgs e)
        {
            this.MarkAllInstance(true);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
        }

        private void ToggleGroup()
        {
            // at this point we have a group name and we want to select all
            // rows in the table that have the same group name
            // If isSelected Then
            // End If
            string groupNameB = JerkHub.Flags.SelectGroupName;
            bool isSelected = JerkHub.Flags.RowSelected;


            foreach (DataGridViewRow oRow in DataGridViewFromFile.Rows)
            {
                ClassOneParamAssociation thisData = oRow.DataBoundItem as ClassOneParamAssociation;
                if (thisData != null && (thisData.ParameterGroup.Equals(groupNameB, StringComparison.OrdinalIgnoreCase)))
                {
                    oRow.Selected = isSelected;
                }
            }
        }

        private void ToggleSet(string setName, bool isSelected)
        {
            JerkHub.Ptr2Debug.AddToDebug(("toggleSet: " + (setName + (" " + isSelected))));
            // get the selected set
            ClassOneSet selectSet;
            selectSet = JerkHub.AllSetsObj.getOneSetByNameFromMaster(setName);
            // now that we have the set name, let's toggle all it's members
            foreach (DataGridViewRow oRow in DataGridViewFromFile.Rows)
            {
                ClassOneParamAssociation thisData = oRow.DataBoundItem as ClassOneParamAssociation;
                if (thisData != null && selectSet.setMembers.Contains(thisData.ThisParameterName))
                {
                    oRow.Selected = isSelected;
                }
            }
        }

        protected override void WireUpEvents()
        {
            if (JerkHub != null)
            {
                JerkHub.EventMan.ActionSelectGroupChanged -= ToggleGroup;
                JerkHub.EventMan.ActionSelectGroupChanged += ToggleGroup;


                JerkHub.EventMan.ActionSetListForShortCutsChanged -= build_FormData;
                JerkHub.EventMan.ActionSetListForShortCutsChanged += build_FormData;



                JerkHub.EventMan.ActionSetShortCutSelectionChanged -= DoAtThing;
                JerkHub.EventMan.ActionSetShortCutSelectionChanged += DoAtThing;
            }
        }

        private void DoAtThing()
        {
            DataGridViewFromFile.ClearSelection();
        }

        #endregion
    }
}