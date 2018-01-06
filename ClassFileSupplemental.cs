using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Parameter_Jerk_2018
{
    public class ClassFileSupplemental : TypicalDataHolder
    {
        #region Fields

        private enum DataModeDef
        {
            Parameters,

            Sets,
        }

        // this class reads and writes the supplemental data file
        // file is tab deliminated
        // first line:    parameter group    instance
        // subsequent lines:  Room Notes    pg_graphics    1
        // defaults
        // parameter group : pg_graphics
        // instance: 1

        public bool DataFileExists = false;

        public string DataFileNameLong = "";

        public string DataFilePath = "";

        private string _dataFileNameShortNoExtension = "";

        private readonly string supplementalFileNameSuffix = ".M3d.ParamJerkSupplemental";

        private System.IO.StreamWriter _objWriter;

        private ClassOneSet _currentReadset = null;

        private readonly List<string> _rawfileData;

        #endregion

        #region Methods

        public ClassFileSupplemental(ParameterJerkerHubCentral jerkHub) : base(jerkHub)
        {
            _rawfileData = new List<string>();
            this.ConstructFileName();
            if (DataFileExists)
            {
                this.ReadSupplementalDataFile();
                this.HarvestSupplementalFileData();
            }
        }

        private void AddToActiveSet(string memberName)
        {
            if (_currentReadset != null)
            {
                _currentReadset.AddParameterToMembers(memberName);
            }
            else
            {
                JerkHub.Ptr2Debug.AddToDebug(("error in data file. tried adding a member with no active set. - " + memberName));
            }
        }

        public void BackupExistingFile()
        {
            // start with a 0 name file an increment until an existing one is not found
            // then rename the existing file to that name
            bool thisBackupExists = true;
            string proposedBackupName = null;
            int currentBackupSuffix = 0;
            if (File.Exists(DataFileNameLong))
            {
                JerkHub.Ptr2Debug.AddToDebug("attempting to backup existing file");
                while (thisBackupExists)
                {
                    currentBackupSuffix++;
                    proposedBackupName = (_dataFileNameShortNoExtension
                                          + (supplementalFileNameSuffix + (".backup_"
                                                                           + (currentBackupSuffix + ".txt"))));
                    thisBackupExists = File.Exists((DataFilePath + ("\\" + proposedBackupName)));
                }

                JerkHub.Ptr2Debug.AddToDebug(("next available backup name: " + proposedBackupName));
                // now rename the existing file, if it exists
                try
                {
                    //todo    My.Computer.FileSystem.RenameFile(dataFileNameLong, proposedBackupName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error saving backup file, please try saving again. If you continue to get this error please let Gregory know. info@mertens3d.com"
                                    + Environment.NewLine
                                    + ex.ToString());
                }
            }
        }

        private void CloseCurrentSetAndAddToParent()
        {
            JerkHub.Ptr2Debug.AddToDebug("closing current set and adding to list");
            if (!(_currentReadset == null))
            {
                JerkHub.AllSetsObj.AllSetListAMasterForEdit.Add(_currentReadset);
                JerkHub.Ptr2Debug.AddToDebug(("list count: " + JerkHub.AllSetsObj.AllSetListAMasterForEdit.Count.ToString()));
            }

            JerkHub.AllSetsObj.MakeShortSetACopyOfEditSet();
            _currentReadset = null;
        }

        public void CloseDataFileForWriting()
        {
            _objWriter.Close();
            MessageBox.Show("File should have saved");
        }

        private void ConstructFileName()
        {
            // get the shared parameters file name being used
            string sharedParamFileName = JerkHub.SharedParametersFileObj.UsersSharedParameterFileNameLong;
            JerkHub.Ptr2Debug.AddToDebug(("sharedParamFileName: " + sharedParamFileName));
            DataFilePath = System.IO.Path.GetDirectoryName(sharedParamFileName);
            DataFileNameLong = System.IO.Path.GetFileNameWithoutExtension(sharedParamFileName);
            // .GetFileNameWithoutExtension(
            _dataFileNameShortNoExtension = System.IO.Path.GetFileNameWithoutExtension(sharedParamFileName);
            JerkHub.Ptr2Debug.AddToDebug(("Short ParameterDefinitionName, no extension: " + _dataFileNameShortNoExtension));
            JerkHub.Ptr2Debug.AddToDebug(("path: " + DataFilePath));
            DataFileNameLong = (DataFilePath + ("\\"
                                                + (DataFileNameLong
                                                   + (supplementalFileNameSuffix + ".txt"))));
            JerkHub.Ptr2Debug.AddToDebug(("Supplemental Data File ParameterDefinitionName: " + DataFileNameLong));
            // check if it exists
            DataFileExists = File.Exists(DataFileNameLong);
            JerkHub.Ptr2Debug.AddToDebug(("Does it exist? " + DataFileExists.ToString()));
        }

        private void CreateNewsupplementalDataFileIfNecassary()
        {
            if (!DataFileExists)
            {
            }
        }

        private void DealWithLineForParameters(string dataReadline)
        {
            List<string> dataArray;
            JerkHub.Ptr2Debug.AddToDebug(("adding line from file: " + dataReadline));
            dataArray = dataReadline.Split('\t').ToList();
            JerkHub.AddOneSupplementalDataParameter(dataArray);
        }

        private void DealWithLineForSets(string dataReadline, int lineNumber)
        {
            // should we have an internal loop here to handle all of the sets?
            // let's try
            // no because we are reading one line at a time
            // we just need to keep adding it to the current set
            // se we either are creating a new set
            // adding to a set
            // or finishing the current set
            Array thisLineArray = dataReadline.Split('\t');
            JerkHub.Ptr2Debug.AddToDebug(("adding line from file: " + dataReadline));
            // -- condition, new set
            if ((dataReadline.Substring(0, 1) == "*"))
            {
                this.StartReadingNewSet(dataReadline);
            }
            else
            {
                this.AddToActiveSet(dataReadline);
                //  JerkHub.Ptr2Debug.addToDebug("illegal line in supplemental data file.")
                //  JerkHub.Ptr2Debug.addToDebug("line #" & lineNumber & " - " & dataReadline)
                //  JerkHub.Ptr2Debug.addToDebug("flag: " & thisLineArray(0))
                // End If
            }
        }

        private void HarvestSupplementalFileData()
        {
            DataModeDef dataModeEnum = DataModeDef.Parameters;
            int currentLineNumber = 0;
            foreach (string oneLine in _rawfileData)
            {
                currentLineNumber++;
                if ((oneLine.Length > 0))
                {
                    if (!(oneLine.Substring(0, 1) == "#"))
                    {
                        if (((oneLine.ToUpper() == "[SETS]")
                             || (oneLine.ToUpper() == "[PARAMETERS]")))
                        {
                            switch (oneLine.ToUpper())
                            {
                                case "[SETS]":
                                    dataModeEnum = DataModeDef.Sets;
                                    break;
                                case "[PARAMETERS]":
                                    dataModeEnum = DataModeDef.Parameters;
                                    break;
                            }
                            JerkHub.Ptr2Debug.AddToDebug(("switching to mode: " + dataModeEnum.ToString()));
                        }
                        else
                        {
                            // now we know what mode we are in, let's parse the data
                            switch (dataModeEnum)
                            {
                                case DataModeDef.Parameters:
                                    this.DealWithLineForParameters(oneLine);
                                    break;
                                case DataModeDef.Sets:
                                    this.DealWithLineForSets(oneLine, currentLineNumber);
                                    break;
                            }
                        }

                        // sets or parameters
                    }
                    else
                    {
                        JerkHub.Ptr2Debug.AddToDebug(("ignoring comment line: " + oneLine));
                    }
                }
            }

            this.CloseCurrentSetAndAddToParent();
        }

        public void OpenDataFileForWriting()
        {
            _objWriter = new System.IO.StreamWriter(DataFileNameLong);
            this.CreateNewsupplementalDataFileIfNecassary();
            _objWriter.WriteLine("#parameter jerk");
            _objWriter.WriteLine(("#" + JerkHub.CurrentVersionNumber));
            _objWriter.WriteLine("#by mertens3d.com");
            _objWriter.WriteLine("#avoid editing this file directly, use parameter jerk");
            _objWriter.WriteLine("#--------------------------------------------------------------------------------");
            _objWriter.WriteLine("#if you edit manually, follow the following format");
            _objWriter.WriteLine("#----- for parameters ---------");
            _objWriter.WriteLine("#parameter name    [tab]parameter group   [tab]instance   [tab]Notes");
            _objWriter.WriteLine("#----- for sets ---------");
            _objWriter.WriteLine("#*Set ParameterDefinitionName   <-- set name is prefixed by an asterisk and marks the beginning of a new set");
            _objWriter.WriteLine("#Set Member   <-- parameter names following a set name become members of the preceding set name");
            _objWriter.WriteLine("#--------------------------------------------------------------------------------");
            _objWriter.WriteLine("[PARAMETERS]");
        }

        // Private Sub readSupplementalParameters()
        // End Sub
        // Private Sub readSupplementalSets()
        // End Sub
        private void ReadSupplementalDataFile()
        {
            // open the file and read in each line one by one
            // skip any lines starting with '#' because they are just our descriptors
            // # This is a Revit shared parameter file.
            // # Do not edit manually.
            // as each line is read, attach it to the corresponding param association
            JerkHub.Ptr2Debug.AddToDebug("Reading supplemental file");
            System.IO.TextReader readFileObj = new StreamReader(DataFileNameLong);
            string line;
            int currentLineNumber = 0;
            while (true)
            {
                try
                {
                    currentLineNumber++;
                    line = readFileObj.ReadLine();
                    if ((line == null))
                    {
                        break;
                    }
                    else
                    {
                        _rawfileData.Add(line.Trim());
                    }
                }
                catch (Exception ex)
                {
                    JerkHub.Ptr2Debug.AddToDebug(("error reading supplemental data file line #"
                                                  + (currentLineNumber + ("\r\n" + ex.ToString()))));
                }
            }

            JerkHub.Ptr2Debug.AddToDebug("Done reading supplemental file");
        }

        private void StartReadingNewSet(string setName)
        {
            // take out the asterisk
            setName = setName.Substring(1);
            if (!(_currentReadset == null))
            {
                this.CloseCurrentSetAndAddToParent();
            }

            _currentReadset = new ClassOneSet(setName, JerkHub);
        }

        public void WriteToFileAssociationListData(List<ClassOneParamAssociation> paramAssocList)
        {
            foreach (ClassOneParamAssociation oneParamAssoc in paramAssocList)
            {
                while (oneParamAssoc.Comment.Contains('\t'))
                {
                    oneParamAssoc.Comment = oneParamAssoc.Comment.Replace('\t', '-');
                }

                if ((oneParamAssoc.Comment == null))
                {
                    oneParamAssoc.Comment = "";
                }

                _objWriter.WriteLine((oneParamAssoc.ThisParameterName + (
                    '\t'
                    + oneParamAssoc.GroupParameterUnder
                    + '\t'
                    + oneParamAssoc.IsInstance.ToString()
                    + '\t'
                    + oneParamAssoc.Comment)));
            }
        }

        public void WriteToFileSetData()
        {
            _objWriter.WriteLine("#--------------------------------------------------------------------------------");
            _objWriter.WriteLine("[SETS]");
            _objWriter.Write(JerkHub.AllSetsObj.writeallSetsObjToFile());
        }

        #endregion
    }
}