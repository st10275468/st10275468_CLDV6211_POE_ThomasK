using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class Products
    {
        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Catagory { get; set; }
        public string Availability {  get; set; }

        public int insert_product(Products p)
        {
            try
            {
                string sql = "INSERT INTO Products (ProductName, Price, Catagory, Availability) VALUES (@Name, @Price, @Catagory, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Catagory", p.Catagory);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Products> GetProducts()
        {
            List<Products> products = new List<Products>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    Products product = new Products();
                    product.ProductID = Convert.ToInt32(r["ProductID"]);
                    product.Name = r["ProductName"].ToString();
                    product.Price = r["Price"].ToString();
                    product.Catagory = r["Catagory"].ToString();
                    product.Availability = r["Availability"].ToString();

                    products.Add(product);
                }
            }
            return products;
        }
    }
}
