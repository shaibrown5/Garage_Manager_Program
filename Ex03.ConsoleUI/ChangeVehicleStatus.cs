using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ChangeVehicleStatus
    {
        private readonly Garage r_Garage;
        private string m_LicenseNumber;
        private Vehicle.eVehicleGarageStatus m_NewVehicleStatus;

        /**
         * This method is the constructor for the ChangeVehicleStatus
         */
        public ChangeVehicleStatus(Garage i_Garage)
        {
            this.r_Garage = i_Garage;
        }

        /**
        * This method changes the vehicle status.
        */
        public void ChangeStatus()
        {
            getDetailsForStatusChange();
            try
            {
                r_Garage.ChangeVehicleStatus(m_LicenseNumber, m_NewVehicleStatus);
                ConsoleUtils.ClearConsoleAndWrite("Changed the status of the vehicle successfully");
                ConsoleUtils.PressAnyKeyToContinue();
            }
            catch (Exception e)
            {
                ConsoleUtils.ClearConsoleAndWrite(e.Message);
                ConsoleUtils.PressAnyKeyToContinue();
            }
        }

        /**
         * This method asks for the license number of the vehicle.
         */
        private void getDetailsForStatusChange()
        {
            ConsoleUtils.ClearConsoleAndWrite("Please enter the License number of the vehicle you would like to change the status:");
            this.m_LicenseNumber = ConsoleUtils.CheckForValidLicenseNumber(Console.ReadLine());
            ConsoleUtils.ClearConsoleAndWrite("Please enter the number of the status you would like");
            Console.WriteLine(@"1.In repair
2.Repaired
3.Payed for");
            m_NewVehicleStatus = checkForValidVehicleStatus(Console.ReadLine());
        }

        /**
         * This method validates the vehicle status.
         */
        private Vehicle.eVehicleGarageStatus checkForValidVehicleStatus(string i_UserInput)
        {
            string userInput = i_UserInput;
            int userInputAsInt;

            while (!(int.TryParse(userInput, out userInputAsInt) && (Enum.IsDefined(typeof(Vehicle.eVehicleGarageStatus), userInputAsInt))))
            {
                ConsoleUtils.ClearConsoleAndWrite("Invalid status, please enter a valid status");
                Console.WriteLine(@"1.In repair,
2.Repaired,
3.Payed for");
                userInput = Console.ReadLine();
            }

            return (Vehicle.eVehicleGarageStatus)userInputAsInt;
        }
    }
}
