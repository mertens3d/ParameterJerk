using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Parameter_Jerk_2018.Forms
{
    public partial class FormParameterJerk : Form
    {
        #region Fields

       

        public bool FirstTime = true;

        #endregion

        #region Properties

        public ParameterJerkerHubCentral JerkHub { get; set; }

        #endregion

        #region Methods

        public FormParameterJerk(ParameterJerkerHubCentral jerkHub)
        {
            InitializeComponent();
            this.JerkHub = jerkHub;


            bottomButtons1.DisplayChild(jerkHub);
        }


        private void Button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


        private void Button3_Click(object sender, System.EventArgs e)
        {
            Process.Start("http://mertens3d.com/tools/revit/2013/parameter-jerk-2013/parameter-jerk-2013-use.php");
        }

        private void Button4_Click(object sender, System.EventArgs e)
        {
            Process.Start("http://mertens3d.com/blog/?p=441");
        }


        private void Button7_Click(object sender, System.EventArgs e)
        {
            JerkHub.SaveSupplementalDataFile();
        }


        private void Button7_Click_3(object sender, System.EventArgs e)
        {
            if (System.IO.File.Exists(JerkHub.SupplementalDataFileObj.DataFileNameLong))
            {
                System.Diagnostics.Process.Start("notepad.exe", JerkHub.SupplementalDataFileObj.DataFileNameLong);
            }
            else
            {
                MessageBox.Show(("Cannot find the supplemental data file:" + ("\r\n" + JerkHub.SupplementalDataFileObj.DataFileNameLong)));
            }
        }


        private void buttonClickedColumnCreateParamIndividual()
        {
            //     '        thisIdx = DataGridView1.CurrentCell.ColumnIndex
            //     'they want to create the parameter, so do it
            //     Dim thisDataItem As ClassOneParamAssociation = DataGridViewFromFile.CurrentRow.DataBoundItem
            //     If JerkHub.sharedParametersFileObj.stageOkForSetup Then
            //         thisDataItem.createSharedParameter()
            //         build_FormData()
            //     End If
        }

        private void ButtonDoIt_Click(object sender, System.EventArgs e)
        {
        }


        private void checkIfSaved(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (JerkHub.Flags.FileNeedsToBeSaved)
            {
                // Dim MessageBoxVB As NewDog System.Text.StringBuilder()
                // MessageBoxVB.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason)
                // MessageBoxVB.AppendLine()
                // MessageBoxVB.AppendFormat("{0} = {1}", "Cancel", e.Cancel)
                // MessageBoxVB.AppendLine()
                // MessageBox.Show(MessageBoxVB.ToString()(), "FormClosing Event")
                DialogResult msgResponse = MessageBox.Show("Supplemental Data needs to be saved. Are you sure you want to close?", "", MessageBoxButtons.OKCancel);
                if ((msgResponse == DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
        }


        private void currentFamilyFile1_Load(object sender, EventArgs e)
        {
        }

        private void CurrentFileTabSelected(object sender, TabControlEventArgs e)
        {
        }


        private void dataGridResults_SelectionChanged(object sender, System.EventArgs e)
        {
            if ((dataGridResults.SelectedCells.Count > 0))
            {
                dataGridResults.ClearSelection();
            }
        }

        //  If a check box cell is clicked, this event handler disables  
        //  or enables the button in the same row as the clicked cell.


        // Private Sub fixButtonForIndividualParams(ByVal oRow As DataGridViewRow)
        //     Dim oStyleFound As NewDog DataGridViewCellStyle
        //     Dim thisData As ClassOneParamAssociation = oRow.DataBoundItem
        //     Dim thisDrawingColor = NewDog System.Drawing.Color
        //     Dim buttonColor As NewDog System.Drawing.Color
        //     Dim buttonText As String = ""
        //     Dim buttonEnabled As Boolean = False
        //     If thisData.parameterFoundInThisFileBool Then
        //         thisDrawingColor = myColorGood
        //         buttonColor = myColorGood
        //         buttonText = "none"
        //         buttonEnabled = False
        //     Else
        //         thisDrawingColor = myColorWarning
        //         buttonColor = myColorWarning
        //         buttonText = "create ->"
        //         buttonEnabled = True
        //     End If
        //     oStyleFound.BackColor = thisDrawingColor
        //     'oStyleFound.ForeColor = thisDrawingColor
        //     'oRow.Cells(2).Style = oStyleFound
        //     oRow.Cells("parameterFoundInThisFileBool").Style = oStyleFound
        //     'oRow.Cells("existColorSwatch").Value = "xxx"
        //     Dim cell As DataGridViewCell = oRow.Cells("ColumnCreateParam")
        //     cell.Style.BackColor = buttonColor
        //     With oRow.Cells("ColumnCreateParam")
        //         .Value = buttonText
        //         .Style = oStyleFound
        //     End With
        //     '-----------------------------------------------------------------------
        //     '--- make sure the parameter is text
        //     If thisData.parameterFoundInThisFileBool Then
        //         Dim oStyleIsText As NewDog DataGridViewCellStyle
        //         'oStyleIsText.BackColor = myColorGood
        //         'Else
        //         '    oStyleIsText.BackColor = myColorError
        //         '    warningText += thisData.thisParameterName & vbCrLf
        //     End If
        //     '  oRow.Cells("paramIsTextStr").Style = oStyleIsText
        //     '
        //     ' End If
        //     '
        //     '---------------------
        // End Sub
        // Private Sub createTheDropBox()
        //     If isFirstBinding Then
        //         Dim cmb As NewDog DataGridViewComboBoxColumn
        //         cmb.HeaderText = "Select Data"
        //         cmb.ParameterDefinitionName = "cmb"
        //         cmb.MaxDropDownItems = 2
        //         cmb.Items.Add("True")
        //         cmb.Items.Add("False")
        //         DataGridViewFromFile.Columns.Add(cmb)
        //         isFirstBinding = False
        //     End If
        // End Sub
        //     Dim warningText As String = ""
        //     For Each oRow As DataGridViewRow In DataGridViewFromFile.Rows
        //         fixButtonForIndividualParams(oRow)
        //     Next
        //     If warningText.Length > 0 And Not warningIssued Then
        //         warningIssued = True
        //     End If
        // End Sub


        private void DataGridViewSetShortCut_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(("data error in DataGridViewSetShortCut. " + e.ToString()));
        }


        // Public Sub unselectAllShortCuts()
        //     For Each oRow As DataGridViewRow In DataGridViewSetShortCut.Rows
        //         oRow.Selected = False
        //     Next
        // End Sub
        private void editSetsError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("edit sets error");
        }

        private void FormParameterJerk_Load(object sender, System.EventArgs e)
        {
            Uri thisUri = new Uri(("http://mertens3d.com/tools/revit/2013/parameter-jerk-2013/form-data/parameter-jerk-2013-generic.php?revitVersion="
                                   + (JerkHub.RevitInterface.RevitVersionNumberStr + ("&dllVersion=" + JerkHub. CurrentVersionNumber))));
            //todo  WebBrowser1.Url = thisUri;
            this.Text = ("Parameter Jerk "
                         + (JerkHub.CurrentVersionNumber + " by: gregory mertens/ mertens3d"));
            if ((JerkHub.StageSetupstageOkForJerking == false))
            {
                this.Close();
            }
        }

        private void fromFileSelectionChanged(object sender, System.EventArgs e)
        {
            // we want to detect if the uers hit the button only...we don't care about the rest...at least right now
            // Dim thisIdx As Integer
            //   Dim targetIdx As Integer = DataGridViewFromFile.CurrentCell.ColumnIndex
            //    Dim thisColumn As DataGridViewColumn
            //    Dim thisColumnName As String
            //   thisColumn = DataGridViewFromFile.Columns(targetIdx)
            //  thisColumnName = thisColumn.ParameterDefinitionName
            // If thisColumnName = "ColumnCreateParam" Then
            //     buttonClickedColumnCreateParamIndividual()
            // End If
            //     'If thisColumnName = "columnCreateLabel" Then
            //     '    Dim thisDataItem As ClassOneParamAssociation = DataGridViewFromFile.CurrentRow.DataBoundItem
            //     '    'thisDataItem.createLabel()
            //     'End If
        }


        // Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        //     'OpenFileDialog1.GroupParameterUnderAsLabelStr = "Select a shared parameters file"
        //     'OpenFileDialog1.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location
        //     'OpenFileDialog1.ShowDialog()
        // End Sub


        private void InializeCompPartB()
        {
            if (JerkHub.StageSetupstageOkForJerking)
            {
                // DataGridViewFromFile.Anchor = AnchorStyles.Bottom & AnchorStyles.Left
                JerkHub.InitFromFiles();

                this.BringToFront();
            }
        }


        private string listOpenDocuments()
        {
            string returnStr = "";
            foreach (Autodesk.Revit.DB.Document oneDoc in JerkHub.RevitInterface.Ptr2UiApp.Application.Documents)
            {
                returnStr = (returnStr
                             + (oneDoc.PathName + "\r\n"));
            }

            return returnStr;
        }

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MainTabControl.SelectedTab.Name.Equals(tabCurrentFile.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                currentFamilyChild.DisplayChild(JerkHub);
            }
            else if (MainTabControl.SelectedTab.Name.Equals(TabPageFirst.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                FirstTabChildControl.DisplayChild(JerkHub);
            }
            else if (MainTabControl.SelectedTab.Name.Equals(TabPageDebug.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                debugChild.DisplayChild(JerkHub);
            }
        }


        private void NewDog(object sender, EventArgs e)
        {
            this.InializeCompPartB();
        }

        // Private Sub ButtonSharedParamFile_Click(sender As System.Object, e As System.EventArgs)
        //     Dim userSelectedSharedParametersFileNameLong As String
        //     InitializeOpenFileDialogForSharedParametersFile()
        //     Dim dr As DialogResult = Me.OpenFileDialog1.ShowDialog()
        //     If (dr = System.Windows.Forms.DialogResult.OK) Then
        //         userSelectedSharedParametersFileNameLong = OpenFileDialog1.FileName
        //         inializeCompPartB(userSelectedSharedParametersFileNameLong)
        //         ' Create a PictureBox for each file, and add that file to the FlowLayoutPanel.
        //         Try
        //         Catch SecEx As SecurityException
        //             ' The user lacks appropriate permissions to read files, discover paths, etc.
        //             MessageBox.Show("Security error. Please contact your administrator for details.\n\n" & _
        //                 "Error message: " & SecEx.Message & "\n\n" & _
        //                 "Details (send to Support):\n\n" & SecEx.StackTrace)
        //         Catch ex As Exception
        //             ' Could not load the image - probably permissions-related.
        //             MessageBox.Show("Error, You may not have permission to read the file, or " + "it may be corrupt." _
        //             & ControlChars.Lf & ControlChars.Lf & "Reported error: " & ex.Message)
        //         End Try
        //     Else
        //         MessageBox.Show("Did not set a new Shared Parameters File")
        //     End If
        // End Sub


        // Private Sub DataGridViewFromFile_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewFromFile.SelectionChanged
        //     If DataGridViewFromFile.SelectedRows.Count > 0 Then
        //         DataGridViewFromFile.ClearSelection()
        //     End If
        // End Sub
        private void SplitContainer1_Panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
        }

        private void TabPage1_Click(object sender, System.EventArgs e)
        {
        }

        private void TabPageSetsB_Click(object sender, System.EventArgs e)
        {
        }

        // Private Sub buttonClickedColumnCreateParamGroup()
        //     Dim thisDataItem As ClassOneParamGroup = DataGridViewGroups.CurrentRow.DataBoundItem
        //     If JerkHub.sharedParametersFileObj.stageOkForSetup Then
        //         JerkHub.createAllInThisParameterGroup(thisDataItem.groupNameB)
        //         build_FormData()
        //     End If
        // End Sub
        private string tempgroupUnderSelectedIndexChanged()
        {
            string allSelected = "";
            foreach (ClassOneParamAssociation oneValue in JerkHub.AllParametersSelectedToBeInserted)
            {
                allSelected = (allSelected
                               + (oneValue.ThisParameterName + "   "));
            }

            return allSelected;
        }

        public void TriggerA()
        {
            bottomButtons1.BuildSelectedParamsToInsertList();
           //todo put back FirstTabChildControl.BuildSelectedParamsToInsertList();
        }


        public void UpdateResultsData()
        {
            //  Me.Main.SelectedTab = TabPage2
            this.dataGridResults.AutoGenerateColumns = true;
            this.dataGridResults.DataSource = JerkHub.AllResultsList;
            // Me.Focus()
            this.dataGridResults.Refresh();
        }

        #endregion
    }
}