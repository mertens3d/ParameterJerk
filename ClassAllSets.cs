using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Parameter_Jerk_2018
{
    public class ClassallSetsObj : TypicalDataHolder
    {
        #region Fields

        // this class handles all the set functions
        // each set needs to be allowed to have one to all parameters assigned to its
        public List<ClassOneSet> AllSetListAMasterForEdit;

        public List<ClassOneSet> allSetListBForShortCuts;

        #endregion

        #region Methods

        public ClassallSetsObj(ParameterJerkerHubCentral jerkHub) : base(jerkHub)
        {
            AllSetListAMasterForEdit = new List<ClassOneSet>();
            allSetListBForShortCuts = new List<ClassOneSet>();
        }

        public void addMemberToActiveSet(ClassOneSet setObj, ClassOneParamAssociation parameterObj)
        {
            setObj.AddParameterToMembers(parameterObj.ThisParameterName);
        }

        public void AddNewSetToList(string newSetName)
        {
            JerkHub.Ptr2Debug.AddToDebug(("addNewSetToList: " + newSetName));
            ClassOneSet foundSet = this.getOneSetByNameFromMaster(newSetName);
            if (((foundSet == null)
                 && this.isNameLegal(newSetName)))
            {
                ClassOneSet newSet = new ClassOneSet(newSetName, JerkHub);
                AllSetListAMasterForEdit.Add(newSet);
                // allSetListA_master_ForEdit.Sort()
                this.SortList();
                this.MakeShortSetACopyOfEditSet();
            }
        }

        public ClassOneSet getOneSetByNameFromMaster(string targetSetName)
        {
            ClassOneSet returnSet = null;
            JerkHub.Ptr2Debug.AddToDebug(("looking for existing set name: " + targetSetName));
            foreach (ClassOneSet oneSet in AllSetListAMasterForEdit)
            {
                if ((oneSet.SetName == targetSetName))
                {
                    returnSet = oneSet;
                    break;
                }
            }

            if ((returnSet == null))
            {
                JerkHub.Ptr2Debug.AddToDebug(("results: " + false.ToString()));
            }
            else
            {
                JerkHub.Ptr2Debug.AddToDebug(("results: " + true.ToString()));
            }

            return returnSet;
        }


        private bool isNameLegal(string proposedName)
        {
            bool returnValue = true;
            if ((proposedName.Length < 1))
            {
                MessageBox.Show("Set ParameterDefinitionName is too short");
                returnValue = false;
            }

            if (!Regex.IsMatch(proposedName, "^[A-Za-z0-9]"))
            {
                MessageBox.Show("Proposed name contains illegal characters, alpha numerics only[A-Z, 0-9].");
                returnValue = false;
            }

            return returnValue;
        }

        internal void MakeShortSetACopyOfEditSet()
        {
            JerkHub.Ptr2Debug.AddToDebug("s) makeShortSetACopyOfEditSet");
            allSetListBForShortCuts.Clear();
            //  JerkHub.ptr2Form.unselectAllShortCuts()
            foreach (ClassOneSet oneItem in AllSetListAMasterForEdit)
            {
                ClassOneSet copyItem = new ClassOneSet(oneItem.SetName, JerkHub);
                // = oneitem.copy
                allSetListBForShortCuts.Add(copyItem);
            }

            JerkHub.EventMan.OnSetListForShortcutsChanged();
            JerkHub.Ptr2Debug.AddToDebug("e) makeShortSetACopyOfEditSet");
        }

        // Public Function getOneSetByNameFromShortcuts(ByVal targetSetName As String) As ClassOneSet
        //     Dim returnSet As ClassOneSet = Nothing
        //     JerkHub.addToDebug("looking for existing set name (shortcuts): " & targetSetName)
        //     For Each oneSet As ClassOneSet In allSetListBForShortCuts
        //         If oneSet.setName = targetSetName Then
        //             returnSet = oneSet
        //             Exit For
        //         End If
        //     Next
        //     If returnSet Is Nothing Then
        //         JerkHub.addToDebug("results: " & False.ToString())
        //     Else
        //         JerkHub.addToDebug("results: " & True.ToString())
        //     End If
        //     Return returnSet
        // End Function
        public void RemoveFromList(string nameToRemove)
        {
            JerkHub.Ptr2Debug.AddToDebug(("removeFromList: " + nameToRemove));
            ClassOneSet foundSet = this.getOneSetByNameFromMaster(nameToRemove);
            if (!(foundSet == null))
            {
                AllSetListAMasterForEdit.Remove(foundSet);
            }

            // '------------------------------
            // foundSet = getOneSetByNameFromShortcuts(nameToRemove)
            // If Not foundSet Is Nothing Then
            //     allSetListBForShortCuts.Remove(foundSet)
            // End If
            this.MakeShortSetACopyOfEditSet();
            // all ClassOneParamAssociation must have it removed too
        }

        public void RemoveMemberFromSet(ClassOneSet setObj, List<string> memberList)
        {
            JerkHub.Ptr2Debug.AddToDebug(("removing member from this set: " + setObj.SetName));
            foreach (string oneMemberName in memberList)
            {
                setObj.RemoveMemberParameter(oneMemberName);
            }
        }

        public void RenameItemInList(string oldName, string newName)
        {
            // find the old item in the list
            // rename it?
            // what about all the parameters that have that set assigned?
            // after renaming here, the same must happen in ClassOneParamAssociation
            JerkHub.Ptr2Debug.AddToDebug(("renameItemInList: "
                                          + (oldName + (" " + newName))));
            ClassOneSet oldSet = this.getOneSetByNameFromMaster(oldName);
            ClassOneSet newNameSet = this.getOneSetByNameFromMaster(newName);
            if ((!(oldSet == null)
                 && ((newNameSet == null)
                     && this.isNameLegal(newName))))
            {
                oldSet.SetName = newName;
                this.SortList();
            }

            this.MakeShortSetACopyOfEditSet();
        }

        public void SortList()
        {
            AllSetListAMasterForEdit = AllSetListAMasterForEdit.OrderBy(x => x.SetName).ToList();
        }

        public string writeallSetsObjToFile()
        {
            string strt = "";
            foreach (ClassOneSet oneSet in AllSetListAMasterForEdit)
            {
                strt = (strt + oneSet.oneSetWriteDataForFile());
            }

            return strt;
        }

        #endregion
    }
}