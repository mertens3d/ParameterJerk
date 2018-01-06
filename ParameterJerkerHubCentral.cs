using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Parameter_Jerk_2018.Forms;

namespace Parameter_Jerk_2018
{
    // Imports Autodesk.Revit.DB.DefinitionGroupsBaseIterator
    public sealed class ParameterJerkerHubCentral
    {
        #region Fields

        public int TotalFailCount;
        private GroupParameterUnderManager _parameterGroupParameterUnderMan;
        private OneFileAllExistingParameters _oneFileAllExistingParam;
        private EventManager _eventMan;

        #endregion

        #region Properties

        private int _currentTaskIndex { get; set; }
        public List<ClassOneParamAssociation> AllAssociationArrayList { get; set; }

        public List<ClassOneParamAssociation> AllParametersSelectedToBeInserted { get; set; }

        public List<ClassOneParamGroup> AllParamterGroupsList { get; set; }

        public List<ClassOneImportResult> AllResultsList { get; set; }

        public ClassallSetsObj AllSetsObj { get; set; }

        public EventManager EventMan
        {
            get { return _eventMan ?? (_eventMan = new EventManager()); }
        }

        // Private m_asseblyPath As String

        //  public OneFileAllExistingParameters OneFileAllExistingParameters { get; set; }
        public Flags Flags { get; set; } = new Flags();

        public OneFileAllExistingParameters OneFileAllExistingParameters
        {
            get { return _oneFileAllExistingParam ?? (_oneFileAllExistingParam = new OneFileAllExistingParameters(this)); }
        }

        public GroupParameterUnderManager ParameterGroupParameterUnderManagerListObj
        {
            get { return _parameterGroupParameterUnderMan ?? (_parameterGroupParameterUnderMan = new GroupParameterUnderManager(this)); }
        }

        public ClassDebug Ptr2Debug { get; set; }

        internal FormParameterJerk Ptr2Form { get; set; }
        public RevitStuff RevitInterface { get; set; }

        internal ClassSharedParametersFile SharedParametersFileObj { get; set; }

        public bool StageSetupstageOkForJerking { get; set; }

        internal ClassFileSupplemental SupplementalDataFileObj { get; set; }

        public int TotalSuccessfulCount { get; set; }

        public int TotalTaskCount { get; set; }

        #endregion

        #region Methods
        public string CurrentVersionNumber = "2013 v.10.02.12.b";
        public ParameterJerkerHubCentral(RevitStuff revitInterface, ClassDebug ptr2Debug)
        {
            this.RevitInterface = revitInterface;

            // , Optional overrideSharedParametersFileNameLong As String = Nothing)
            //   MessageBox.Show(overrideSharedParametersFileNameLong)
            // MessageBox.Show(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location()))
            this.Ptr2Form = new FormParameterJerk(this);
            this.Ptr2Debug = ptr2Debug;
            AllAssociationArrayList = new List<ClassOneParamAssociation>();
            AllParamterGroupsList = new List<ClassOneParamGroup>();
            AllResultsList = new List<ClassOneImportResult>();
            AllParametersSelectedToBeInserted = new List<ClassOneParamAssociation>();


            AllSetsObj = new ClassallSetsObj(this);
               Ptr2Debug.AddToDebug(CurrentVersionNumber);


            SharedParametersFileObj = new ClassSharedParametersFile(this);


            // , overrideSharedParametersFileNameLong)
            StageSetupstageOkForJerking = true;
            if ((Flags.StageOkForJerking == false))
            {
                StageSetupstageOkForJerking = false;
            }

            if (StageSetupstageOkForJerking)
            {
                this.CheckVersion();
            }

            // debugShowOptions()
        }

        public void AddOneSupplementalDataParameter(List<string> onesupplementalDataArray)
        {
            string fileParamName = "";
            string fileGroupParameterUnderEnumStr = "pg_graphics";
            bool fileIsInstance = true;
            string fileComment = "";
            BuiltInParameterGroup thisGroupParmeterUnderAsEnum = BuiltInParameterGroup.INVALID;
            try
            {
                if ((onesupplementalDataArray.Count > 0))
                {
                    fileParamName = onesupplementalDataArray[0];
                    if ((onesupplementalDataArray.Count > 1))
                    {
                        fileGroupParameterUnderEnumStr = onesupplementalDataArray[1].ToString().ToUpper();
                        if ((onesupplementalDataArray.Count > 2))
                        {
                           fileIsInstance = onesupplementalDataArray[2].Equals("todo");
                            if ((onesupplementalDataArray.Count > 3))
                            {
                                fileComment = onesupplementalDataArray[3];
                            }
                        }
                    }
                }

                // addToDebug("adding supplemental fileParamName: " & fileParamName)
                // addToDebug("adding supplemental fileGroupParameterUnderEnumStr: " & fileGroupParameterUnderEnumStr)
                // addToDebug("adding supplemental fileIsInstance: " & fileIsInstance)
                // now we need to see if we can covert a string for the group into an enum
                Enum.Parse(typeof (BuiltInParameterGroup), fileGroupParameterUnderEnumStr, true);
                // addToDebug("thisGroupParmeterUnderAsEnum: " & thisGroupParmeterUnderAsEnum.ToString())
                foreach (ClassOneParamAssociation oneParamAsso in AllAssociationArrayList)
                {
                    //  addToDebug("compare: " & oneParamAsso.thisParameterName.ToLower() & " <-> " & fileParamName.ToLower())
                    if ((oneParamAsso.ThisParameterName.ToLower() == fileParamName.ToLower()))
                    {
                        Ptr2Debug.AddToDebug("supplemental match found");
                        oneParamAsso.addSupplementData(thisGroupParmeterUnderAsEnum, fileIsInstance, fileComment);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Ptr2Debug.AddToDebug(ex.ToString());
            }
        }

        public void AddToResults(ClassOneImportResult oneResult)
        {
            _currentTaskIndex++;
            if (oneResult.ResultSuccessful)
            {
                TotalSuccessfulCount++;
            }
            else
            {
                TotalFailCount++;
            }

            oneResult.TaskCounter = (_currentTaskIndex.ToString() + (":" + TotalTaskCount.ToString()));
            AllResultsList.Add(oneResult);
            Ptr2Form.UpdateResultsData();
        }

        private void CheckVersion()
        {
            if ((RevitInterface.RevitVersionNumberStr == "2018"))
            {
            }
            else
            {
                MessageBox.Show("This build of parameterJerk is for 2013 only. Please check with mertens3d.com for an updated build");
                StageSetupstageOkForJerking = false;
            }
        }

        public void CreateAllInThisParameterGroup(string targetGroup)
        {
            Autodesk.Revit.DB.Transaction docTransaction = RevitInterface.NewTransaction("mertens3d.com - parameterJerk - Create Shared Parameter");
            try
            {
                docTransaction.Start();
                foreach (DefinitionGroup group in RevitInterface.SharedParameterFile.Groups)
                {
                    if ((group.Name.Equals(targetGroup, StringComparison.OrdinalIgnoreCase)))
                    {
                        foreach (ExternalDefinition oneExternalDef in group.Definitions)
                        {
                            // MessageBox.Show(oneExternalDef.ParameterGroup.ToString())
                            RevitInterface.FamilyManager.AddParameter(oneExternalDef, BuiltInParameterGroup.PG_GRAPHICS, true);
                            // BuiltInParameterGroup.PG_GRAPHICS
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            docTransaction.Commit();
        }

        private int customSortAllAssociationListByParameterGroup(ClassOneParamAssociation itemA, ClassOneParamAssociation itemB)
        {
            if ((itemA.ParameterGroup.ToLower() == itemB.ParameterGroup.ToLower()))
            {
                if ((String.Compare(itemA.ThisParameterName.ToLower(), itemB.ThisParameterName.ToLower(), StringComparison.Ordinal)) != 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            else if ((String.Compare(itemA.ParameterGroup.ToLower(), itemB.ParameterGroup.ToLower(), StringComparison.Ordinal)) != 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        private int customSortAllAssociationListByParameterName(ClassOneParamAssociation itemA, ClassOneParamAssociation itemB)
        {
            return (String.Compare(itemA.ThisParameterName.ToLower(), itemB.ThisParameterName.ToLower(), StringComparison.Ordinal));
        }

        private int customSortParameterGroup(ClassOneParamGroup itemA, ClassOneParamGroup itemB)
        {
            return (String.Compare(itemA.groupName.ToLower(), itemB.groupName.ToLower(), StringComparison.Ordinal));
        }

        public void FlagChangesToSupplemental()
        {
            //  ptr2Form.ButtonSaveSupplemental.BackColor = Drawing.Color.LightPink
        }

        public void InitFromFiles()
        {
            // MessageBox.Show("initFromFiles");
            this.ReadSharedParametersFile();
            SupplementalDataFileObj = new ClassFileSupplemental(this);
            Ptr2Debug.AddToDebug("Starting Sort");
            this.SortAllAssociationsList();
            Ptr2Debug.AddToDebug("Done Sorting");
        }

        public void InitializeCounts()
        {
            TotalSuccessfulCount = 0;
            TotalFailCount = 0;
        }


        public void ReadSharedParametersFile()
        {
            ClassOneParamAssociation newgroupUnderSelectedIndexChanged;
            // MessageBox.Show(m_sharedParamFile.Groups.coun
            // Dim iter As DefinitionGroupsBaseIterator
            // iter = m_sharedParamFile.Groups.ForwardIterator
            // Do While iter.MoveNext
            //     Dim myGroup = iter.Current
            // Loop
            // MessageBox.Show("here")
            foreach (DefinitionGroup myGroup in RevitInterface.SharedParameterFile.Groups)
            {
                AllParamterGroupsList.Add(new ClassOneParamGroup(myGroup.Name));
                foreach (Autodesk.Revit.DB.ExternalDefinition oneExternalDef in myGroup.Definitions)
                {
                    newgroupUnderSelectedIndexChanged = new ClassOneParamAssociation(oneExternalDef, this);
                    AllAssociationArrayList.Add(newgroupUnderSelectedIndexChanged);
                }
            }

            // '  MessageBox.Show("e) readSharedParametersFile")
        }

        public void SaveSupplementalDataFile()
        {
            // this sub writes the supplemental text data file
            // it will work by just completely rewriting the file
            try
            {
                SupplementalDataFileObj.BackupExistingFile();
                SupplementalDataFileObj.OpenDataFileForWriting();
                SupplementalDataFileObj.WriteToFileAssociationListData(AllAssociationArrayList);
                SupplementalDataFileObj.WriteToFileSetData();
                SupplementalDataFileObj.CloseDataFileForWriting();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing supplemental file. Make sure you have the necessary privileges." + Environment.NewLine + Environment.NewLine + ex.ToString());
            }
        }

        private void SortAllAssociationsList()
        {
            // allAssociationArrayList.Sort(AddressOf customSortAllAssociationListByParameterName)
            //  MessageBox.Show("sorting allAssociationArrayList")
            AllAssociationArrayList = AllAssociationArrayList
                .OrderBy(x => x.ThisParameterName)
                .ThenBy(x => x.ParameterGroup)
                .ToList();
                
            // MessageBox.Show("sorting allParamterGroupsList")
            AllParamterGroupsList = AllParamterGroupsList.OrderBy(x => x.groupName).ToList();
            // MessageBox.Show("sorting allSetsObj")
            AllSetsObj.SortList();
            // MessageBox.Show("done sort")
        }

        #endregion
    }
}