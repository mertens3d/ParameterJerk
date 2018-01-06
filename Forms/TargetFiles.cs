using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class TargetFiles : ChildControl
    {
        #region Fields

        private bool applyToFileList = false;

        public List<string> FilesToModify;

        #endregion

        #region Methods

        public TargetFiles()
        {
            InitializeComponent();
        }

        private void ButtonSelectFiles_Click(object sender, System.EventArgs e)
        {
            this.InitializeOpenFileDialogForRevitFiles();
            DialogResult dr = this.OpenFileDialog1.ShowDialog();
            if ((dr == System.Windows.Forms.DialogResult.OK))
            {
                //  Read the files
                foreach (string file in OpenFileDialog1.FileNames)
                {
                    //  Create a PictureBox for each file, and add that file to the FlowLayoutPanel.
                    try
                    {
                        FilesToModify.Add(file);
                    }
                    catch (SecurityException SecEx)
                    {
                        //  The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show(("Security error. Please contact your administrator for details.\\n\\n" + ("Error message: "
                                                                                                                   + (SecEx.Message + ("\\n\\n" + ("Details (send to Support):\\n\\n" + SecEx.StackTrace))))));
                    }
                    catch (Exception ex)
                    {
                        //  Could not load the image - probably permissions-related.
                        MessageBox.Show((("Error, You may not have permission to read the file, or " + "it may be corrupt.")
                                         + (Environment.NewLine
                                            + (Environment.NewLine + ("Reported error: " + ex.Message)))));
                    }
                }
            }

            this.detectIfBackupFile();
            ListBoxTargetFiles.DataSource = FilesToModify;
            ListBoxTargetFiles.Refresh();
        }

        private void detectIfBackupFile()
        {
            // Dim nameSuffix As String
            //   Dim nameLength As Integer
            List<string> nameArray;
            //  Dim returnValue As Boolean = False
            string targetSection;
            string warningStr = ("Warning: At least on of the files you selected appears to be a backup file." + ("\r\n" + ("This might lead to problems." + "\r\n")));
            int errorCount = 0;
            foreach (string onefileName in FilesToModify)
            {
                // get the last characters of the file name
                // xxxx(0.0001.rfa)
                nameArray = onefileName.Split('.').ToList();
                // now if the name array is only 2, then we are same
                if ((nameArray.Count > 2))
                {
                    // we want the second to last value
                    targetSection = nameArray[(nameArray.Count - 2)];
                    int result;
                    if (Int32.TryParse(targetSection, out result))
                    {
                        warningStr = (warningStr + ("\r\n" + onefileName));
                        JerkHub.Ptr2Debug.AddToDebug(warningStr);
                        errorCount++;
                    }
                }
            }

            if ((errorCount > 0))
            {
                MessageBox.Show(warningStr);
            }
        }

        private void ImportAllSelectedParamsToFileList()
        {
            foreach (string oneFile in FilesToModify)
            {
                JerkHub.Ptr2Debug.AddToDebug(("attempting to open: " + oneFile));
                try
                {
                    // ptr2UiApp.Application.SharedParametersFilename = oneFile
                    // m_SharedParamFile = m_App.Application.OpenSharedParameterFile
                    // open the file (this happens in the background, so users will not see it
                    var m_doc = JerkHub.RevitInterface.Ptr2UiApp.Application.OpenDocumentFile(oneFile);
                    // modify it
                    // make sure it's the active file
                    ImportAllSelectedParamsToTargetFile(m_doc);
                    // save it
                    m_doc.Save();
                    // close it
                    m_doc.Close();
                    // test if it closed
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void ImportAllSelectedParamsToTargetFile(Autodesk.Revit.DB.Document targetDoc)
        {
            // --- rebuild the insertlist
            //todo - put back
            //foreach (DataGridViewRow oRow in ParentFormParameterJerk. DataGridViewFromFile.SelectedRows)
            //{
            //    // If oRow.Selected Then
            //    ClassOneParamAssociation thisParameterData = oRow.DataBoundItem as ClassOneParamAssociation;
            //    thisParameterData.createSharedParameter(ParentFormParameterJerk.CheckBoxDeleteIfExists.Checked, targetDoc);
            //    // End If
            //}
        }

        public void InitializeOpenFileDialogForRevitFiles()
        {
            //  Set the file dialog to filter for graphics files.
            FilesToModify = new List<string>();
            this.OpenFileDialog1.Filter = "Family Files (*.RFA)|*.RFA";
            this.OpenFileDialog1.Multiselect = true;
            this.OpenFileDialog1.Title = "Parameter Jerk - Select RFA\'s";
        }

        public void InitializeOpenFileDialogForSharedParametersFile()
        {
            //  Set the file dialog to filter for graphics files.
            FilesToModify = new List<string>();
            OpenFileDialog1.Filter = "Shared Parameters Files (*.TXT)|*.TXT";
            OpenFileDialog1.Multiselect = false;
            OpenFileDialog1.Title = "Parameter Jerk - Select Shared Parameter File";
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.InitialDirectory = JerkHub.SharedParametersFileObj.UsersSharedParameterDirectory;
        }

        private void RadioButton1_CheckedChanged_1(object sender, System.EventArgs e)
        {
            this.SetFileSelectOption(false);
            // SplitContainer1.SplitterDistance = SplitContainer1.Height - 100
        }

        private void RadioButton2_CheckedChanged_1(object sender, System.EventArgs e)
        {
            this.SetFileSelectOption(true);
        }

        private void SetFileSelectOption(bool newStatus)
        {
            applyToFileList = newStatus;
            ButtonSelectFiles.Enabled = newStatus;
            ListBoxTargetFiles.Enabled = newStatus;
        }

        #endregion
    }
}