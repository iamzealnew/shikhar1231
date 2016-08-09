using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem
{
    class Program
    {
        public static List<Flight> flightList;
        static void Main(string[] args)
        {

            flightList = new List<Flight>();
            showMenu();

        }

        static void showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please make a choice : ");
            Console.WriteLine("Press 1 to View Flight Details ");
            Console.WriteLine("Press 2 to Delete Flight ");
            Console.WriteLine("Press 3 to Exit ");

            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:

                    Console.WriteLine("Please enter Location Name :");
                    String locationName = Console.ReadLine();
                    DBHelper db = new DBHelper();
                    flightList = db.getFlight(locationName);

                    if (flightList.Count > 0)
                    {
                        for (int i = 0; i < flightList.Count; i++)
                        {
                            Console.WriteLine("Flight ID is : " + flightList[i].FlightID);
                            Console.WriteLine("Flight Name is : " + flightList[i].FlightName);
                            Console.WriteLine("Flight is from location : " + flightList[i].FromLocation);
                            Console.WriteLine("Flight is to location : " + flightList[i].ToLocation);
                            if (flightList[i].IsSpecialFlight == 1)
                            {
                                Console.WriteLine("Yay...this is a special flight. You get 10% discount");

                                double Fare = flightList[i].Fare;

                                double disFare = Fare;
                                double dis = (Fare * 0.1);
                                Console.WriteLine("Flight Fare is : " + (Fare - dis));


                            }
                            else
                                Console.WriteLine("Flight Fare is : " + flightList[i].Fare);

                        }
                    }
                    else
                        Console.WriteLine("No flights found..");


                    showMenu();
                    break;
                case 2:

                    Console.WriteLine("Enter the id to delete the flight : ");
                    int delID = int.Parse(Console.ReadLine());

                    DBHelper db1 = new DBHelper();
                    Console.WriteLine("Are you absolutely sure? (y/n) ");
                    String choice = Console.ReadLine();
                    if (choice.Equals("y"))
                    {
                        int i = db1.delFlight(delID);
                        if (i==1)
                        {
                            Console.WriteLine("Flight deletion successful.");
                        }
                        else
                            Console.WriteLine("Flight deletion was not successful/cancelled.");
                    }
                    showMenu();
                    break;
                case 3:
                    break;


            }
        }
    }
}
