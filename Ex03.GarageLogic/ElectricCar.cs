namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        public const float k_MaxBatteryLife = 2.1f;

        /**
         * Constructor for electric based car
         * Initializes the energy source
         */
        public ElectricCar()
        {
            EnergySource = new Electric(k_MaxBatteryLife);
        }

        /**
         * To string method that returns vehicle relevant properties
         */
        public override string ToString()
        {
            return string.Format(@"The vehicle is an Electric Car
{0}", base.ToString());
        }
    }
}
