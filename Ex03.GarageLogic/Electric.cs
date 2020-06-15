namespace Ex03.GarageLogic
{
    public class Electric : EnergySource
    {
        /**
         * Constructor for electric type energy source
         */
        public Electric(float i_MaxTimeOfEngineOp) : base(i_MaxTimeOfEngineOp)
        {}

        /**
         * This method chardes the batery with the inputed amount
         */
        public void ChargeBatery(float i_AmountToCharge)
        {
            RefuelEnergy(i_AmountToCharge);
            EnergyType = eEnergyType.Electric;
        }
    }
}
