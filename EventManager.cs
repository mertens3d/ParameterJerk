using System;

namespace Parameter_Jerk_2018
{
    public class EventManager
    {
        #region Methods

        protected internal virtual void OnActionSelectGroupChanged()
        {
            ActionSelectGroupChanged?.Invoke();
        }

        protected internal void OnSetListForShortcutsChanged()
        {
            ActionSetListForShortCutsChanged?.Invoke();
        }

        #endregion

        internal event Action ActionSelectGroupChanged;
        internal event Action ActionSetListForShortCutsChanged;
        internal event Action ActionSetShortCutSelectionChanged;

        public void OnSetShortCutSelectionChanged()
        {
            ActionSetShortCutSelectionChanged?.Invoke();
        }
    }
}