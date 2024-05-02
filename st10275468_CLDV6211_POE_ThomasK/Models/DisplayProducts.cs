using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class DisplayProducts
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Catagory { get; set; }
        public bool Availability { get; set; }

        public DisplayProducts() { }


        public DisplayProducts(int fid, string fname, decimal fprice, string fcatagory, bool favailability)
        {
            ProductID = fid;
            ProductName = fname;
            Price = fprice;
            Catagory = fcatagory;
            Availability = favailability;
         }
        public static List<DisplayProducts> SelectProducts()

        {
            List<DisplayProducts> products = new List<DisplayProducts>();

            string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, Price, Catagory, Availability FROM Products";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DisplayProducts product = new DisplayProducts();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName =Convert.ToString(reader["ProductName"]);
                    product.Price = Convert.ToDecimal(reader["Price"]);
                    product.Catagory = Convert.ToString(reader["Catagory"]);
                    product.Availability = Convert.ToBoolean(reader["Availability"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
    }
}
