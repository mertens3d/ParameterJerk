using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter_Jerk_2018
{
    using Autodesk.Revit.DB;
    public class ClassOneParamGroup
    {

        private string _groupName;

        public string groupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        public ClassOneParamGroup(string groupName)
        {
            this._groupName = groupName;
        }
    }
    // ---------------- new method
    public class RawSharedParameterInfo
    {

        public static string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                m_FileName = value;
            }
        }

        private static string m_FileName;

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        private string m_Name;

        public string GUID
        {
            get
            {
                return m_GUID;
            }
            set
            {
                m_GUID = value;
            }
        }

        private string m_GUID;

        public string Owner
        {
            get
            {
                return m_Owner;
            }
            set
            {
                m_Owner = value;
            }
        }

        private string m_Owner;

        public BuiltInParameterGroup Group
        {
            get
            {
                return m_Group;
            }
            set
            {
                m_Group = value;
            }
        }

        private BuiltInParameterGroup m_Group;

        public ParameterType Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        private ParameterType m_Type;

        public bool ReadOnly
        {
            get
            {
                return m_ReadOnly;
            }
            set
            {
                m_ReadOnly = value;
            }
        }

        private bool m_ReadOnly;

        public bool Visible
        {
            get
            {
                return m_Visible;
            }
            set
            {
                m_Visible = value;
            }
        }

        private bool m_Visible;
    }
}
