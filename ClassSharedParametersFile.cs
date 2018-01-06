using System.IO;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace Parameter_Jerk_2018
{
    public class ClassSharedParametersFile : TypicalDataHolder
    {
        #region Fields

        // this is routines specific to parameters in the shared parameters file
        public DefinitionGroup SharedParameterDefinitionGroup { get; set; }
    

        public string UsersSharedParameterDirectory = null;

        public string UsersSharedParameterFileNameLong = null;

        #endregion

        #region Methods

        public ClassSharedParametersFile(ParameterJerkerHubCentral jerkHub) : base(jerkHub)
        {
            // , Optional overideSharedParametersFileNameLong As String = Nothing)
            jerkHub.Flags.StageOkForJerking = true;
            UsersSharedParameterFileNameLong = jerkHub.RevitInterface.Doc.Application.SharedParametersFilename;
            FileInfo info = new FileInfo(UsersSharedParameterFileNameLong);
            if (info != null)
            {
                UsersSharedParameterDirectory = info.DirectoryName;
            }

            // Else
            //     usersSharedParameterFileNameLong = overideSharedParametersFileNameLong
            // End If
            //    jerkHub.ptr2Form.LabelCurrentSharedParametersFile.Text = usersSharedParameterFileNameLong
            this.verifyThatShareParameterFileExists();
            JerkHub.Ptr2Debug.AddToDebug(("usersSharedParameterFileNameLong: " + UsersSharedParameterFileNameLong));
            // getParameterJerkSharedParametersFile()
            // If stageOkForSetup Then
            //     parameterJerkSharedParameterFileObj = ptr2Doc.Application.OpenSharedParameterFile
            // End If
        }

        public void AddParameterToGroup(string parameterName)
        {
            // add our parameter to the group

            ExternalDefinitionCreationOptions option = new ExternalDefinitionCreationOptions(parameterName, ParameterType.Text);
           Definition def = SharedParameterDefinitionGroup.Definitions.Create(option);
        }

        // Private Function GetFamilyParamGuid(ByVal fp As FamilyParameter, ByRef guid As String) As Boolean
        //     guid = String.Empty
        //     Dim isShared As Boolean = False
        //     Dim fi As System.Reflection.FieldInfo = fp.[GetType]().GetField("m_Parameter", System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
        //     If fi IsNot Nothing Then
        //         Dim p As Parameter = TryCast(fi.GetValue(fp), Parameter)
        //         isShared = p.IsShared
        //         If isShared AndAlso p.GUID IsNot Nothing Then
        //             guid = p.GUID.ToString()
        //         End If
        //     End If
        //     Return isShared
        // End Function
        public bool DoesParameterAlreadyExistInGroup(string parameterName)
        {
            // get all the parameters already in the group (we don't want to create ours if it's already in there)
            Definitions allDefs = SharedParameterDefinitionGroup.Definitions;
            bool foundIt = false;
            foreach (Definition oneDefintion in allDefs)
            {
                //    allDefsString += " " & oneDefintion.ParameterDefinitionName
                foundIt = (oneDefintion.Name == parameterName);
                if (foundIt)
                {
                    break;
                }
            }

            // we need to prompt the user here if the parameter does not exist, because an error has occurred
            if (!foundIt)
            {
                MessageBox.Show("Error, the parameter is not in the shared parameters file. Please do this_________");
            }

            return foundIt;
        }

        public Definition GetDefinitionFromSharedParametersFile(string parameterName)
        {
            Definitions allDefs = SharedParameterDefinitionGroup.Definitions;
            Definition foundDef = null;
            foreach (Definition oneDefintion in allDefs)
            {
                if ((oneDefintion.Name == parameterName))
                {
                    //  Dim groupUnderSelectedIndexChanged As InternalDefinition = oneDefintion
                    // Dim cat As ExternalDefinition = oneDefintion
                    foundDef = oneDefintion;
                    break;
                }
            }

            return foundDef;
        }

        private void getParameterJerkSharedParametersFile()
        {
            // get the shared parameter file
            // first save the users shared parameter file
            // MsgBox(usersSharedParameterFileNameLong)
            // now calculate where parameterJerks shared parameter file should be
            //  parameterJerkSharedParameterFileNameLong = System.Reflection.Assembly.GetExecutingAssembly().Location & "\" & parameterJerkSharedParameterFileNameShort
            // parameterJerkSharedParameterFileNameLong = ptr2Doc.Application.SharedParametersFilename
            // ---------------- check if the file exists
            // If doesSharedParametersFileExist() Then
            //     If GetAttr(parameterJerkSharedParameterFileNameLong) = vbReadOnly Then
            //         stageOkForSetup = False
            //     End If
            // Else
            // ----- if it doesn't exist, let them manually select it
            // stageOkForSetup = False
            // End If
        }

        private void manualySelectSharedParametersFile()
        {
        }

        private void verifyThatShareParameterFileExists()
        {
            JerkHub.Ptr2Debug.AddToDebug("Does file exist?: ");
            if (System.IO.File.Exists(UsersSharedParameterFileNameLong))
            {
                JerkHub.Ptr2Debug.AddToDebug(("Result: " + true.ToString()));
            }
            else
            {
                JerkHub.Ptr2Debug.AddToDebug(("Result: " + false.ToString()));
             JerkHub.Flags.   StageOkForJerking = false;
                MessageBox.Show(("Error. The location of your shared parameter file is invalid." + ("\r\n" + ("Location specified: "
                                                                                                              + (UsersSharedParameterFileNameLong + ("\r\n" + "Please fix this before proceeding."))))));
            }
        }

        #endregion
    }
}