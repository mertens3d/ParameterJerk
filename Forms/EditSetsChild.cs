using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class EditSetsChild : ChildControl
    {
        #region Methods

        public EditSetsChild()
        {
            InitializeComponent();
        }

        protected override void WireUpEvents()
        {
            if (JerkHub != null)
            {
            JerkHub.EventMan.ActionSetListForShortCutsChanged -= build_FormData;
            JerkHub.EventMan.ActionSetListForShortCutsChanged += build_FormData;
                
            }

        }

        private void BtnEditSetsAddMember_Click(object sender, System.EventArgs e)
        {
            // edit sets, add selected to set
            // first we need to get the selected parameter
            // MessageBox.Show(DataGridViewEditAvailableParams.SelectedRows.Count)
            ClassOneSet activeEditSet = this.GetActiveEditSet();
            if (!(activeEditSet == null))
            {
                foreach (DataGridViewRow oRow in DataGridViewEditAvailableParams.SelectedRows)
                {
                    //   If oRow.Selected Then
                    ClassOneParamAssociation thisData = oRow.DataBoundItem as ClassOneParamAssociation;
                    // we need to know the active set
                    // and we need to know the selected parameter
                    // MessageBox.Show("adding " & thisData.thisParameterName)
                    JerkHub.AllSetsObj.addMemberToActiveSet(activeEditSet, thisData);
                    //   Exit For
                    //  End If
                    // If thisData.parameterGroup.ToLower = groupNameB.ToLower Then
                    //     oRow.Selected = isSelected
                    // End If
                }
            }

         JerkHub.Flags.MarkFileToBeSaved();
            this.RedrawEditPage();
        }

        private void BtnEditSetsRemoveMember_Click(object sender, System.EventArgs e)
        {
            // edit sets, add selected to set
            // first we need to get the selected parameter
            ClassOneSet activeEditSet = this.GetActiveEditSet();
            List<string> tempListOfNamesToRemove = new List<string>();
            if (!(activeEditSet == null))
            {
                //             MessageBox.Show(DataGridViewEditSetsAssignedParameters.SelectedRows.Count)
                foreach (DataGridViewRow oRow in DataGridViewEditSetsAssignedParameters.SelectedRows)
                {
                    ClassOneSetMember thisData = oRow.DataBoundItem as ClassOneSetMember;
                    tempListOfNamesToRemove.Add(thisData.memberName);
                    // If thisData.parameterGroup.ToLower = groupNameB.ToLower Then
                    //     oRow.Selected = isSelected
                    // End If
                }
            }

            JerkHub.AllSetsObj.RemoveMemberFromSet(activeEditSet, tempListOfNamesToRemove);
            JerkHub.Flags.MarkFileToBeSaved();
            this.RedrawEditPage();
        }

        public void build_FormData()
        {
            // ------------------------------------
             JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewSetEdit");
            this.DataGridViewSetEdit.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewSetEdit.AutoGenerateColumns = false;
            this.DataGridViewSetEdit.DataSource = JerkHub.AllSetsObj.AllSetListAMasterForEdit;
            this.DataGridViewSetEdit.ClearSelection();
            // Me.DataGridViewSetEdit.Update()
            // Me.DataGridViewSetEdit.Refresh()
            // ------------------------------------
             JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewEditAvailableParams");
            this.DataGridViewEditAvailableParams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewEditAvailableParams.AutoGenerateColumns = false;
            this.DataGridViewEditAvailableParams.DataSource = JerkHub.AllAssociationArrayList;
            this.DataGridViewEditAvailableParams.ClearSelection();
            this.DataGridViewEditAvailableParams.Refresh();
        }

        private void buildEditSetsCurrentMembers()
        {
            // this builds the list of currently selected members of the active set
            List<ClassOneSetMember> activeMembers = new List<ClassOneSetMember>();
            ClassOneSet activeSet = this.GetActiveEditSet();
            if (!(activeSet == null))
            {
                foreach (string oneMember in activeSet.setMembers)
                {
                    activeMembers.Add(new ClassOneSetMember(oneMember));
                }

                this.DataGridViewEditSetsAssignedParameters.DataSource = activeMembers;
            }
        }

        private void Button5_Click(object sender, System.EventArgs e)
        {
            JerkHub.AllSetsObj.RemoveFromList(this.GetActiveEditSet().SetName);
            JerkHub.Flags.MarkFileToBeSaved();
            this.RedrawEditPage();
        }

        private void Button6_Click(object sender, System.EventArgs e)
        {
            // get the selected row
            ClassOneSet activeSet = this.GetActiveEditSet();
            string proposedName = Microsoft.VisualBasic.Interaction.InputBox(("Original ParameterDefinitionName: " + (activeSet.SetName + ("\r\n" + "NewDog ParameterDefinitionName: "))), "Rename", activeSet.SetName);
            //   MessageBox.Show(proposedName)
            JerkHub.AllSetsObj.RenameItemInList(this.GetActiveEditSet().SetName, proposedName);
            JerkHub.Flags.MarkFileToBeSaved();
            this.RedrawEditPage();
            // get it's name
            // get the proposed name
            // make sure it doesn't already exist
            // rename it
        }

        private void ButtonAddNewSet_Click(object sender, System.EventArgs e)
        {
            string newSetName = Microsoft.VisualBasic.Interaction.InputBox("NewDog Set ParameterDefinitionName: ");
            if (!(newSetName == null))
            {
                JerkHub.AllSetsObj.AddNewSetToList(newSetName);
            }

            JerkHub.Flags.MarkFileToBeSaved();
            this.RedrawEditPage();
        }

        private void editNewSetNameSelected(object sender, System.EventArgs e)
        {
            buildEditSetsCurrentMembers();
        }

        private ClassOneSet GetActiveEditSet()
        {
            // this sub looks for the currently selected row in the edit sets

            // If returnValue Is Nothing Then
            //     MessageBox.Show("is nothing")
            // Else
            //     MessageBox.Show("not nothing: " & returnValue.ToString())
            // End If
            return (from DataGridViewRow orow in DataGridViewSetEdit.SelectedRows select orow.DataBoundItem as ClassOneSet).FirstOrDefault();
        }

        private void InializeCompPartB()
        {
            this.build_FormData();
        }

        private void RedrawEditPage()
        {
            this.buildEditSetsCurrentMembers();
            //  MessageBox.Show("before : " & JerkHub.allSetsObj.allSetListForShortCuts.Count)
            // Try
            this.DataGridViewSetEdit.DataSource = null;
            this.DataGridViewSetEdit.DataSource = JerkHub.AllSetsObj.AllSetListAMasterForEdit;
            this.DataGridViewSetEdit.Refresh();
            // --- because the front page might have been changed by making changes to the edit page

            // Catch ex As Exception
            //     MessageBox.Show(ex.ToString())
            // End Try
        }

        #endregion

      
    }
}