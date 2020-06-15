using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        //Dictionary that holds all vehicles in the garage. Key: license, Value: vehicle
        private readonly Dictionary<string, Vehicle> r_VehiclesInGarage;

        /**
         * Constructor for garage, creates new dictionary to hold the vehicles in the garage
         */
        public Garage()
        {
            this.r_VehiclesInGarage = new Dictionary<string, Vehicle>();
        }

        /**
         * This method retrieves a vehicle from the garage by license number
         * Throw
         * s KeyNotFoundException if it is not in the garage
         */
        public Vehicle GetVehicleByLicense(string i_LicenseOfVehicle)
        {
            if (!IsVehicleInGarage(i_LicenseOfVehicle))
            {
                throw new KeyNotFoundException("The vehicle is not in the Garage");
            }
            return r_VehiclesInGarage[i_LicenseOfVehicle];
        }

        /**
         * This method checks if the wanted Vehicle is in the Garage
         * returns true or false respectively
         */
        public bool IsVehicleInGarage(string i_LicenseOfVehicle)
        {
            return r_VehiclesInGarage.ContainsKey(i_LicenseOfVehicle);
        }

        /**
         * This method adds a vehicle to the garage
         * If the vehicle already exists - changes its status to in repair
         * Throws ArgumentException if vehicle is already in the garage
         */
        public void AddVehicleToGarage(Vehicle i_VehicleToAdd)
        {
            if (IsVehicleInGarage(i_VehicleToAdd.LicenseNumber))
            {
                //changes the vehicles status to "In Repair"
                r_VehiclesInGarage[i_VehicleToAdd.LicenseNumber].VehicleGarageStatus = Vehicle.eVehicleGarageStatus.InRepair;
                throw new ArgumentException("The vehicle is already in the garage");
            }
            
            r_VehiclesInGarage.Add(i_VehicleToAdd.LicenseNumber, i_VehicleToAdd);
        }

        /**
         * This method returns a list of all license numbers currently in the garage
         * Option to filter wanted license numbers by their status in garage
         */
        public List<string> GetLicenseList(params Vehicle.eVehicleGarageStatus[] i_VehicleStatusFilter)
        {
            //throws ArgumentNullException
            List<String> LicenseList = r_VehiclesInGarage.Keys.ToList();

            // if the user input a filter
            if (i_VehicleStatusFilter != null && i_VehicleStatusFilter.Length != 0)
            {
                
                foreach (KeyValuePair<string, Vehicle> vehicle in r_VehiclesInGarage)
                { 
                    if (!vehicle.Value.VehicleGarageStatus.Equals(i_VehicleStatusFilter[0])) 
                    { 
                        LicenseList.Remove(vehicle.Value.LicenseNumber);
                    }
                }
                
            }

            return LicenseList;
        }

        /**
         * This method changes the wanted vehicles garage status
         * Throws ArgumentException if vehicle is not found
         */
        public void ChangeVehicleStatus(string i_LicenseNumber, Vehicle.eVehicleGarageStatus i_NewGarageStatus)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }

            r_VehiclesInGarage[i_LicenseNumber].VehicleGarageStatus = i_NewGarageStatus;
        }

        /**
         * This method inflates the wheels to the maximum air pressure
         * Throws ArgumentException if car is not in the garage
         */
        public void InflateWheelToMax(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }

            foreach (Wheel wheel in r_VehiclesInGarage[i_LicenseNumber].Wheels)
            {
                wheel.Inflate(wheel.MaxTirePressure - wheel.CurrentTirePressure);
            }
        }

        /**
         * This method refuels a fuel based vehicle
         * Throws ArgumentException if car is not in garage or car is electric based
         */
        public void RefuelVehicle(string i_LicenseNumber, Fuel.eFuelType i_FuelType, float i_AmountToFill)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }

            Vehicle vehicle = r_VehiclesInGarage[i_LicenseNumber];
            if (!(vehicle.EnergySource is Fuel))
            {
                throw new ArgumentException("The Vehicle is not a fuel based vehicle ");
            }

            Fuel tank = (Fuel)vehicle.EnergySource;
            tank.RefuelFuel(i_FuelType, i_AmountToFill);
            vehicle.SetEnergyPercentage();
        }

        /**
         * This method recharges an electric based vehicle
         * Throws ArgumentException if car is not in garage or car is fuel based
         */
        public void RechargeVehicle(string i_LicenseNumber, float i_AmountToFill)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("The vehicle is not in the garage");
            }

            Vehicle vehicle = r_VehiclesInGarage[i_LicenseNumber];
            if (!(vehicle.EnergySource is Electric))
            {
                throw new ArgumentException("The Vehicle is not a fuel based vehicle");
            }

            Electric battery = (Electric)vehicle.EnergySource;
            battery.ChargeBatery(i_AmountToFill);
            vehicle.SetEnergyPercentage();
        }
    }
}
