using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;

namespace Parameter_Jerk_2018
{
    public class GroupParameterUnderManager : TypicalDataHolder
    {
        #region Properties

        // this class builds and deals with parameter group under values
        // not all the ones are one we want to use, so they must be selected
        public List<BuiltInParameterGroup> GroupParameterUnderBuiltInParameterGroupList { get; set; } = new List<BuiltInParameterGroup>();


        public List<string> GroupParameterUnderlabelList { get; set; } = new List<string>();

        #endregion

        #region Methods

        public GroupParameterUnderManager(ParameterJerkerHubCentral jerkHub) : base(jerkHub)
        {
            this.InitParameterList();
            this.BuildLabelList();
            GroupParameterUnderlabelList.Sort();
        }

        private void BuildLabelList()
        {


            List<BuiltInParameterGroup> values = Enum.GetValues(typeof(BuiltInParameterGroup)).Cast<BuiltInParameterGroup>().ToList();

            foreach (BuiltInParameterGroup builtInParameterGroup in values)
            {
                GroupParameterUnderlabelList.Add(LabelUtils.GetLabelFor(builtInParameterGroup));
            }


            //foreach (BuiltInParameterGroup oneParam in GroupParameterUnderBuiltInParameterGroupList)
            //{
            //    GroupParameterUnderlabelList.Add(LabelUtils.GetLabelFor(oneParam));
            //}
        }

        public DataGridViewComboBoxColumn CreateComboBoxWithEnums()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn
            {
                DataPropertyName =  "GroupParameterUnderAsLabelStr",
                Name = "GroupParameterUnderAsLabelStr",
                HeaderText = "GroupUnder Parameter Under",
                DisplayIndex = 2,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataSource = GroupParameterUnderlabelList,
            };


            return combo;
        }

        public int GetItemIndex(string targetStr)
        {
            int returnIndex = 0;
            int indCount = 0;
            foreach (string oneItem in GroupParameterUnderlabelList)
            {
                if ((oneItem == targetStr))
                {
                    returnIndex = indCount;
                    break;
                }

                indCount++;
            }

            return returnIndex;
        }

        // 1) Energy Model - Building Services : PG_CONCEPTUAL_ENERGY_DATA_BUILDING_SERVICES
        // 2) Data : PG_DATA
        // 3) Electrical - Circuiting : PG_ELECTRICAL_CIRCUITING
        // 4) General : PG_GENERAL
        // 5) Adaptive Component : PG_FLEXIBLE
        // 6) Energy Model : PG_ENERGY_ANALYSIS_CONCEPTUAL_MODEL
        // 7) Detailed Model : PG_ENERGY_ANALYSIS_DETAILED_MODEL
        // 8) Common : PG_ENERGY_ANALYSIS_DETAILED_AND_CONCEPTUAL_MODELS
        // 9) Fitting : PG_FITTING
        // 10) Conceptual Energy Data : PG_CONCEPTUAL_ENERGY_DATA
        // 11) Area : PG_AREA
        // 12) Model Properties : PG_ADSK_MODEL_PROPERTIES
        // 13) V Grid : PG_PATTERN_GRID_V
        // 14) U Grid : PG_PATTERN_GRID_U
        // 15) Display : PG_DISPLAY
        // 16) Analysis Results : PG_ANALYSIS_RESULTS
        // 17) Slab Shape Edit : PG_SLAB_SHAPE_EDIT
        // 18) Photometrics : PG_LIGHT_PHOTOMETRICS
        // 19) Pattern Application : PG_PATTERN_APPLICATION
        // 20) Green Building Properties : PG_GREEN_BUILDING
        // 21) Profile 2 : PG_PROFILE_2
        // 22) Profile 1 : PG_PROFILE_1
        // 23) Profile : PG_PROFILE
        // 24) Bottom Chords : PG_TRUSS_FAMILY_BOTTOM_CHORD
        // 25) Top Chords : PG_TRUSS_FAMILY_TOP_CHORD
        // 26) Diagonal Webs : PG_TRUSS_FAMILY_DIAG_WEB
        // 27) Vertical Webs : PG_TRUSS_FAMILY_VERT_WEB
        // 28) Title Text : PG_TITLE
        // 29) Fire Protection : PG_FIRE_PROTECTION
        // 30) Rotation about : PG_ROTATION_ABOUT
        // 31) Translation in : PG_TRANSLATION_IN
        // 32) Analytical Model : PG_ANALYTICAL_MODEL
        // 33) Rebar Set : PG_REBAR_ARRAY
        // 34) Layers : PG_REBAR_SYSTEM_LAYERS
        // 35) Member Orientation : PG_ORIENTATION
        // 36) Grid Pattern : PG_PATTERN_GRID
        // 37) Grid 2 Mullions : PG_PATTERN_MULLION_2
        // 38) Horizontal Mullions : PG_PATTERN_MULLION_HORIZ
        // 39) Grid 1 Mullions : PG_PATTERN_MULLION_1
        // 40) Vertical Mullions : PG_PATTERN_MULLION_VERT
        // 41) Grid 2 Pattern : PG_PATTERN_GRID_2
        // 42) Horizontal Grid Pattern : PG_PATTERN_GRID_HORIZ
        // 43) Grid 1 Pattern : PG_PATTERN_GRID_1
        // 44) Vertical Grid Pattern : PG_PATTERN_GRID_VERT
        // 45) IFC Parameters : PG_IFC
        // 46) Electrical : PG_AELECTRICAL
        // 47) Energy Analysis : PG_ENERGY_ANALYSIS
        // 48) Structural Analysis : PG_STRUCTURAL_ANALYSIS
        // 49) Mechanical - Airflow : PG_MECHANICAL_AIRFLOW
        // 50) Mechanical - Loads : PG_MECHANICAL_LOADS
        // 51) Electrical - Loads : PG_ELECTRICAL_LOADS
        // 52) Electrical - Lighting : PG_ELECTRICAL_LIGHTING
        // 53) Text : PG_TEXT
        // 54) Camera : PG_VIEW_CAMERA
        // 55) Extents : PG_VIEW_EXTENTS
        // 56) Pattern : PG_PATTERN
        // 57) Constraints : PG_CONSTRAINTS
        // 58) Phasing : PG_PHASING
        // 59) Mechanical : PG_MECHANICAL
        // 60) Structural : PG_STRUCTURAL
        // 61) Plumbing : PG_PLUMBING
        // 62) Electrical Engineering : PG_ELECTRICAL
        // 63) Stringers : PG_STAIR_STRINGERS
        // 64) Risers : PG_STAIR_RISERS
        // 65) Treads : PG_STAIR_TREADS
        // 66) Materials and Finishes : PG_MATERIALS
        // 67) Graphics : PG_GRAPHICS
        // 68) Construction : PG_CONSTRUCTION
        // 69) Dimensions : PG_GEOMETRY
        // 70) Identity Data : PG_IDENTITY_DATA
        // 71) Other : INVALID
        private void InitParameterList()
        {
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.INVALID);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ANALYSIS_RESULTS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ANALYTICAL_MODEL);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_CONSTRAINTS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_CONSTRUCTION);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_DATA);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_GEOMETRY);
            //  get dimensions
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_AELECTRICAL);
            // electrical 
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ELECTRICAL);
            // electrical engineering
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ELECTRICAL_CIRCUITING);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ELECTRICAL_LIGHTING);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ELECTRICAL_LOADS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ENERGY_ANALYSIS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_FIRE_PROTECTION);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_GENERAL);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_GRAPHICS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_GREEN_BUILDING);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_IDENTITY_DATA);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_IFC);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_REBAR_SYSTEM_LAYERS);
            // layers
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_MATERIALS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_MECHANICAL);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_MECHANICAL_AIRFLOW);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_MECHANICAL_LOADS);
            //todo  groupParameterUnderBuiltInParameterGroupList.Add(-1);
            // other
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_ADSK_MODEL_PROPERTIES);
            // model properties
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_PHASING);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_LIGHT_PHOTOMETRICS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_PLUMBING);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_REBAR_ARRAY);
            // rebar set??
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_SLAB_SHAPE_EDIT);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_STRUCTURAL);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_STRUCTURAL_ANALYSIS);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_TEXT);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_TITLE);
            GroupParameterUnderBuiltInParameterGroupList.Add(Autodesk.Revit.DB.BuiltInParameterGroup.PG_VISIBILITY);
        }

        public BuiltInParameterGroup LabelToParameterEnum(string labelStr)
        {
            BuiltInParameterGroup returnParamGroup = BuiltInParameterGroup.PG_GRAPHICS;
            JerkHub.Ptr2Debug.AddToDebug(("trying to find enum for this label --> " + labelStr));
            foreach (BuiltInParameterGroup oneParam in GroupParameterUnderBuiltInParameterGroupList)
            {
                //   JerkHub.Ptr2Debug.addToDebug("comparing " & labelStr & " <-> " & LabelUtils.GetLabelFor(oneParam))
                if ((labelStr == LabelUtils.GetLabelFor(oneParam)))
                {
                    JerkHub.Ptr2Debug.AddToDebug(("found: "
                                                  + (labelStr + (" : "
                                                                 + (LabelUtils.GetLabelFor(oneParam) + (" : " + oneParam.ToString()))))));
                    returnParamGroup = oneParam;
                }
            }

            return returnParamGroup;
        }

        private int sortByLabel(BuiltInParameterGroup p1, BuiltInParameterGroup p2)
        {
            // Dim a As String = LabelUtils.GetLabelFor(p1)
            //   JerkHub.Ptr2Debug.addToDebug("Compare: " & LabelUtils.GetLabelFor(p1) & " : " & LabelUtils.GetLabelFor(p2))
            return (String.Compare(LabelUtils.GetLabelFor(p1), LabelUtils.GetLabelFor(p2), StringComparison.Ordinal));
        }

        #endregion
    }
}