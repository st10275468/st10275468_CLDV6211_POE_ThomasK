using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class MyProductsOrders
    {
        public MyProductsOrders() { }
        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }

        public static List<MyProductsOrders> GetMyProductsOrders(int? userID)
        {
            List<MyProductsOrders> productsOrders = new List<MyProductsOrders>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string Sql = "SELECT Transactions.OrderID, Transactions.UserID, Products.ProductID, Products.ProductName, Products.Price FROM Transactions JOIN Products ON Transactions.ProductID = Products.ProductID WHERE Products.UserID = @UserID";
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("UserID", userID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MyProductsOrders pOrder = new MyProductsOrders();
                    pOrder.OrderID = Convert.ToInt32(reader["OrderID"]);
                    pOrder.ProductID = Convert.ToInt32(reader["ProductID"]);
                    pOrder.UserID = Convert.ToInt32(reader["UserID"]);
                    pOrder.ProductName = Convert.ToString(reader["ProductName"]);
                    pOrder.Price = Convert.ToString(reader["Price"]);
                    productsOrders.Add(pOrder);
                }
            }
            return productsOrders;
        }



    }
    public class DisplayMyProductOrders : MyProductsOrders
    {
        public DisplayMyProductOrders()
        { }
        public DisplayMyProductOrders(int OrderID, int ProductID, int UserID, string ProductName, string Price)
        {
            this.OrderID = OrderID;
            this.ProductID = ProductID;
            this.UserID = UserID;
            this.ProductName = ProductName;
            this.Price = Price;
        }

        public static List<DisplayMyProductOrders> SelectMyProductOrders()
        {
            List<DisplayMyProductOrders> displayMyProductOrders = new List<DisplayMyProductOrders>();

            string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string Sql = "SELECT Transactions.OrderID, Transactions.UserID, Products.ProductID, Products.ProductName, Products.Price FROM Transactions JOIN Products ON Transactions.ProductID = Products.ProductID WHERE Products.UserID = @UserID";
                    SqlCommand cmd = con.CreateCommand();
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DisplayMyProductOrders productOrder = new DisplayMyProductOrders();
                        productOrder.OrderID = Convert.ToInt32(reader["OrderID"]);
                        productOrder.ProductID = Convert.ToInt32(reader["ProductID"]);
                        productOrder.UserID = Convert.ToInt32(reader["UserID"]);
                        productOrder.ProductName = Convert.ToString(reader["ProductName"]);
                        productOrder.Price = Convert.ToString(reader["Price"]);
                        displayMyProductOrders.Add(productOrder);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error occured while retreiving orders");
            }
            return displayMyProductOrders;
        }
    }
}
