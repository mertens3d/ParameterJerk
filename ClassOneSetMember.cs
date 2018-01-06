using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter_Jerk_2018
{
    public class ClassOneSetMember
    {

        private string _memberName;

        public string memberName
        {
            get
            {
                return _memberName;
            }
            set
            {
                _memberName = value;
            }
        }

        public ClassOneSetMember(string memberName)
        {
            _memberName = memberName;
        }
    }
}
