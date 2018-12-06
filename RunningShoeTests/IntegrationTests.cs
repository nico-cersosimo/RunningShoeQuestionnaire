using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningShoeQuestionaire.DAL;
using RunningShoeQuestionaire.Models;

namespace RunningShoeTests
{
    [TestClass]
    public class IntegrationTests
    {
        private TransactionScope tran;
        private string connString = @"Data Source =.\SQLEXPRESS;Initial Catalog=RunningShoe; Integrated Security=True";

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO brand VALUES ('Nico Shoes','1')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAllBrandsTest()
        {
            IBrandDAL brandDAL = new BrandDAL(connString);

            List<Brand> brands = brandDAL.GetAllBrands();

            Assert.IsNotNull(brands);

            List<string> names = new List<string>();
            foreach (Brand brand in brands)
            {
                names.Add(brand.Name);
            }
            CollectionAssert.Contains(names, "Nico Shoes");
        }
    }
}
