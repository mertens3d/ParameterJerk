using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public class ChildControl : UserControl
    {
        #region Fields

        private FormParameterJerk _parentFormParameterJerk;

        #endregion

        #region Properties

        public bool EventsWired { get; set; }

        protected ParameterJerkerHubCentral JerkHub { get; set; }
        //public void SetJerk(ParameterJerkerHubCentral jerkHub)
        //{

        //}
        protected FormParameterJerk ParentFormParameterJerk
        {
            get
            {
                if (_parentFormParameterJerk == null)
                {
                    Control current = this.Parent;
                    // Parent as FormParameterJerk;
                    while (!(current is FormParameterJerk) && current != null)
                    {
                        current = current.Parent;
                    }

                    _parentFormParameterJerk = current as FormParameterJerk;
                }

                return _parentFormParameterJerk;
            }
        }

        #endregion

        #region Methods

        public virtual void build_FormData()
        {
        }

        public void DisplayChild(ParameterJerkerHubCentral jerkHub)
        {
            this.JerkHub = jerkHub;

            if (!EventsWired)
            {
                WireUpEvents();
            }
            DisplayTriggered();
        }

        protected virtual void DisplayTriggered()
        {
        }

        protected virtual void WireUpEvents()
        {
        }

        #endregion
    }
}