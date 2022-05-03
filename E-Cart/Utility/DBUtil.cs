using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace E_Cart.Utility
{
    /// <summary>
    /// This class contains methods to access database
    /// </summary>
    public class DBUtil
    {
     
        String ConnectionString;

        public DBUtil(String connectionString) {
            this.ConnectionString = connectionString;
        }


        /// <summary>
        /// This method executes a parameterless procedure in database and returns datatable
        /// </summary>
        /// <param name="MySPName">Procedure Name</param>
        /// <returns>Datatable</returns>
        public DataTable CallStoredProcedure(string procedureName)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(procedureName,con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
            }
            return dt;
        }


        /// <summary>
        /// this method execiutes a query in database and returns the Data in a Datatable
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <returns>Datatable</returns>
        public DataTable ExecuteQuery(String query) {

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(this.ConnectionString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        //cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
            }

            return dt;

        }

    }
}
