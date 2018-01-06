using System.Drawing;

namespace Parameter_Jerk_2018.Forms
{
    public partial class BottomButtons : ChildControl
    {
        #region Methods

        public BottomButtons()
        {
            InitializeComponent();
        }


        public void BuildSelectedParamsToInsertList()
        {
            // --- rebuild the insertlist

            if (JerkHub != null)
            {
                if ((JerkHub.AllParametersSelectedToBeInserted.Count > 0))
                {
                    ButtonDoIt.Enabled = true;
                    LabelSelectWarningA.Visible = false;
                    LabelSelectWarningB.Visible = false;
                }
                else
                {
                    ButtonDoIt.Enabled = false;
                    LabelSelectWarningA.Visible = true;
                    LabelSelectWarningB.Visible = true;
                }
            }
        }

        private void Button7_Click_2(object sender, System.EventArgs e)
        {
            this.ButtonSaveGeneric();
        }

        private void ButtonSaveGeneric()
        {
            JerkHub.SaveSupplementalDataFile();
            flagSaveSupplemental.Visible = false;
            JerkHub.Flags.FileNeedsToBeSaved = false;
        }

        private void ButtonSaveSupplemental_Click(object sender, System.EventArgs e)
        {
            this.ButtonSaveGeneric();
        }

        internal void MarkFileToBeSaved()
        {
            Color warningColor = Color.Coral;
            flagSaveSupplemental.Visible = true;
            JerkHub.Flags.FileNeedsToBeSaved = true;
        }

        #endregion
    }
}