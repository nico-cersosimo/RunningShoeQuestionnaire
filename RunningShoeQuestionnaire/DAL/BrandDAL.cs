using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunningShoeQuestionaire.Models;
using System.Data.SqlClient;

namespace RunningShoeQuestionaire.DAL
{
    public class BrandDAL : IBrandDAL
    {
        private string ConnString;
        Brand brand = new Brand();

        public BrandDAL(string connString)
        {
            ConnString = connString;
        }

        public List<Brand> GetAllBrands()
        {
            List<Brand> output = new List<Brand>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(ConnString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM brand";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        brand.Name = Convert.ToString(reader["brandName"]);
                        brand.AvgCost = Convert.ToInt32(reader["avgCost"]);

                        output.Add(brand);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            brand.Brands = output;
            return output;
        }
    }
}
