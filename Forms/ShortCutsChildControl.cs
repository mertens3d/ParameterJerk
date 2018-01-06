using System;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class ShortCutsChildControl : ChildControl
    {
        #region Methods

        public ShortCutsChildControl()
        {
            InitializeComponent();
        }
        protected override void WireUpEvents()
        {

            JerkHub.EventMan.ActionSetListForShortCutsChanged += build_FormData;


        }
        public override void build_FormData()
        {
            // ------------------------------------
            JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewGroups");
            this.DataGridViewGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewGroups.AutoGenerateColumns = false;
            this.DataGridViewGroups.DataSource = ParentFormParameterJerk.JerkHub.AllParamterGroupsList;
            DataGridViewGroups.ClearSelection();
            this.DataGridViewGroups.Refresh();
            // ------------------------------------
            JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewSetShortCut");
            this.DataGridViewSetShortCut.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewSetShortCut.AutoGenerateColumns = false;
            this.DataGridViewSetShortCut.DataSource = ParentFormParameterJerk.JerkHub.AllSetsObj.allSetListBForShortCuts;
            this.DataGridViewSetShortCut.ClearSelection();
            this.DataGridViewSetShortCut.Refresh();
        }

        private void DataGridViewGroups_CellContentClick(object sender, EventArgs e)
        {
            ClassOneParamGroup thisData;
            foreach (DataGridViewRow oRow in DataGridViewGroups.Rows)
            {
                thisData = oRow.DataBoundItem as ClassOneParamGroup;


                JerkHub.Flags.SelectGroupName = thisData.groupName;
                JerkHub.Flags.RowSelected = oRow.Selected;

                JerkHub.EventMan.OnActionSelectGroupChanged();
            }
        }

        private void DataGridViewGroups_DataBindingComplete(object sender, System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow oRow in DataGridViewGroups.Rows)
            {
                // With oRow.Cells("ColumnCreateAllInGroup")
                //     .Value = "create all in ->"
                // End With
            }
        }

        private void RedrawEditPage()
        {
            this.DataGridViewSetShortCut.DataSource = null;
            this.DataGridViewSetShortCut.DataSource = JerkHub.AllSetsObj.allSetListBForShortCuts;
            this.DataGridViewSetShortCut.ClearSelection();
            // Me.DataGridViewSetShortCut.Update()
            this.DataGridViewSetShortCut.Refresh();
        }

        #endregion
    }
}