using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class WheelInflateStation
    {
        private readonly Garage r_Garage;
        private string m_LicenseNumber;

        /**
         * This method is the constructor for the WheelInfalteStation.
         */
        public WheelInflateStation(Garage i_Garage)
        {
            r_Garage = i_Garage;
        }

        /**
        * This method is inflate the air to max.
        */
        public void Inflate()
        {
            getLicenseNumber();
            try
            {
                r_Garage.InflateWheelToMax(m_LicenseNumber);
                ConsoleUtils.ClearConsoleAndWrite("Inflated all the wheels successfully");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                ConsoleUtils.ClearConsoleAndWrite(e.Message);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
        }

        /**
         * This method gets the vehicle license number.
         */
        private void getLicenseNumber()
        {
            ConsoleUtils.ClearConsoleAndWrite("Please enter the license number of the vehicle");
            this.m_LicenseNumber = ConsoleUtils.CheckForValidLicenseNumber(Console.ReadLine());
        }
    }
}