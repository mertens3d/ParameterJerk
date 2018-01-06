namespace Parameter_Jerk_2018
{
    public class Flags
    {
        #region Properties

        internal bool FileNeedsToBeSaved { get; set; }
        public bool StageOkForJerking { get; set; }
        public bool WarningIssued { get; set; }
        public string SelectGroupName { get; set; }
        public bool RowSelected { get; set; }


        public bool ReactToChangesInComboBoxGroupUnder { get; set; }
        #endregion

        #region Methods

        public void MarkFileToBeSaved()
        {
            FileNeedsToBeSaved = true;
            //todo set event
        }

        #endregion
    }
}