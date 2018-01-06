namespace Parameter_Jerk_2018
{
    public abstract class TypicalDataHolder
    {
        protected ParameterJerkerHubCentral JerkHub { get; set; }



        protected TypicalDataHolder(ParameterJerkerHubCentral jerkHub)
        {
            JerkHub = jerkHub;
        }
    }
}