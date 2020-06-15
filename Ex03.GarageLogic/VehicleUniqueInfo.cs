using System;

namespace Ex03.GarageLogic
{
    public class VehicleUniqueInfo
    {
        private readonly Type r_Type;
        private readonly string r_Message;

        /**
         * This method is the constructor for the VehicleUniqueInfo
         */
        public VehicleUniqueInfo(Type i_Type, string i_Message)
        {
            r_Type = i_Type;
            r_Message = i_Message;
        }

        /**
         * Getter setter for the type fo information
         */
        public Type Type
        {
            get
            {
                return r_Type;
            }
        }

        /**
         * getter for the the message of the info
         */
        public string Message
        {
            get
            {
                return r_Message;
            }
        }
    }
}
