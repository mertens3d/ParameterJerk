using System;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace Parameter_Jerk_2018
{
    public class ClassOneParamAssociation : TypicalDataHolder
    {
        #region Fields

        private readonly Autodesk.Revit.DB.Parameter _paramObj = null;

        private readonly string _paramName = null;

        private readonly string _parameterGroup = null;

        private BuiltInParameterGroup _groupParameterUnderEnum = BuiltInParameterGroup.PG_GRAPHICS;

        private bool _isInstance = true;

        private string _comment = "";


        public DefinitionGroup DefinitionGroupObj;

        public string DataCategoryFromFileDef = null;
        private string _groupParameterUnderEnumAsString;
        private ExternalDefinition _thisExternalDefinition;

        #endregion

        #region Properties

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                JerkHub.FlagChangesToSupplemental();
            }
        }


        public string GroupParameterUnder
        {
            get { return _groupParameterUnderEnum.ToString(); }
            set { MessageBox.Show("from groupParameterUnder"); }
        }

        public string GroupParameterUnderAsLabelStr
        {
            get
            {
                //  JerkHub.Ptr2Debug.addToDebug("s) aaa")
                return Autodesk.Revit.DB.LabelUtils.GetLabelFor(_groupParameterUnderEnum).ToString();
                //  Return _groupParameterUnderLabel
            }
            set
            {
                // from here we need to figure out what the parameter is that the string represents
                JerkHub.Ptr2Debug.AddToDebug(JerkHub.ParameterGroupParameterUnderManagerListObj.LabelToParameterEnum(value).ToString());
                _groupParameterUnderEnum = JerkHub.ParameterGroupParameterUnderManagerListObj.LabelToParameterEnum(value);
                JerkHub.FlagChangesToSupplemental();
            }
        }

        public Guid GuidFromSharedParametersFile { get; set; }

        public bool IsInstance
        {
            get { return _isInstance; }
            set
            {
                _isInstance = value;
                JerkHub.FlagChangesToSupplemental();
            }
        }

        public string ParameterGroup
        {
            get { return _parameterGroup; }
            set { }
        }

        public string ThisParameterName
        {
            get { return _paramName; }
            set { }
        }

        #endregion

        #region Methods

        public ClassOneParamAssociation(ExternalDefinition externDef, ParameterJerkerHubCentral jerkerHub) : base(jerkerHub)
        {
            this.JerkHub = jerkerHub;
            _thisExternalDefinition = externDef;
            _paramName = externDef.Name;
            _parameterGroup = externDef.OwnerGroup.Name;
            _groupParameterUnderEnumAsString = Autodesk.Revit.DB.LabelUtils.GetLabelFor(BuiltInParameterGroup.PG_ANALYSIS_RESULTS);
            //  ptr2TargetDoc = doc
        }

        // Private Function findsketchplane(ByVal doc As Document, ByVal normal As XYZ) As SketchPlane
        //     Dim result As SketchPlane = Nothing
        //     'Dim a As New List(Of Element)()
        //     'Dim n As Integer ' = ptr2TargetDoc.get_elements(gettype(sketchplane), a)
        //     Dim list = New FilteredElementCollector(ptr2TargetDoc).OfClass(GetType(SketchPlane))
        //     'groupUnderSelectedIndexChanged = New StandardValuesCollection(List.ToElementIds().ToList())
        //     'ptr2TargetDoc.element(GetType(sketchplane), a)
        //     ''(gettype(sketchplane), a)
        //     'Dim sketchplanetype As type = GetType(sketchplane)
        //     'ptr2TargetDoc.getelements()
        //     'n = GetType(sketchplane)()
        //     For Each e As SketchPlane In list
        //         If e.Plane.Normal.IsAlmostEqualTo(normal) Then
        //             result = e
        //             Exit For
        //         End If
        //     Next
        //     Return result
        // End Function
        public void addSupplementData(BuiltInParameterGroup groupUnderEnum, bool isInstance, string comment)
        {
            this._groupParameterUnderEnum = groupUnderEnum;
            // _groupParameterUnderLabel = Autodesk.Revit.DB.LabelUtils.GetLabelFor(_groupParameterUnderEnum).ToString()
            this.IsInstance = isInstance;
            this._comment = comment;
        }

        public void AnalyzeMe()
        {
            GuidFromSharedParametersFile = _paramObj.GUID;
            // dataCategoryFromFileDef = _paramObj.
        }

        public bool createSharedParameter(bool replaceExisting, Autodesk.Revit.DB.Document targetDoc)
        {
            // we should not be able to get here unless the stage is not set up correctly
            // we need to check 
            // 1) does the parameter need to be created
            // 2) if it is aleady created, do they need to manually delete it and create anew?
            FamilyParameter existingParameter = this.DoesParameterExistInFile(_paramName, targetDoc);
            bool isSuccessful = false;
            string failReason = "";
            bool okToProceed = true;
            if (!(existingParameter == null))
            {
                JerkHub.Ptr2Debug.AddToDebug("Matching Existing - what is the user option?");
                if (replaceExisting)
                {
                    JerkHub.Ptr2Debug.AddToDebug("User Chooses to delete matching existing.");
                    this.deleteExistingParameter(existingParameter, targetDoc);
                    // -------
                    JerkHub.Ptr2Debug.AddToDebug("Testing for matching parameter again, to make sure we successfully deleted it.");
                    existingParameter = this.DoesParameterExistInFile(_paramName, targetDoc);
                    if ((existingParameter == null))
                    {
                        okToProceed = true;
                    }
                    else
                    {
                        JerkHub.Ptr2Debug.AddToDebug("Deleting existing parameter failed. This import fails.");
                        isSuccessful = false;
                        okToProceed = false;
                    }
                }
                else
                {
                    // do nothing
                    JerkHub.Ptr2Debug.AddToDebug("User DOES NOT Choose to delete matching existing. This import fails.");
                    MessageBox.Show("parameter not added because it already exists in the file and you have not elected to overwrite it");
                    isSuccessful = false;
                    failReason = "Parameter exist, no permission given to overwrite";
                    okToProceed = false;
                }
            }

            if (okToProceed)
            {
                // --- we are guaranteed not to have a matching existing parameter here
                this.importOneParameter(_paramName, targetDoc);
                JerkHub.Ptr2Debug.AddToDebug("Post import, test if the parameter exists in the file...it should");
                existingParameter = this.DoesParameterExistInFile(_paramName, targetDoc);
                if ((existingParameter == null))
                {
                    isSuccessful = false;
                    failReason = "Unable to add parameter";
                    JerkHub.Ptr2Debug.AddToDebug("Import failed");
                }
                else
                {
                    JerkHub.Ptr2Debug.AddToDebug("Import successful");
                    isSuccessful = true;
                }
            }

            ClassOneImportResult thisResult = new ClassOneImportResult();
            thisResult.ParameterName = _paramName;
            thisResult.fileNameLong = targetDoc.PathName;
            // but what if we were not able to delete the existing parameter
            thisResult.ResultSuccessful = isSuccessful;
            thisResult.ResultLong = failReason;
            JerkHub.AddToResults(thisResult);
            return isSuccessful;
        }

        // Private Sub bindSharedParameterToFile()
        //     Dim userResponse As MessageBox.ShowResult
        //     userResponse = MessageBox.Show("Create the Shared Parameter " & vbCrLf & vbTab & thisParameterName & vbCrLf & "?", MessageBox.ShowStyle.YesNo)
        //     If userResponse = MessageBox.ShowResult.Yes Then
        //         'first we need to make sure the shared parameters file is setup correctly
        //         'If ptr2SharedParametersFile.checkStageForSetup() Then
        //         Dim docTransaction As New Autodesk.Revit.DB.Transaction(ptr2TargetDoc)
        //         docTransaction.SetName("mertens3d.com - parameterJerk - Create Shared Parameter")
        //         docTransaction.Start()
        //         'If Not ptr2SharedParametersFile.doesParameterAlreadyExistInGroup(thisParameterName) Then
        //         '    ptr2SharedParametersFile.addParameterToGroup(thisParameterName)
        //         'End If
        //         'now we need to add to the file
        //         bindParameterToFile()
        //         docTransaction.Commit()
        //         'Else
        //         '    MessageBox.Show("Canceled - Create New Parameter")
        //         'End If
        //     End If
        // End Sub
        // Private Sub createNONSharedParameterInFile()
        //     Dim docTransaction As New Autodesk.Revit.DB.Transaction(ptr2TargetDoc)
        //     docTransaction.SetName("mertens3d.com - parameterJerk - Create Shared Parameter")
        //     docTransaction.Start()
        //     'now we need to add to the file
        //     'bindParameterToFile()
        //     'we want it in the project, so bind to a category
        //     Dim cats As CategorySet = ptr2TargetDoc.Application.Create.NewCategorySet
        //     cats.Insert(ptr2TargetDoc.Settings.Categories.Item(BuiltInCategory.OST_ProjectInformation))
        //     'create a binding - instance or type
        //     Dim bind As InstanceBinding = ptr2TargetDoc.Application.Create.NewInstanceBinding(cats)
        //     ptr2TargetDoc.ParameterBindings.Insert(sharedParameterFileDef, bind, BuiltInParameterGroup.PG_TEXT)
        //     docTransaction.Commit()
        // End Sub
        // Private Sub bindParameterToFile()
        //     MessageBox.Show("bindParameterToFile")
        //     Dim m_Manager As FamilyManager = Nothing
        //     m_Manager = ptr2TargetDoc.FamilyManager
        //     Try
        //         MessageBox.Show("_thisExternalDefinition: " & _thisExternalDefinition.ToString())
        //         m_Manager.AddParameter(_thisExternalDefinition, _parameterGroup, True)
        //     Catch ex As Exception
        //         MessageBox.Show(ex.ToString())
        //     End Try
        // End Sub
        private void deleteExistingParameter(FamilyParameter paramToDelete, Autodesk.Revit.DB.Document targetDoc)
        {
            FamilyManager mgr = targetDoc.FamilyManager;
            JerkHub.Ptr2Debug.AddToDebug(("Deleting existing parameter: " + paramToDelete.Definition.Name));
            Autodesk.Revit.DB.Transaction docTransaction = new Autodesk.Revit.DB.Transaction(targetDoc);
            docTransaction.SetName("delete existing parameter");
            try
            {
                docTransaction.Start();
                mgr.RemoveParameter(paramToDelete);
                docTransaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private FamilyParameter DoesParameterExistInFile(string parameterNameStr, Autodesk.Revit.DB.Document targetDoc)
        {
            FamilyManager mgr = null;
            mgr = targetDoc.FamilyManager;
            // Catch ex As Exception
            // End Try
            JerkHub.Ptr2Debug.AddToDebug(("Testing if Parameter exists : " + parameterNameStr));
            foreach (FamilyParameter oneParameter in mgr.Parameters)
            {
                if ((oneParameter.Definition.Name.ToLower() == parameterNameStr.ToLower()))
                {
                    JerkHub.Ptr2Debug.AddToDebug(("Result : " + true.ToString()));
                    return oneParameter;
                }
            }

            JerkHub.Ptr2Debug.AddToDebug(("Result : " + false.ToString()));
            return null;
        }

        private void importOneParameter(string requestedParameterName, Autodesk.Revit.DB.Document targetDoc)
        {
            DefinitionFile m_sharedParamFile;
            // = ptr2TargetDoc.Application.OpenSharedParameterFile
            FamilyManager m_Manager = targetDoc.FamilyManager;
            // ptr2TargetDoc.Application.SharedParametersFilename = p_fileName
            m_sharedParamFile = targetDoc.Application.OpenSharedParameterFile();
            foreach (DefinitionGroup Group in m_sharedParamFile.Groups)
            {
                foreach (ExternalDefinition oneExternalDef in Group.Definitions)
                {
                    if ((oneExternalDef.Name.ToLower() == requestedParameterName.ToLower()))
                    {
                        Autodesk.Revit.DB.Transaction docTransaction = new Autodesk.Revit.DB.Transaction(targetDoc);
                        docTransaction.SetName("mertens3d.com - parameterJerk - Create Shared Parameter");
                        try
                        {
                            docTransaction.Start();
                            // m_Manager.AddParameter(oneExternalDef, oneExternalDef.ParameterGroup, True)
                            // see http://spiderinnet.typepad.com/blog/2011/04/parameter-of-revit-api-15-set-familyparameter.html
                            FamilyParameter returnedParameter = m_Manager.AddParameter(oneExternalDef, _groupParameterUnderEnum, _isInstance);
                            docTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
        }

        #endregion
    }
}