using Ex03.GarageLogic;
using System;
using System.Collections.Generic;

namespace Ex03.ConsoleUI
{
    public class DisplayMenu
    {
        private readonly Garage r_Garage;
        private readonly RechargeVehicleStation r_RechargeStation;
        private readonly RefuelVehicleStation r_RefuelStation;
        private readonly WheelInflateStation r_WheelInflateStation;
        private readonly PrintLicenseNumberList r_PrintLicenseNumberList;
        private readonly VehicleAdder r_VehicleAdder;
        private readonly ChangeVehicleStatus r_ChangeVehicleStatus;
        private const string k_WelcomeMessage = @"Welome to Avner-Brown Garge LTD. 
Please select an option number:
1. Add a new vehicle
2. Display license numbers
3. Change the status of the vehicle
4. Fully inflate tire
5. Refuel a vehicle
6. Recharge a vehicle
7. Display a vehicle's full details
8. Exit";

        /**
        * This method is the constructor for the DisplayMenu.
        */
        public DisplayMenu()
        {
            r_Garage = new Garage();
            r_RechargeStation = new RechargeVehicleStation(r_Garage);
            r_RefuelStation = new RefuelVehicleStation(r_Garage);
            r_WheelInflateStation = new WheelInflateStation(r_Garage);
            r_PrintLicenseNumberList = new PrintLicenseNumberList(r_Garage);
            r_VehicleAdder = new VehicleAdder(r_Garage);
            r_ChangeVehicleStatus = new ChangeVehicleStatus(r_Garage);
        }

        /**
         * This method is the main garage controller
         * runs until the user chooses to exit
         */
        public void GarageMenuOption()
        {
            eMenuOption menuOption = eMenuOption.AddVehicle;

            while(!menuOption.Equals(eMenuOption.Exit)){
                ConsoleUtils.ClearConsoleAndWrite(k_WelcomeMessage);
                string userInput = Console.ReadLine();
                menuOption = checkValidInput(userInput);
                //menu options
                switch (menuOption)
                {
                    case eMenuOption.AddVehicle:
                        r_VehicleAdder.GetVehicleDetailsFromUser();
                        break;
                    case eMenuOption.DisplayLicenseNumbers:
                        r_PrintLicenseNumberList.PrintGarageLicenseNumberList();
                        break;
                    case eMenuOption.ChangeVehicleStatus:
                        r_ChangeVehicleStatus.ChangeStatus();
                        break;
                    case eMenuOption.InflateToMax:
                        r_WheelInflateStation.Inflate();
                        break;
                    case eMenuOption.Refuel:
                        r_RefuelStation.Refuel();
                        break;
                    case eMenuOption.Recharge:
                        r_RechargeStation.Recharge();
                        break;
                    case eMenuOption.DisplayVehicleDetails:
                        printVehicleDetails();
                        break;
                }
            }

            exitGarage();
        }

        /**
         * This method check for a valid Input and returns a valid eMenuOption option.
         */
        private eMenuOption checkValidInput(string i_UserInput)
        {
            string userInput = i_UserInput;
            int userInputAsInt;

            while (!(int.TryParse(userInput, out userInputAsInt) && (Enum.IsDefined(typeof(eMenuOption), userInputAsInt))))
            {
                ConsoleUtils.ClearConsoleAndWrite(k_WelcomeMessage);
                Console.WriteLine(string.Format("{0}Invalid choice, please enter a valid option", Environment.NewLine));
                userInput = Console.ReadLine();
            }

            return (eMenuOption)userInputAsInt;
        }

        /**
         * This method prints the vehicle details.
         */
        private void printVehicleDetails()
        {
            try
            {
                ConsoleUtils.ClearConsoleAndWrite("Please enter the license number of the vehicle");
                string licenceNumber = ConsoleUtils.CheckForValidLicenseNumber(Console.ReadLine());
                ConsoleUtils.ClearConsoleAndWrite(r_Garage.GetVehicleByLicense(licenceNumber).ToString());
                Console.Write(Environment.NewLine);
                ConsoleUtils.PressAnyKeyToContinue();
            }
            catch (KeyNotFoundException knfe)
            {
                ConsoleUtils.ClearConsoleAndWrite(knfe.Message);
                ConsoleUtils.PressAnyKeyToContinue();
            }
        }

        /**
         * This method is the exit for the program.
         */
        private void exitGarage()
        {
            ConsoleUtils.ClearConsoleAndWrite("Thank you, please come again!");
            ConsoleUtils.PressAnyKeyToContinue();
        }

        /**
         * Enum list of menu options
         */
        public enum eMenuOption
        {
            AddVehicle = 1,
            DisplayLicenseNumbers = 2,
            ChangeVehicleStatus = 3,
            InflateToMax = 4,
            Refuel = 5,
            Recharge = 6,
            DisplayVehicleDetails = 7,
            Exit = 8
        }
    }
}

