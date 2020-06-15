using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class RefuelVehicleStation
    {
        private readonly Garage r_Garage;
        private string m_LicenseNumber;
        private bool m_CheckForEnergyType;
        private float m_AmountForFuel;
        private Fuel.eFuelType m_FuelType;

        /**
         * This method is a constructor for the refuel process.
         */
        public RefuelVehicleStation(Garage i_Garage)
        {
            this.r_Garage = i_Garage;
        }

        /**
        * This method refuels the vehicle.
        * Prints an error according to the error.
        */
        public void Refuel()
        {
            try
            {
                getDetailsForRefuel();
                r_Garage.RefuelVehicle(m_LicenseNumber, m_FuelType, m_AmountForFuel);
                string refuelingMessage = m_CheckForEnergyType
                    ? "Refueled the vehicle successfully"
                    : "Vehicle cannot be refueled";
                ConsoleUtils.ClearConsoleAndWrite(refuelingMessage);
                ConsoleUtils.PressAnyKeyToContinue();
            }
            catch (Exception e)
            {
                ConsoleUtils.ClearConsoleAndWrite(e.Message);
                ConsoleUtils.PressAnyKeyToContinue();
            }
        }

        /**
         * This method asks refueling details.
         */
        private void getDetailsForRefuel()
        {
            ConsoleUtils.ClearConsoleAndWrite("Please enter the license number of the vehicle you would like to refuel:");
            this.m_LicenseNumber = ConsoleUtils.CheckForValidLicenseNumber(Console.ReadLine());
            //checks that the energy types match
            if (m_CheckForEnergyType = checkEnergyType(m_LicenseNumber))
            {
                ConsoleUtils.ClearConsoleAndWrite("Please enter the amount of fuel you would like to refuel:");
                checkForValidAmountOfFuel(Console.ReadLine());
                ConsoleUtils.ClearConsoleAndWrite("Please enter the type of fuel type of the vehicle:");
                Console.WriteLine(@"1. Soler
2. Octan95
3. Octan96
4. Octan98");
                this.m_FuelType = checkForValidFuelType(Console.ReadLine());
            }
        }

        /**
        * This method validates the energy type.
        */
        private bool checkEnergyType(string i_LicenseNumber)
        {
            Vehicle vehicleToCheckType = r_Garage.GetVehicleByLicense(i_LicenseNumber);

            return vehicleToCheckType.EnergySource.EnergyType.Equals(EnergySource.eEnergyType.Fuel);
        }

        /**
        * This method validates the amount of fuel.
        */
        private void checkForValidAmountOfFuel(string i_UserInput)
        {
            string userInput = i_UserInput;

            while (!float.TryParse(userInput, out this.m_AmountForFuel) || m_AmountForFuel < 0)
            {
                ConsoleUtils.ClearConsoleAndWrite("Amount of fuel is invalid, please enter a valid amount");
                userInput = Console.ReadLine();
            }
        }

        /**
        * This method validates the fuel type.
        */
        private Fuel.eFuelType checkForValidFuelType(string i_UserInput)
        {
            string userInput = i_UserInput;
            int userInputAsInt;

            while (!(int.TryParse(userInput, out userInputAsInt) && Enum.IsDefined(typeof(Fuel.eFuelType), userInputAsInt)))
            {
                ConsoleUtils.ClearConsoleAndWrite("Invalid fuel type, please enter a valid type");
                Console.WriteLine(@"1. Soler
2. Octan95
3. Octan96
4. Octan98");
                userInput = Console.ReadLine();
            }

            return (Fuel.eFuelType)userInputAsInt;
        }
    }
}
