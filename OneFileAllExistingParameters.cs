using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB;

namespace Parameter_Jerk_2018
{
    public class OneFileAllExistingParameters : TypicalDataHolder
    {
        #region Fields

        private List<OneParamData> _allParamData;

        #endregion

        #region Properties

        public List<OneParamData> AllParamData
        {
            get { return _allParamData ?? (_allParamData = BuildParamData()); }
            set { _allParamData = value; }
        }


        #endregion

        #region Methods

        public OneFileAllExistingParameters(ParameterJerkerHubCentral jerkerHub) : base(jerkerHub)
        {
            if (AllParamData != null && AllParamData.Any())
            {
                string dog = AllParamData[0].ParameterDefinitionName;
            }
        }

        private List<OneParamData> BuildParamData()
        {
            List<OneParamData> toREturn = new List<OneParamData>();

            if (JerkHub?.RevitInterface.AllParametersFromFamilyMan != null)
            {
                foreach (FamilyParameter familyParameter in   JerkHub.RevitInterface.AllParametersFromFamilyMan.Take(10))
                {
                    OneParamData oneParamData = new OneParamData(familyParameter, JerkHub)
                    {
                        ParameterDefinitionName = familyParameter.Definition.Name,
                        GroupId = familyParameter.Definition.ParameterGroup.ToString(),
                        Type = ((ParameterType) familyParameter.Definition.ParameterType).ToString(),
                        UnitType = ((UnitType) familyParameter.Definition.UnitType).ToString(),
                        ElementId = familyParameter.Id
                        // GroupUnder = familyParameter.Definition.ParameterGroup
                        //externDef.OwnerGroup.ParameterDefinitionName;
                    };

                    toREturn.Add(oneParamData);
                }
            }


            return toREturn;
        }

        #endregion
    }
}