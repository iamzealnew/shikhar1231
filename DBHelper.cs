using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagementSystem
{
    class DBHelper
    {
        static SqlConnection cn;
        static SqlCommand cmd;

        static SqlConnection getConnection()
        {

            String conStr = @"Data Source=inchnilpdb02\mssqlserver1;Initial Catalog=CHN12_MMS73_TEST;Integrated Security=False;User ID=mms73user;Password=mms73user;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                if (!String.IsNullOrWhiteSpace(conStr))
                    return new SqlConnection(conStr);
                else
                    return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Raised <id-1>: " + e.ToString());
            }

            return null;
        }

        public List<Flight> getFlight(String locationName)
        {
            List<Flight> flightListdb = new List<Flight>();
            try
            {
                cn = getConnection();
                cn.Open();
                SqlCommand cmd1 = new SqlCommand("getLocationName1213929", cn);
                cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr1 = cmd1.ExecuteReader();
                
                SortedList<int , String> s1 = new SortedList<int , String>();

                while (dr1.Read())
                {
                    s1.Add(int.Parse(dr1.GetValue(0).ToString()), dr1.GetValue(1).ToString());
                    
                }
                dr1.Close();

                cmd = new SqlCommand("getFlight1213929", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@location", locationName));
                SqlDataReader dr = cmd.ExecuteReader();

                
               
               // Console.WriteLine("ID VALUE IS" + st1);
                while (dr.Read())
                {                                      
                    int fID = int.Parse(dr.GetValue(0).ToString());
                    string fName = dr.GetValue(1).ToString();
                    int fL = int.Parse(dr.GetValue(2).ToString());
                    int tL = int.Parse(dr.GetValue(3).ToString());
                    string fL1;
                    bool checkForFrom = s1.TryGetValue(fL, out fL1);
                    string tL1;
                    bool checkFroTo = s1.TryGetValue(tL, out tL1);
                    int isSL = int.Parse(dr.GetValue(4).ToString());
                    double fare = double.Parse(dr.GetValue(5).ToString());
                    Flight newFlight = new Flight(fID, fL1, tL1, isSL, fName, fare);
                    flightListdb.Add(newFlight);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return flightListdb;

        }


        public int delFlight(int flightID)
        {
            try
            {
                cn = getConnection();
                cn.Open();
                cmd = new SqlCommand("delFlight1213929", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", flightID));
                int hasExecuted = cmd.ExecuteNonQuery();
                return hasExecuted;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Occured while deleting");
                return 0;
            }
            

        }
    }
}

