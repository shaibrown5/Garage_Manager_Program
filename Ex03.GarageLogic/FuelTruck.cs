namespace Ex03.GarageLogic
{
    public class FuelTruck : Truck
    {
        private const Fuel.eFuelType k_FuelType = Fuel.eFuelType.Soler;
        private const float k_FuelTankSize = 120;

        /**
         * Constructor for a fuel based truck
         * updates vehicles energy source
         */
        public FuelTruck()
        {
            EnergySource = new Fuel(k_FuelType, k_FuelTankSize);
        }

        /**
         * To string method that prints the vehicles properties
         */
        public override string ToString()
        {
            return string.Format(@"The vehicle is a fuel truck
{0}", base.ToString());
        }
    }
}
