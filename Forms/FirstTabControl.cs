using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class FirstTabControl : ChildControl
    {
        #region Fields

      

        #endregion

        #region Methods

        public FirstTabControl()
        {
            InitializeComponent();
        }

        protected override void WireUpEvents()
        {

            JerkHub.EventMan.ActionSetListForShortCutsChanged += build_FormData;


        }

        public override void build_FormData()
        {
            JerkHub.Ptr2Debug.AddToDebug("s) build_FormData");
            // ------------ make sure the shared parameters file exists
            // ---- if not, let them select one
            // --------------------------------- datagridviewfromfile
            JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewFromFile");
            //   JerkHub.Ptr2Debug.addToDebug("s) DataGridViewFromFile - aaaa")



               

                JerkHub.Ptr2Debug.AddToDebug("s) DataGridViewFromFile - datasource");
                // try to clear it


                // SetupGrid()
                // dataGridView1.AutoSize = True
                // Dim combo As NewDog DataGridViewComboBoxColumn()
                // combo.DataSource = [Enum].GetValues(GetType(GroupParameterUnderAsLabelStr))
                // combo.DataPropertyName = "GroupParameterUnderAsLabelStr"
                // combo.ParameterDefinitionName = "GroupParameterUnderAsLabelStr"
                // DataGridViewFromFile.Columns.Add(combo)
                // createTheDropBox()
               

                // Me.ComboBoxEditSets.DataSource = JerkHub.allParamterGroupsList
                // Me.ComboBoxEditSets.DisplayMember = "groupNameB"
                // Me.DataGridViewFromFile.AutoGenerateColumns = False
                // this is a workaround to get the column into the right spot
                // Me.DataGridViewFromFile.Columns("parameterFoundInThisFileBool").DisplayIndex = 3
                ParentFormParameterJerk.FirstTime = false;
            JerkHub.Ptr2Debug.AddToDebug("e) build_FormData");
        }


       

     

        

        private void DataGridViewFromFile_SelectionChanged(object sender, System.EventArgs e)
        {
            ParentFormParameterJerk.TriggerA();
        }

       

    
        private void DataGridViewSetShortCut_SelectionChanged(object sender, System.EventArgs e)
        {
            ClassOneSet thisData;
            JerkHub.EventMan.OnSetShortCutSelectionChanged();

           //TODO
            //foreach (DataGridViewRow oRow in ` DataGridViewSetShortCut.SelectedRows)
            //{
            //    thisData = oRow.DataBoundItem as ClassOneSet;
            //    this.ToggleSet(thisData.SetName, true);
            //}

        }

        protected override void DisplayTriggered()
        {
            build_FormData();
        }


        


     

        
        
       

     

       

        #endregion

        private void shortCutsChildControl1_Load(object sender, EventArgs e)
        {

        }
    }
}