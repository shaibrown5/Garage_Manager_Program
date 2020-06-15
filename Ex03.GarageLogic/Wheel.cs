using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufactureName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        
        /**
         * Getter for the current air pressure of the the wheel
         */
        public float CurrentTirePressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        /**
         * Getter and setter for maximum tire pressure
         */
        public float MaxTirePressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        /**
         * getter and setter for the wheel manufacturer
         */
        public string ManufactureName
        {
            get
            {
                return m_ManufactureName;
            }

            set
            {
                m_ManufactureName = value;
            }
        }

        /**
        * Constructor for the wheel that receives the maximum amount of air pressure
        * Initializes the maximum amount of air pressure
        */
        public Wheel(float i_MaxAirPressure)
        {
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        /**
         * This method receives a wanted amount of air pressure and adds it to the wheel         *
         * Throws ValueOutOfRangeException if amount exceeds the maximum tire pressure
         */
        public void Inflate(float i_AirToPump)
        {
            //if the air pressure given is negative
            if (i_AirToPump < 0)
            {
                throw new ArgumentException("Amount of air to pump can not be negative!");
            }
            //if the air pressure exceeds tha maximum allowed
            else if ((m_CurrentAirPressure + i_AirToPump) > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure);
            }
            else
            {
                m_CurrentAirPressure += i_AirToPump;
            }
        }

        /**
         * To string method that returns the wheel information
         */
        public override string ToString()
        {
            return string.Format(@"The wheel manufacturer is {0}
The recommended maximum air pressure is {1}
The current air pressure is {2}", m_ManufactureName, m_MaxAirPressure, m_CurrentAirPressure);
        }
    }
}
