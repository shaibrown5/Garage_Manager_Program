using System;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_MaxEnergy;
        private float m_CurrentEnergyAmount = 0;
        private eEnergyType m_EnergyType;

        /**
         * Getter for the current amount of energy
         */
        public float CurrentEnergyAmount
        {
            get
            {
                return m_CurrentEnergyAmount;
            }
        }

        /**
         * Getter setter for the max amount of energy
         */
        public float MaxEnergy
        {
            get
            {
                return m_MaxEnergy;
            }

            set
            {
                m_MaxEnergy = value;
            }
        }

        /**
         * Getter setter for EnergyType
         */
        public eEnergyType EnergyType
        {
            get
            {
                return m_EnergyType;
            }

            set
            {
                m_EnergyType = value;
            }
        }

        /**
         * constructor for energy source
         * Initializes maximum amount of energy
         */
        protected EnergySource(float i_MaxAmountEnergy)
        {
            this.m_MaxEnergy = i_MaxAmountEnergy;
        }

        /**
         * Enum list of the types of energy sources
         */
        public enum eEnergyType
        {
            Fuel = 1,
            Electric = 2
        }

        /**
         * This method refuels the energy with the given amount to add
         * If the amount is negative throws ArgumentException
         * If adding amount is larger than the maximum, throws ValueOutOfRange
         */
        public void RefuelEnergy(float i_AmountToFill)
        {
            //if the amount to fill given is negative
            if (i_AmountToFill < 0)
            {
                throw new ArgumentException("Amount to fill can not be negative!");
            }
            //if the air pressure exceeds tha maximum allowed
            else if ((m_CurrentEnergyAmount + i_AmountToFill) > m_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, m_MaxEnergy);
            }
            else
            {
                m_CurrentEnergyAmount += i_AmountToFill;
            }
        }

        /**
         * To string method that returns energy source properties
         */
        public override string ToString()
        {
            return string.Format(@"The energy type is {0}
The maximum amount of energy is {1}
The current amount of energy is {2}", m_EnergyType, m_MaxEnergy, m_CurrentEnergyAmount);
        }
    }
}