using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameter_Jerk_2018
{
    public class ClassOneSet :TypicalDataHolder
    {

        public List<string> setMembers = new List<string>();


        public ClassOneSet( string nameOfNewSet, ParameterJerkerHubCentral jerkHub) : base(jerkHub)
        {
            this.SetName = nameOfNewSet;
        }

        public string SetName { get; set; } = null;

        public void AddParameterToMembers(string newMember)
        {
            //   MessageBox.Show("adding member" & newMember & " to " & _setName)
            // first we need to make sure it's an active parameter
            // they may have deleted it
            // or maybe we should just flag it
            if (!setMembers.Contains(newMember))
            {
                setMembers.Add(newMember);
            }

        }

        public void RemoveMemberParameter(string memberName)
        {
            //   MessageBox.Show("adding member" & newMember & " to " & _setName)
            // first we need to make sure it's an active parameter
            // they may have deleted it
            // or maybe we should just flag it
             JerkHub.Ptr2Debug.AddToDebug(("trying to delete member: " + memberName));
            if (setMembers.Contains(memberName))
            {
                 JerkHub.Ptr2Debug.AddToDebug("found it in the list");
                setMembers.Remove(memberName);
            }
            else
            {
                 JerkHub.Ptr2Debug.AddToDebug("DID NOT find it in the list");
            }

        }

        public void renameSetName(string newName)
        {
        }

        public string oneSetWriteDataForFile()
        {
            string strt = "";
            strt = (strt + ("*"
                        + (this.SetName + "\r\n")));
            foreach (string oneMember in setMembers)
            {
                // strt += "*MEMBER" & vbTab & oneMember & vbCrLf
                strt = (strt
                            + (oneMember + "\r\n"));
            }

            return strt;
        }

        public void addDataFromFile()
        {
        }
    }
}
