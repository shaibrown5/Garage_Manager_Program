using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class RechargeVehicleStation
    {
        private readonly Garage r_Garage;
        private string m_LicenseNumber;
        private bool m_CheckForEnergyType;
        private int m_MinsToCharge;

        /**
         * This method is a constructor for the recharge process.
         */
        public RechargeVehicleStation(Garage i_Garage)
        {
            this.r_Garage = i_Garage;
        }

        /**
         * This method recharges the vehicle.
         * Prints an error according to the error.
         */
        public void Recharge()
        {
            try
            {
                getDetailsForRecharge();
                r_Garage.RechargeVehicle(m_LicenseNumber, m_MinsToCharge/60);
                string chargingMessage = m_CheckForEnergyType ? "Vehicle was charged successfully" : "Vehicle can't be charged";
                ConsoleUtils.ClearConsoleAndWrite(chargingMessage);
                ConsoleUtils.PressAnyKeyToContinue();
            }
            catch (Exception e)
            {
                ConsoleUtils.ClearConsoleAndWrite(e.Message);
                ConsoleUtils.PressAnyKeyToContinue();
            }
        }

        /**
         * This method asks for details for recharge.
         */
        private void getDetailsForRecharge()
        {
            ConsoleUtils.ClearConsoleAndWrite("Please enter the license number of the vehicle you would like to charge:");
            this.m_LicenseNumber = ConsoleUtils.CheckForValidLicenseNumber(Console.ReadLine());
            if(m_CheckForEnergyType = checkForValidEnergyType(m_LicenseNumber))
            {
                ConsoleUtils.ClearConsoleAndWrite("Please enter the amount of time to charge the battery (in whole minutes):");
                checkForValidMinsToReCharge(Console.ReadLine());
            }
        }

        /**
         * This method validates the energy type.
         */
        private bool checkForValidEnergyType(string i_LicenseNumber)
        {
            Vehicle vehicleToCheckType = r_Garage.GetVehicleByLicense(i_LicenseNumber);

            return vehicleToCheckType.EnergySource.EnergyType.Equals(EnergySource.eEnergyType.Electric);
        }

        /**
         * This method validates the amount of time to recharge in min.
         */
        private void checkForValidMinsToReCharge(string i_userInput)
        {
            string minsToChargeStr = i_userInput;

            while (!int.TryParse(minsToChargeStr, out this.m_MinsToCharge))
            {
                ConsoleUtils.ClearConsoleAndWrite("Invalid number of minutes to charge");
                Console.WriteLine("Please enter a valid amount of minutes to charge:");
                minsToChargeStr = Console.ReadLine();
            }
        }
    }
}
