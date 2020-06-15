using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 16;
        private const int k_MaxTirePressure = 28;
        private bool m_CarryingDangerousMaterials;
        private float m_VolumeOfCargo;

        /**
         * Getter setter for carrying dangerous materials value
         */
        public bool CarryingDangerousMaterials
        {
            get
            {
                return m_CarryingDangerousMaterials;
            }

            set
            {
                m_CarryingDangerousMaterials = value;
            }
        }

        /**
         * Getter setter for the volume of cargo
         */
        public float VolumeOfCargo
        {
            get
            {
                return m_VolumeOfCargo;
            }

            set
            {
                m_VolumeOfCargo = value;
            }
        }

        /**
         * Constructor for Truck object
         * initializes the list of the trucks wheels
         */
        protected Truck()
        {
            Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaxTirePressure));
            }

            createUniqueInfoList();
        }

        /**
         * This method returns a list of truck unique info
         */
        private void createUniqueInfoList()
        {
            List<VehicleUniqueInfo> truckUniqueInfo = new List<VehicleUniqueInfo>();
            truckUniqueInfo.Add(new VehicleUniqueInfo(typeof(bool), "carrying dangerous material"));
            truckUniqueInfo.Add(new VehicleUniqueInfo(typeof(float), "volume of cargo"));
            base.SetUniqueInfoList(truckUniqueInfo);
        }

        /**
         * This method overrides the base's method
         * Receives an array of answers and updates the fields accordingly
         */
        public override void UpdateUniqueFields(List<object> i_ListOfUniqueInfoAnswers)
        {
            m_CarryingDangerousMaterials = (bool)i_ListOfUniqueInfoAnswers[0];
            m_VolumeOfCargo = float.Parse((string)i_ListOfUniqueInfoAnswers[1]);
        }

        /**
         * To string method that prints the vehicles details as well as truck relevant details 
         */
        public override string ToString()
        {
            string dangerousMaterialMessage = m_CarryingDangerousMaterials ? "is" : "is not";
            return string.Format(@"{0}
The number of wheels is {1}
The volume of cargo is {2}
The truck {3} carrying dangerous materials", base.ToString(), k_NumberOfWheels, m_VolumeOfCargo, dangerousMaterialMessage);
        }
    }
}
