namespace Parameter_Jerk_2018.Forms
{
    public partial class DebugChild : ChildControl
    {
        public DebugChild()
        {
            InitializeComponent();
        }
        private void Button1_Click_1(object sender, System.EventArgs e)
        {
            DisplayDebug();
        }

        public void DisplayDebug()
        {
            foreach (string oneItem in  JerkHub.Ptr2Debug. DebugLineItemsList)
            {
                DebugTextBox.AppendText(oneItem);
            }

            // ptr2FormObj.DebugTextBox.Text = debugTextToDate
            DebugTextBox.Select();
            DebugTextBox.Refresh();
        }

        protected override void DisplayTriggered()
        {
        }
    }
}
