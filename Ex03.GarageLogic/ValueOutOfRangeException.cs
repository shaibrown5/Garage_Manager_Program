using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        /**
         * Exception that is thrown when an input exceeds the allowed range
         * Prints the legal range 
         */
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) 
            : base(string.Format("Must be in the range {0} to {1}", i_MinValue, i_MaxValue))
        {
            this.m_MaxValue = i_MaxValue;
            this.m_MinValue = i_MinValue;
        }
    }
}
