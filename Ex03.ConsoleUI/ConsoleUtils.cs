using System;

namespace Ex03.ConsoleUI
{
    public class ConsoleUtils
    {
        /**
        * This method clears the console log and writes a message
        */
        public static void ClearConsoleAndWrite(string i_Message)
        {
            Console.Clear();
            Console.WriteLine(i_Message);
        }

        /**
         * This method prints and exit message and waits for the user to press any key to continue
         */
        public static void PressAnyKeyToContinue()
        {
            Console.Out.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        /**
        * This method validates the license number.
        */
        public static string CheckForValidLicenseNumber(string i_UserInput)
        {
            string userInput = i_UserInput;

            while (String.IsNullOrWhiteSpace(userInput))
            {
                ClearConsoleAndWrite("License number can't be empty, please enter a valid license number");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        /**
         * This method prints an Enum list
         */
        public static void PrintEnum(Type i_Enum)
        {
            int valueIndex = 1;

            foreach (Enum enumValue in Enum.GetValues(i_Enum))
            {
                if (!enumValue.ToString().Equals("Undefined"))
                {
                    Console.WriteLine(string.Format("{0}. {1}", valueIndex, enumValue.ToString()));
                    valueIndex++;
                }
            }
        }

        /**
        * This method validates a string input
        */
        public static string CheckStringInput(string i_UserInput, string i_Message)
        {
            string userInput = i_UserInput;

            while (String.IsNullOrWhiteSpace(userInput))
            {
                ClearConsoleAndWrite(string.Format("{0} can not be empty!{1}Please re enter choice", i_Message, Environment.NewLine));
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        /**
         * This method validates a float input
         */
        public static float CheckFloatInput(string i_InputToCheck, string i_Message)
        {
            string inputToConvert = i_InputToCheck;
            float convertedInput = -1;

            while (!float.TryParse(inputToConvert, out convertedInput) || convertedInput < 0 || String.IsNullOrWhiteSpace(inputToConvert))
            {
                ClearConsoleAndWrite(string.Format("{0} must be a positive float number!{1}Please re-enter a {0}", i_Message, Environment.NewLine));
                inputToConvert = Console.ReadLine();
            }

            return convertedInput;
        }

        /**
         * This method validates a int input
         */
        public static int CheckIntInput(string i_InputToCheck, string i_Message)
        {
            string inputToConvert = i_InputToCheck;
            int convertedInput = -1;

            while (!int.TryParse(inputToConvert, out convertedInput) || convertedInput < 0 || String.IsNullOrWhiteSpace(inputToConvert))
            {
                ClearConsoleAndWrite(string.Format("{0} must be a whole positive number!{1}Please re-enter a {0}", i_Message, Environment.NewLine));
                inputToConvert = Console.ReadLine();
            }

            return convertedInput;
        }

        /**
        * This method validates an enum value
        */
        public static int CheckEnumValue(Type i_TypeOfEnum, string i_UserInput)
        {
            string userInput = i_UserInput;
            int userInputAsInt;

            while (!(int.TryParse(userInput, out userInputAsInt) && (Enum.IsDefined(i_TypeOfEnum, userInputAsInt))))
            {
                Console.Clear();
                PrintEnum(i_TypeOfEnum);
                Console.WriteLine(string.Format("{0}Invalid choice, please enter a valid option", Environment.NewLine));
                userInput = Console.ReadLine();
            }

            return userInputAsInt;
        }
    }
}
