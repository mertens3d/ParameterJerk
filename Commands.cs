using System;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Parameter_Jerk_2018
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class ParameterJerk2018 : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                RevitStuff revitStuff = new RevitStuff(commandData);
                ClassDebug  Ptr2Debug = new ClassDebug();

                ParameterJerkerHubCentral jerkHub = new ParameterJerkerHubCentral(revitStuff, Ptr2Debug);
                jerkHub.Ptr2Form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class makeToolBarForParameterJerk2018 : Autodesk.Revit.UI.IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Autodesk.Revit.UI.Result.Succeeded;
        }

        public Autodesk.Revit.UI.Result OnStartup(UIControlledApplication application)
        {
            // todo  Dim m3dMenu As New classMertens3dMenu(application)
            // todo    m3dMenu.addToMenu("parameterJerk", "Parameter Jerk 2013", "mertens3d.parameterJerk2013")
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}