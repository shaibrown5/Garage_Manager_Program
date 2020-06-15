using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private eCarColour m_ColourOfCar;
        private eNumOfDoors m_NumberOfDoors;
        private const int k_NumberOfWheels = 4;
        private const int k_MaxTirePressure = 32;

        /**
         * Getter setter for the number of doors on the car
         */
        public eNumOfDoors DoorNum
        {
            get
            {
                return m_NumberOfDoors;
            }

            set
            {
                m_NumberOfDoors = value;
            }
        }

        /**
         * Getter setter for the colour of the car
         */
        public eCarColour Colour
        {
            get
            {
                return m_ColourOfCar;
            }

            set
            {
                m_ColourOfCar = value;
            }
        }

        /**
         * Constructor for car type vehicle
         * Initializes the wheels list
         */
        protected Car()
        {
            Wheels = new List<Wheel>(k_NumberOfWheels);

            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                Wheels.Add(new Wheel(k_MaxTirePressure));
            }

            createUniqueInfoList();
        }

        /**
         * This method returns a list of car unique info
         */
        private void createUniqueInfoList()
        {
            List<VehicleUniqueInfo> carUniqueInfo = new List<VehicleUniqueInfo>();
            carUniqueInfo.Add(new VehicleUniqueInfo(typeof(eCarColour), "car colour"));
            carUniqueInfo.Add(new VehicleUniqueInfo(typeof(eNumOfDoors), "number of doors"));
            base.SetUniqueInfoList(carUniqueInfo);
        }

        /**
         * This method overrides the base's method
         * Receives an array of answers and updates the fields accordingly
         */
        public override void UpdateUniqueFields(List<object> i_ListOfUniqueInfoAnswers)
        {
            m_ColourOfCar = (eCarColour)int.Parse((string)i_ListOfUniqueInfoAnswers[0]);
            m_NumberOfDoors = (eNumOfDoors)int.Parse((string)i_ListOfUniqueInfoAnswers[1]);
        }

        /**
         * Enum list of the car colours
         */
        public enum eCarColour
        {
            Red = 1,
            White = 2,
            Black = 3,
            Silver = 4,
        }

        /**
         * Enum list of the number of doors available on a car
         */
        public enum eNumOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        /**
         * To string method that returns vehicle relevant information
         */
        public override string ToString()
        {
            return string.Format(@"{0}
The number of wheels is {1}
The colour of the car is {2}
The number of doors are {3}", base.ToString(), k_NumberOfWheels, m_ColourOfCar, m_NumberOfDoors);
        }
    }
}
