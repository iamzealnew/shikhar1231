using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ConsoleApplication3
{
    class DBHelper
    {
        
         /* @author 
        Name : Shikhar Shrivastava
        Contact : 8962664191
        email : shikharshrivastava93@gmail.com
        
        */

        static SqlConnection cn;
        static SqlCommand cmd;

        /// <summary>
        /// Creates a Connection with the Database
        /// </summary>
        /// <returns></returns>
        static SqlConnection GetConnection()
        {
                             
            string conStr = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=test;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            try
            {
                if (!string.IsNullOrEmpty(conStr))
                {
                    return new SqlConnection(conStr);
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public static int AddBooking(Booking objBooking)
        {
            int countAvailable=0;

            cn = GetConnection();
            if (cn.State == System.Data.ConnectionState.Closed)
            {
                cn.Open();
            }

            try
            {
                SqlCommand checker = new SqlCommand("select available from tbl_vehicle where vehicle_id = " + objBooking.vehicle_id + ";", cn);
                SqlDataReader checkerRead = checker.ExecuteReader();

                while (checkerRead.Read())
                {
                    countAvailable = checkerRead.GetInt32(0);
                }
                checkerRead.Close();
                cn.Close();
                cn.Open();
                
                

            }
            catch(Exception e) {

                Console.WriteLine("In catch 1 :"+e);
                cn.Close();
                cn.Open();

            }

            cmd = new SqlCommand("add_booking", cn); cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@address", objBooking.address));
            cmd.Parameters.Add(new SqlParameter("@num", objBooking.noOfVehicle));
            cmd.Parameters.Add(new SqlParameter("@vehicle_id", objBooking.vehicle_id));
            cmd.Parameters.Add(new SqlParameter("@booking_id", objBooking.booking_id));
            int i;
            if (countAvailable > objBooking.noOfVehicle)
            {
                i = cmd.ExecuteNonQuery();
            } else  i = 0;
            cn.Close();
            if (i > 0)
            {
                return 1;
            }
            return 0;
        }

        public static List<Vehicle> ViewVehicle(String type)
        {

            List<Vehicle> lstStudent = new List<Vehicle>();
            cn = GetConnection();

                if (cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
            

            cmd = new SqlCommand("view_vehicle", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@type", type));
            SqlDataReader stdReader = cmd.ExecuteReader();
            if (stdReader.HasRows)
            {
                while (stdReader.Read())
                {
                    Vehicle objVehicle = new Vehicle();
                    objVehicle.type = stdReader["Vehicle_type"].ToString();
                    objVehicle.vehicle_id = Convert.ToInt32(stdReader["vehicle_id"].ToString());
                    objVehicle.available = Convert.ToInt32(stdReader["available"].ToString());

                    lstStudent.Add(objVehicle);

                }


            }
            else
            {
                Console.WriteLine("nothing found");
                
            }

            return lstStudent;


        }



    }
}
