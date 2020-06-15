namespace Ex03.GarageLogic
{
    public class FuelMotorcycle : Motorcycle
    {
        public const Fuel.eFuelType k_FuelType = Fuel.eFuelType.Octan95;
        public const float k_FuelTankSize = 7;

        /**
         * Constructor for fuel based motorcycles
         * Updates the energy source of the vehicle
         */
        public FuelMotorcycle()
        {
            EnergySource = new Fuel(k_FuelType, k_FuelTankSize);
        }

        /**
         * To string method that prints relevant vehicles properties
         */
        public override string ToString()
        {
            return string.Format(@"The vehicle is a fuel motorcycle
{0}", base.ToString());
        }
    }
}
