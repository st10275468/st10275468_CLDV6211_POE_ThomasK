using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using st10275468_CLDV6211_POE_ThomasK.Controllers;
using System.Data.SqlClient;
using System.Numerics;
using System.Xml.Linq;
namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class Products
    {
        public Products() { }
        
        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);
        
        

        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Catagory { get; set; }
        public int Availability {  get; set; }

        public int? UserID { get; set; }


        public int insert_product(Products p, int? UserID)
        {

            string sql = "INSERT INTO Products (ProductName, Price, Catagory, Availability, UserID) VALUES (@Name, @Price, @Catagory, @Availability, @UserID)";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {

                        cmd.Parameters.AddWithValue("@Name", p.Name);
                        cmd.Parameters.AddWithValue("@Price", p.Price);
                        cmd.Parameters.AddWithValue("@Catagory", p.Catagory);
                        cmd.Parameters.AddWithValue("@Availability", p.Availability);
                        cmd.Parameters.AddWithValue("@UserID", UserID);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        con.Close();
                        return rowsAffected;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"SQL Error: {ex.Message}");

                throw ex;

            }
            catch (Exception ex)
            {
               
                Console.Error.WriteLine($"Error: {ex.Message}");
                throw;
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
                    product.Availability = Convert.ToInt32(r["Availability"]);

                    products.Add(product);
                }
            }
            return products;
        }
    }
}
