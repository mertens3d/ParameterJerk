using System.Linq;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class SelectedParametersChlldControl : ChildControl
    {
        #region Methods

        public SelectedParametersChlldControl()
        {
            InitializeComponent();
        }
        public void BuildSelectedParamsToInsertList()
        {

            DataGridViewToInsert.AutoGenerateColumns = false;
            DataGridViewToInsert.DataSource = JerkHub.AllParametersSelectedToBeInserted.ToArray();
            DataGridViewToInsert.ClearSelection();
            LabelSelectParamsToInsert.Text = ("Selected Parameters ("
                                              + (JerkHub.AllParametersSelectedToBeInserted.Count.ToString() + ")"));
            this.DataGridViewToInsert.Refresh();


            if (JerkHub != null)
            {
                JerkHub.AllParametersSelectedToBeInserted.Clear();


                //todo add back in
                //foreach (DataGridViewRow oRow in DataGridViewFromFile.Rows)
                //{
                //    ClassOneParamAssociation thisData = (ClassOneParamAssociation) oRow.DataBoundItem;
                //    //   nameToAdd = thisData.thisParameterName.ToString
                //    if (oRow.Selected)
                //    {
                //        JerkHub.AllParametersSelectedToBeInserted.Add(thisData);
                //    }
                //}



                DataGridViewToInsert.AutoGenerateColumns = false;
                DataGridViewToInsert.DataSource = JerkHub.AllParametersSelectedToBeInserted.ToList();
                DataGridViewToInsert.ClearSelection();
                LabelSelectParamsToInsert.Text = ("Selected Parameters (" + (JerkHub.AllParametersSelectedToBeInserted.Count.ToString() + ")"));
                DataGridViewToInsert.Refresh();
            }
        }
        #endregion
    }
}