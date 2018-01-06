namespace Parameter_Jerk_2018
{
    public class ClassOneImportResult
    {
        #region Fields

        private string _fileNameLong;


        private bool _resultSuccessful;

        #endregion

        #region Properties

        public string fileNameLong
        {
            get { return _fileNameLong; }
            set { _fileNameLong = value; }
        }

        public string FileNameShort
        {
            get { return System.IO.Path.GetFileName(_fileNameLong); }
            set { }
        }

        public string ParameterName { get; set; }

        public string ResultLong { get; set; }

        public bool ResultSuccessful
        {
            get { return _resultSuccessful; }
            set { _resultSuccessful = (value == true); }
        }

        public string TaskCounter { get; set; }

        #endregion
    }
}