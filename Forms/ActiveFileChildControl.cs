using System;
using System.Linq;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class ActiveFileChildControl : ChildControl
    {
        #region Methods

        public ActiveFileChildControl()
        {
            InitializeComponent();
        }

        private void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                //header was clicked

                DataGridViewColumnCollection foundColumns = dataGridView1.Columns;
                DataGridViewColumn clickedColumns = foundColumns[e.ColumnIndex];
                // MessageBox.Show("Clicked:" + clickedColumns);

                if (JerkHub.OneFileAllExistingParameters != null && JerkHub.OneFileAllExistingParameters.AllParamData.Any())
                {
                    if (clickedColumns.HeaderText.Equals(this.NameDog.HeaderText, StringComparison.OrdinalIgnoreCase))
                    {
                        JerkHub.OneFileAllExistingParameters.AllParamData = JerkHub.OneFileAllExistingParameters.AllParamData.OrderBy(x => x.ParameterDefinitionName).ToList();
                        this.dataGridView1.DataSource = JerkHub.OneFileAllExistingParameters.AllParamData;
                        this.Refresh();
                        labelParameterCount.Text = "Parameter Count : " + JerkHub.OneFileAllExistingParameters.AllParamData.Count.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Error Jerkhub is null");
                }
            }

            //  this.dataGridView1.Refresh();
        }

        private void CurrentFileTabSelected(object sender, TabControlEventArgs e)
        {
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    //header was clicked

            //    DataGridViewColumnCollection foundColumns = dataGridView1.Columns;
            //    string clickedColumns = foundColumns[e.ColumnIndex].HeaderText;
            //    MessageBox.Show("Clicked:" + clickedColumns);


            //}
        }

       
        protected override void DisplayTriggered()
        {
            if (JerkHub != null)
            {
                dataGridView1.DataSource = JerkHub.OneFileAllExistingParameters.AllParamData;
                // MessageBox.Show(JerkHub.OneFileAllExistingParameters.AllParamData.Count.ToString());


                dataGridView1.AutoGenerateColumns = false;


                DataGridViewComboBoxColumn columnToAdd = JerkHub.ParameterGroupParameterUnderManagerListObj.CreateComboBoxWithEnums();

                dataGridView1.DataError += handleError;

                dataGridView1.Columns.Add(columnToAdd);


                this.dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("Jerk is null");
            }
        }

        private void handleError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }

        #endregion

        private void ActiveFileChildControl_Load(object sender, EventArgs e)
        {

        }
    }
}