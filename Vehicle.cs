using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Vehicle
    {
         /* @author 
        Name : Shikhar Shrivastava
        Contact : 8962664191
        email : shikharshrivastava93@gmail.com
        
        */
        
        public int vehicle_id, available;
        public String type;

        public Vehicle(int vehicle_id, int available, String type)
        {
            this.vehicle_id = vehicle_id;
            this.available = available;
            this.type = type;

        }

        public Vehicle()
        {

        }
    }
}
