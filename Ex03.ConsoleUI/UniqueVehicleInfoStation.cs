using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UniqueVehicleInfoStation
    {
        private readonly Garage r_Garage;

        /**
         * Constructor
         * Initializes the current garage
         */
        public UniqueVehicleInfoStation(Garage i_Garage)
        {
            this.r_Garage = i_Garage;
        }

        /**
         * This method updates the relevant vehicles information.
         * Returns the updates vehicle.
         */
        public Vehicle GetUniqueInfo(Vehicle i_Vehicle)
        {
            List<object> userInputAnswers = new List<object>();

            for (int i = 0 ; i < i_Vehicle.UniqueInfoList.Count; i++)
            {
                VehicleUniqueInfo information = i_Vehicle.UniqueInfoList[i];
                string message = (information.Type == typeof(bool))
                    ? "Please Enter y (yes) if {0} or n (no) if not."
                    : "Enter the {0}";
                ConsoleUtils.ClearConsoleAndWrite(string.Format(message, information.Message));
                if (information.Type.IsEnum)
                {
                    ConsoleUtils.PrintEnum(information.Type);
                }

                string userInput = Console.ReadLine();
                try
                {
                    checkUserInformationInput(userInput, information);
                    if (information.Type == typeof(bool))
                    {
                        userInputAnswers.Add(userInput.Equals("y"));
                    }
                    else
                    {
                        userInputAnswers.Add(userInput);
                    }
                }
                catch (FormatException fe)
                {
                    ConsoleUtils.ClearConsoleAndWrite(fe.Message);
                    ConsoleUtils.PressAnyKeyToContinue();
                    i--;
                }
            }

            i_Vehicle.UpdateUniqueFields(userInputAnswers);

            return i_Vehicle;
        }

        /**
         * This method validates the user input according to the data type of the information
         */
        private void checkUserInformationInput(string i_UserInput, VehicleUniqueInfo i_CurrInfo)
        {
            if (i_CurrInfo.Type == typeof(bool))
            {
                if (!(i_UserInput.Equals("y") || i_UserInput.Equals("n")))
                {
                    throw  new FormatException("Illegal input! Input must be either 'y' or 'n'");
                }
            }
            else if (i_CurrInfo.Type == typeof(int))
            {
                int intValue = -1;
                if (!(int.TryParse(i_UserInput, out intValue) && intValue > 0))
                {
                    throw new FormatException("Illegal input! Input must be a positive whole number");
                }
            }
            else if (i_CurrInfo.Type == typeof(float))
            {
                float floatValue = -1;
                if (!(float.TryParse(i_UserInput, out floatValue) && floatValue > 0))
                {
                    throw new FormatException("Illegal input! Input must be a positive float number");
                }
            }
            else if (i_CurrInfo.Type == typeof(string))
            {
                if (String.IsNullOrWhiteSpace(i_UserInput))
                {
                    throw new FormatException("Illegal input! Input can not be empty");
                }
            }
            else if (i_CurrInfo.Type.IsEnum)
            {
                if (!(int.TryParse(i_UserInput, out int intValue) && (Enum.IsDefined(i_CurrInfo.Type, intValue))))
                {
                    throw new FormatException("Illegal input! Input must be an index from the list");
                }
            }
        }
    }
}
