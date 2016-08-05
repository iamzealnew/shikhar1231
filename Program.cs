using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        
         /* @author 
        Name : Shikhar Shrivastava
        Contact : 8962664191
        email : shikharshrivastava93@gmail.com
        
        */
        
        static List<Vehicle> lstvehicle;
        static void Main(string[] args)
        {
            lstvehicle = new List<Vehicle>();

            showMenu();

        }

        public static void showMenu()
        {
            Console.WriteLine();

            Console.WriteLine("Please make a choice : ");
            Console.WriteLine("Press 1 to make a new booking. ");
            Console.WriteLine("Press 2 to view Vehicle details and availablility. ");
            Console.WriteLine();

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:

                    Console.WriteLine("Please enter Vehicle Id");
                    int v_id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter no of vehicles required");
                    int noOfV = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter your address");
                    String address = Console.ReadLine();
                    Random rnd = new Random();
                    int b_id = rnd.Next(10000, 99999);

                    Booking newBooking = new Booking(b_id, v_id, noOfV, address);

                    int result = DBHelper.AddBooking(newBooking);
                    if (result == 1)
                    {

                        Console.WriteLine("Booking successfull with ID :" + b_id);
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong :( ");
                    }

                    showMenu();
                    break;

                case 2:

                    Console.WriteLine("Please enter the type of vehicle you want.");
                    String type = Console.ReadLine();
                    lstvehicle = DBHelper.ViewVehicle(type);

                    if (lstvehicle.Count > 0)
                    {
                        foreach (Vehicle objvehicle in lstvehicle)
                        {
                            Console.WriteLine("Vehicle Details");

                            Console.WriteLine("Vehicle Type:");
                            Console.WriteLine(objvehicle.type);
                            Console.WriteLine("Vehicle Availablility:");
                            Console.WriteLine(objvehicle.available);
                            Console.WriteLine("Vehicle ID");
                            Console.WriteLine(objvehicle.vehicle_id);
                            

                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again");

                    }

                    showMenu();
                    break;


            }
        }
    }
}
