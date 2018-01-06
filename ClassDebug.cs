using System.Collections.Generic;
using System.Diagnostics;

namespace Parameter_Jerk_2018
{
    public class ClassDebug
    {
        #region Fields

        private readonly Stopwatch _stopWatchObj = new Stopwatch();

        private double _lastTimeMark;

        public List<string> DebugLineItemsList = new List<string>();

        #endregion

        #region Methods

        public ClassDebug()
        {
            _stopWatchObj.Start();
        }

        public void AddToDebug(string debugStr)
        {
            var newStr = (this.bufferText(_stopWatchObj.ElapsedMilliseconds.ToString()) + (" | "
                                                                                              + (this.bufferText((_stopWatchObj.ElapsedMilliseconds - _lastTimeMark).ToString()) + (" - "
                                                                                                                                                                                    + (debugStr + ("\r\n" + "\r\n"))))));
            DebugLineItemsList.Add(newStr);
            _lastTimeMark = _stopWatchObj.ElapsedMilliseconds;
        }

        private string bufferText(string textStr)
        {
            while ((textStr.Length < 4))
            {
                textStr = ("0" + textStr);
            }

            return textStr;
        }

        #endregion
    }
}