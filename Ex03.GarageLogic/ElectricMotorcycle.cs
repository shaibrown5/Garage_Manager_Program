namespace Ex03.GarageLogic
{
    public class ElectricMotorcycle : Motorcycle
    {
        public const float k_MaxBatteryLife = 1.2f;

        /**
         * Constructor that creates a new electric based motorcycle
         * Initializes the energy source
         */
        public ElectricMotorcycle()
        {
            EnergySource = new Electric(k_MaxBatteryLife);
        }

        /**
         * To string method that prints vehicle relevant properties
         */
        public override string ToString()
        {
            return string.Format(@"The vehicle is an Electric Motorcycle
{0}", base.ToString());
        }
    }
}
