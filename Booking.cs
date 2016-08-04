using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Booking
    {
        public int booking_id, vehicle_id, noOfVehicle;
        public String address;

        public Booking(int booking_id, int vehicle_id, int noOfVehicle, String address)
        {
            this.booking_id = booking_id;
            this.vehicle_id = vehicle_id;
            this.noOfVehicle = noOfVehicle;
            this.address = address;
        }

    }
}
