using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private const int k_NumberOfWheels = 2;
        private const int k_MaxTirePressure = 30;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        /**
         * Getter setter for the volume of the engine
         */
        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }

            set
            {
                m_EngineVolume = value;
            }
        }

        /**
         * Getter setter for the license type
         */
        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }

            set
            {
                m_LicenseType = value;
            }
        }

        /**
         * constructor for generic motorcycle vehicle
         * Initializes a list of the motorcycles wheels
         */
        protected Motorcycle()
        {
            Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaxTirePressure));
            }

            createUniqueInfoList();
        } 
        
        /**
         * This method returns a list of motorcycle unique info
         */
        private void createUniqueInfoList()
        {
            List<VehicleUniqueInfo> motorcycleUniqueInfo = new List<VehicleUniqueInfo>();
            motorcycleUniqueInfo.Add(new VehicleUniqueInfo(typeof(eLicenseType), "type of license"));
            motorcycleUniqueInfo.Add(new VehicleUniqueInfo(typeof(int), "engine volume"));
            base.SetUniqueInfoList(motorcycleUniqueInfo);
        }

        /**
         * This method overrides the base's method
         * Receives an array of answers and updates the fields accordingly
         */
        public override void UpdateUniqueFields(List<object> i_ListOfUniqueInfoAnswers)
        {
            m_LicenseType = (eLicenseType)int.Parse((string)i_ListOfUniqueInfoAnswers[0]);
            m_EngineVolume = int.Parse((string)i_ListOfUniqueInfoAnswers[1]);
        }

        /**
         * Enum list of the possible license types
         */
        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B = 4
        }

        /**
         * To string method that prints the vehicles properties as well as motorcycle relevant properties
         */
        public override string ToString()
        {
            return string.Format(@"{0}
The number of wheels is {1}
The license type is {2}
The engine volume is {3}", base.ToString(), k_NumberOfWheels, m_LicenseType, m_EngineVolume);
        }
    }
}