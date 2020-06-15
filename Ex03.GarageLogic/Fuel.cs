using System;

namespace Ex03.GarageLogic
{
    public class Fuel : EnergySource
    {
        private readonly eFuelType r_FuelType;

        /**
         * Constructor for fuel type energy source
         * Initializes the fuel type and energy type
         */
        public Fuel(eFuelType i_FuelType, float i_MaxAmountOfFuel ) : base(i_MaxAmountOfFuel)
        {
            this.r_FuelType = i_FuelType;
            EnergyType = eEnergyType.Fuel;
        }

        /**
         * This method refuel a fuel based vehicle
         * Throws ArgumentException if the fuel type is wrong
         */
        public void RefuelFuel(eFuelType i_FuelType, float i_AmountToFill)
        {
            if (i_FuelType != r_FuelType)
            {   
                throw new ArgumentException(string.Format("Fuel must be of type {0}", r_FuelType));
            }
            
            RefuelEnergy(i_AmountToFill);
        }

        /**
         * Enum list of fuel types
         */
        public enum eFuelType
        {
            Soler = 1, 
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        /**
         * To string method that prints the energy sources properties
         */
        public override string ToString()
        {
            return string.Format(@"The fuel type is {0}
The current fuel in liters is {1}
The maximum fuel in liters is {2}", r_FuelType, CurrentEnergyAmount, MaxEnergy);
        }
    }
}
