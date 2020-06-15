using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        // vehicle properties
        private string m_ModelName = string.Empty;
        private string m_LicenseNumber = string.Empty;
        private float m_EnergyPercentage = 0;
        private List<Wheel> m_Wheels = new List<Wheel>();
        private EnergySource m_EnergySource = null;
        // vehicle in garage properties
        private string m_OwnerName = string.Empty;
        private string m_OwnerPhoneNum = string.Empty;
        private eVehicleGarageStatus m_VehicleGarageStatus;
        private List<VehicleUniqueInfo> m_UniqueInfoList;

        /**
         * Getter for the list of unique vehicle information
         */
        public List<VehicleUniqueInfo> UniqueInfoList
        {
            get
            {
                return m_UniqueInfoList;
            }
        }

        /**
         * Constructor method
         * Initializes the vehicles repair status as " in repair"
         */
        protected Vehicle()
        {
            this.m_VehicleGarageStatus = eVehicleGarageStatus.InRepair;
        }

        /**
         * Sets the unique info list according to the type of vehicle
         */
        public void SetUniqueInfoList(List<VehicleUniqueInfo> i_UniqueInfoList)
        {
            m_UniqueInfoList = i_UniqueInfoList;
        }
        
        /**
         * Getter / setter for the model name
         */
        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        /**
         * Getter / setter for the license number
         */
        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            set
            {
                m_LicenseNumber = value;
            }
        }

        /**
         * Getter for the remaining amount of energy percent
         */
        public float RemainingEnergyPercentage
        {
            get
            {
                return this.m_EnergyPercentage;
            }
        }

        /**
         * This method calculates the amount of remaining energy percentage
         */
        public void SetEnergyPercentage()
        {
            m_EnergyPercentage = (float)((m_EnergySource.CurrentEnergyAmount / m_EnergySource.MaxEnergy) * 100);
        }

        /**
         * Getter / setter for the vehicles wheels
         */
        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }

            set
            {
                m_Wheels = value;
            }
        }

        /**
         * Getter / setter for the energy source
         */
        public EnergySource EnergySource
        {
            get
            {
                return m_EnergySource;
            }

            set
            {
                m_EnergySource = value;
            }
        }

        /**
         * Getter / setter for the owners name
         */
        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }

            set
            {
                m_OwnerName = value;
            }
        }

        /**
         * Getter / setter for the owners phone number
         */
        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNum;
            }

            set
            {
                m_OwnerPhoneNum = value;
            }
        }

        /**
         * This is a Virtual method used to update unique vehicle information
         */
        public virtual void  UpdateUniqueFields(List<object> i_ListOfObjects){}

        /**
         * Getter / setter for the model name
         */
        public eVehicleGarageStatus VehicleGarageStatus
        {
            get
            {
                return m_VehicleGarageStatus;
            }

            set
            {
                m_VehicleGarageStatus = value;
            }
        }

        /**
         * Enum that lists the possible statuses of a vehicle in the garage
         */
        public enum eVehicleGarageStatus
        {
            InRepair = 1,
            Repaired = 2,
            PayedFor = 3
        }

        /**
         * To string method tha prints the vehicles properties
         */
        public override string ToString()
        {
            return string.Format(@"The vehicle's license number is {0}
The vehicle's model is {1}
The owner's name is {2}
{2}'s phone number is {3}
The vehicle's status in the garage is {4}
{5}
The energy percentage is {6}%
{7}",
                m_LicenseNumber, 
                m_ModelName, 
                m_OwnerName, 
                m_OwnerPhoneNum, 
                m_VehicleGarageStatus,
                m_EnergySource.ToString(),
                m_EnergyPercentage,
                m_Wheels[0].ToString());
        }
    }
}
