namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        public const Fuel.eFuelType k_FuelType = Fuel.eFuelType.Octan96;
        public const float k_FuelTankSize = 60;

        /**
         * Constructor for fuel based car
         * Updates the vehicles energy source
         */
        public FuelCar() 
        {
            EnergySource = new Fuel(k_FuelType, k_FuelTankSize);
        }

        /**
         * To string method that prints relevant vehicles properties
         */
        public override string ToString()
        {
            return string.Format(@"The vehicle is a Fuel Car
{0}", base.ToString());
        }
    }
}
