using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem
{
    interface IFlight
    {
        string FlightName
        {
            get;
            set;
        }
        Double Fare
        {
            get;
            set;
        }
        int IsSpecialFlight
        {
            get;
            set;
        }
        int FlightID
        {
            get;
            set;
        }
        String FromLocation
        {
            get;
            set;
        }
        String ToLocation
        {
            get;
            set;
        }



    }
    class Flight : IFlight
    {
        public int IsSpecialFlight;
        public String FlightName;
        public Double Fare;
        public int FlightID;
        public String FromLocation;
        public String ToLocation;

        int IFlight.FlightID
        {
            get
            {
                return FlightID;
            }

            set
            {
                FlightID = value;
            }
        }

        String IFlight.FromLocation
        {
            get
            {
                return FromLocation;
            }

            set
            {
                FromLocation = value;
            }
        }

        String IFlight.ToLocation
        {
            get
            {
                return ToLocation;
            }

            set
            {
                ToLocation = value;
            }
        }

        int IFlight.IsSpecialFlight
        {
            get
            {
                return IsSpecialFlight;
            }

            set
            {
                IsSpecialFlight = value;
            }
        }

        String IFlight.FlightName
        {
            get
            {
                return FlightName;
            }

            set
            {
                FlightName = value;
            }
        }

        double IFlight.Fare
        {
            get
            {
                return Fare;
            }

            set
            {
                Fare = value;
            }
        }

        

        public Flight(int FlightID, String FromLocation, String ToLocation, int IsSpecialFlight, String FlightName, Double Fare)
        {

            this.FlightID = FlightID;
            this.FromLocation = FromLocation;
            this.ToLocation = ToLocation;
            this.IsSpecialFlight = IsSpecialFlight;
            this.FlightName = FlightName;
            this.Fare = Fare;
        }
       
    }
}
