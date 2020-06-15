using System;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        /**
         * This method creates the wanted vehicle type and returns it
         * Throws ArgumentException if no such vehicle exists
         */
        public static Vehicle MakeVehicle(eVehicleType i_VehicleType)
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.ElectricMotorcycle:
                    newVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.FuelMotorcycle:
                    newVehicle = new FuelMotorcycle();
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case eVehicleType.FuelCar:
                    newVehicle = new FuelCar();
                    break;
                case eVehicleType.FuelTruck:
                    newVehicle = new FuelTruck();
                    break;
                default:
                    throw new ArgumentException(string.Format("The index {0} is not supported.", i_VehicleType));
            }

            return newVehicle;
        }

        /**
         * Enum list of vehicle types accepted by this garage
         */
        public enum eVehicleType
        {
            FuelMotorcycle = 1,
            ElectricMotorcycle = 2,
            FuelCar = 3, 
            ElectricCar = 4, 
            FuelTruck = 5
        }
    }
}
