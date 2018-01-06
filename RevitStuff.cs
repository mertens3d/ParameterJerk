using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Parameter_Jerk_2018
{
    public class RevitStuff
    {
        #region Properties

        public List<FamilyParameter> AllParametersFromFamilyMan
        {
            get
            {
                List<FamilyParameter> toReturn = new List<FamilyParameter>();

                foreach (FamilyParameter familyParameter in FamilyManager.Parameters)
                {
                    toReturn.Add(familyParameter);
                }


                return toReturn;
            }
        }

        public ExternalCommandData CommandData { get; set; }

        public Document Doc
        {
            get { return CommandData.Application.ActiveUIDocument.Document; }
            set { MessageBox.Show("need to handle this"); }
        }

        public FamilyManager FamilyManager
        {
            get { return Doc.FamilyManager; }
        }

        public UIApplication Ptr2UiApp
        {
            get { return CommandData.Application; }
        }

        public string RevitVersionNumberStr
        {
            get { return Doc.Application.VersionNumber; }
        }

        public DefinitionFile SharedParameterFile
        {
            get { return Doc.Application.OpenSharedParameterFile(); }
        }

        #endregion

        #region Methods

        public RevitStuff(ExternalCommandData commandData)
        {
            this.CommandData = commandData;
        }

        public Transaction NewTransaction(string name)
        {
            Transaction toReturn = new Autodesk.Revit.DB.Transaction(Doc);
            toReturn.SetName(name);
            return toReturn;
        }

        #endregion
    }
}