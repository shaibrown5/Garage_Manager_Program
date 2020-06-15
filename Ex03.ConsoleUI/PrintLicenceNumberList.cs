using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class PrintLicenseNumberList
    {
        private readonly Garage r_Garage;

        /**
         * This method is a constructor for Print license number list
         */
        public PrintLicenseNumberList(Garage i_Garage)
        {
            r_Garage = i_Garage;
        }

        /**
        * This method prints a list of license numbers in the garage.
        */
        public void PrintGarageLicenseNumberList()
        {
            ConsoleUtils.ClearConsoleAndWrite("Would you like to filter the list by vehicle status? enter y / n");
            string needForFilter = checkForValidAnswer(Console.ReadLine());
            if (needForFilter.Equals("y"))
            {
                ConsoleUtils.ClearConsoleAndWrite("Please enter a valid number for a filter.");
                Console.WriteLine(@"The filters are:
1.In repair 
2.Repaired 
3.Payed for");
                Vehicle.eVehicleGarageStatus filter = checkForValidVehicleGarageStatus(Console.ReadLine());
                printList(r_Garage.GetLicenseList(filter));
            }
            else if (needForFilter.Equals("n"))
            {
                printList(r_Garage.GetLicenseList(null));
            }

            ConsoleUtils.PressAnyKeyToContinue();
        }

        /**
         * This method checks for a valid answer by the user for the filter question.
         */
        private string checkForValidAnswer(string i_userInput)
        {
            string userInput = i_userInput;

            while (!userInput.Equals("y") && !userInput.Equals("n"))
            {
                ConsoleUtils.ClearConsoleAndWrite("Invalid Input! Please enter y for yes and n for no");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        /**
         * This method checks for a valid eVehicleGarageStatus
         */
        private Vehicle.eVehicleGarageStatus checkForValidVehicleGarageStatus(string i_userInput)
        {
            string userInput = i_userInput;
            int userInputAsInt;

            while (!((int.TryParse(userInput, out userInputAsInt) && (Enum.IsDefined(typeof(Vehicle.eVehicleGarageStatus), userInputAsInt)))))
            {
                ConsoleUtils.ClearConsoleAndWrite(@"Invalid Input! The filters are:
1.In repair 
2.Repaired 
3.Payed for");
                userInput = Console.ReadLine();
            }

            return (Vehicle.eVehicleGarageStatus)userInputAsInt;
        }

        /**
         * This method will print in a loop the list.
         */
        private void printList(List<string> i_ListOfKeys)
        {
            Console.Clear();
            if (i_ListOfKeys.Count == 0)
            {
                Console.WriteLine("Didn't find any vehicles");
            }
            else
            {
                foreach (string key in i_ListOfKeys)
                {
                    Console.WriteLine(key);
                }
            }
        }
    }
}
