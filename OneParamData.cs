using Autodesk.Revit.DB;

namespace Parameter_Jerk_2018
{
    public class OneParamData :TypicalDataHolder
    {
        #region Properties

        //public int ElementIdAsInt
        //{
        //    get { return ElementId.IntegerValue; }
        //}

        public ElementId ElementId { get; set; }

        private FamilyParameter FamilyParameter { get; set; }

        public string GroupId { get; set; }
        private BuiltInParameterGroup _groupParameterUnderEnum = BuiltInParameterGroup.PG_GRAPHICS;


        public BuiltInParameterGroup CurrentParameterGroup { get; set; }

        public string GroupParameterUnderAsLabelStr
        {
            get
            {
                //  JerkHub.Ptr2Debug.addToDebug("s) aaa")
                return Autodesk.Revit.DB.LabelUtils.GetLabelFor(  FamilyParameter.Definition.ParameterGroup).ToString();
                //  Return _groupParameterUnderLabel
            }
            set
            {
                // from here we need to figure out what the parameter is that the string represents
                _groupParameterUnderEnum = JerkHub.ParameterGroupParameterUnderManagerListObj.LabelToParameterEnum(value);
            }
        }

        public string GroupUnder
        {
            get
            {
                string toReturn = "Other";

                if ((BuiltInParameterGroup) FamilyParameter.Definition.ParameterGroup == BuiltInParameterGroup.INVALID)
                {
                    toReturn = "Other";
                }
                else
                {
                    toReturn = ((BuiltInParameterGroup) FamilyParameter.Definition.ParameterGroup).ToString();
                }
                return toReturn;
            }
        }

        public string ParameterDefinitionName { get; set; }


        public string Type { get; set; }
        public string UnitType { get; set; }

        #endregion

        #region Methods

        public OneParamData(FamilyParameter familyParameter, ParameterJerkerHubCentral jerkHub) : base(jerkHub)
        {
            this.FamilyParameter = familyParameter;
            CurrentParameterGroup = familyParameter.Definition.ParameterGroup;
        }

        #endregion
    }
}