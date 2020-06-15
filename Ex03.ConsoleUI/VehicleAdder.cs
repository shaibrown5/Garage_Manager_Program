using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class VehicleAdder
    {
        private readonly Garage r_Garage;
        private readonly UniqueVehicleInfoStation r_UniqueVehicleInfoStation;

        /**
         * Constructor method
         * Implements the garage.
         */
        public VehicleAdder(Garage i_Garage)
        {
            this.r_Garage = i_Garage;
            this.r_UniqueVehicleInfoStation = new UniqueVehicleInfoStation(r_Garage);
        }

        /**
         * This method gets the vehicles details from user
         * Catches ArgumentException
         */
        public Vehicle GetVehicleDetailsFromUser()
        {
            Vehicle vehicleToAdd = null;

            try
            {
                vehicleToAdd = VehicleBuilder.MakeVehicle(getVehicleType());
                vehicleToAdd.LicenseNumber = getLicenseNumber();
                r_Garage.AddVehicleToGarage(vehicleToAdd);
                vehicleToAdd = fillDetails(vehicleToAdd);
                ConsoleUtils.ClearConsoleAndWrite("Vehicle added successfully!");
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }
            catch (ArgumentException ae)
            {
                ConsoleUtils.ClearConsoleAndWrite(ae.Message);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
            }

            return vehicleToAdd;
        }

        /**
         * This method gets license number from the user
         */
        private string getLicenseNumber()
        {
            ConsoleUtils.ClearConsoleAndWrite("Enter the license number of the vehicle");
            string userInput = Console.ReadLine();
            userInput = ConsoleUtils.CheckStringInput(userInput, "License number");

            return userInput;
        }

        /**
         * This method fills the vehicle properties
         */
        private Vehicle fillDetails(Vehicle i_VehicleToFill)
        {
            i_VehicleToFill.ModelName = getVehicleModel();
            i_VehicleToFill.OwnerName = getOwnerName();
            i_VehicleToFill.OwnerPhoneNumber = getOwnerPhoneNum(i_VehicleToFill.OwnerName);
            getWheelManufacturer(i_VehicleToFill.Wheels);
            getCurrentWheelPressure(i_VehicleToFill.Wheels);
            getCurrentAmountOfEnergy(i_VehicleToFill.EnergySource);
            i_VehicleToFill.SetEnergyPercentage();
            i_VehicleToFill = getVehicleTypeDetails(i_VehicleToFill);

            return i_VehicleToFill;
        }

        /**
         * This method receives a vehicle and sends it to the relevant details provider
         */
        private Vehicle getVehicleTypeDetails(Vehicle i_Vehicle)
        {
            Vehicle updatedVehicle = r_UniqueVehicleInfoStation.GetUniqueInfo(i_Vehicle);

            return updatedVehicle;
        }

        /**
         * This method gets the vehicles current amount of energy.
         */
        private void getCurrentAmountOfEnergy(EnergySource i_EnergySource)
        {
            string message = (i_EnergySource is Fuel) ? "fuel amount" : "battery time left (in hours)";
            ConsoleUtils.ClearConsoleAndWrite(string.Format("Enter the current {0}", message));
            string userInput = Console.ReadLine();
            float convertedInput = ConsoleUtils.CheckFloatInput(userInput, "Energy amount");
            try
            {
                i_EnergySource.RefuelEnergy(convertedInput);
            }
            catch (Exception e)
            {
                ConsoleUtils.ClearConsoleAndWrite(e.Message);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                getCurrentAmountOfEnergy(i_EnergySource);
            }
        }

        /**
         * This methods gets the current wheel pressure from the user
         */
        private void getCurrentWheelPressure(List<Wheel> i_Wheels)
        {
            ConsoleUtils.ClearConsoleAndWrite("Enter the current pressure of the wheels");
            string userInput= Console.ReadLine();
            float convertedAirPressure = ConsoleUtils.CheckFloatInput(userInput, "Tire Pressure");
            try
            {
                foreach (Wheel wheel in i_Wheels)
                {
                    wheel.Inflate(convertedAirPressure);
                }
            }
            catch (ValueOutOfRangeException voore)
            {
                ConsoleUtils.ClearConsoleAndWrite(voore.Message);
                Console.WriteLine("Press any key to continue");
                Console.ReadLine();
                getCurrentWheelPressure(i_Wheels);
            }
        }

        /**
         * This method gets the name of the wheels manufacturer
         */
        private void getWheelManufacturer(List<Wheel> i_WheelList)
        {
            ConsoleUtils.ClearConsoleAndWrite("Enter the manufacturer of the wheels");
            string wheelManufacturer = ConsoleUtils.CheckStringInput(Console.ReadLine(), "Wheel manufacturer");
            foreach (Wheel wheel in i_WheelList)
            {
                wheel.ManufactureName = wheelManufacturer;
            }
        }

        /**
         * This method gets the owners phone number
         */
        private string getOwnerPhoneNum(string i_OwnerName)
        {
            string ownerPhoneNum = "";
            ConsoleUtils.ClearConsoleAndWrite(string.Format("Enter {0}'s phone number", i_OwnerName));
            ownerPhoneNum = Console.ReadLine();
            ownerPhoneNum = "" + ConsoleUtils.CheckIntInput(ownerPhoneNum, "Phone number");

            return ownerPhoneNum;
        }

        /**
         * This method gets the owners name
         */
        private string getOwnerName()
        {
            string ownerName = "";
            ConsoleUtils.ClearConsoleAndWrite("Enter the owners name of the vehicle");
            ownerName = Console.ReadLine();
            ownerName = ConsoleUtils.CheckStringInput(ownerName, "Owners Name");

            return ownerName;
        }

        /**
         * This method gets the model name of the vehicle
         */
        private string getVehicleModel()
        {
            string model = "";
            ConsoleUtils.ClearConsoleAndWrite("Enter the model of the vehicle");
            model = Console.ReadLine();
            model = ConsoleUtils.CheckStringInput(model, "Model type");

            return model;
        }

        /**
         * This methods gets the vehicle type from the user
         */
        private VehicleBuilder.eVehicleType getVehicleType()
        {
            ConsoleUtils.ClearConsoleAndWrite("Pick a vehicle type:");
            ConsoleUtils.PrintEnum(typeof(VehicleBuilder.eVehicleType));
            string userInput = Console.ReadLine();

            return (VehicleBuilder.eVehicleType)ConsoleUtils.CheckEnumValue(typeof(VehicleBuilder.eVehicleType), userInput);
        }
    }
}
