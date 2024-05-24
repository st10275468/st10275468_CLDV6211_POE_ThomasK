using System.Data.SqlClient;

namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class Orders
    {
        public Orders() { }

        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public int OrderID{ get; set; }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        
       

        public static List<Orders> GetOrders(int? UserID)
        {
            
            List<Orders> orders = new List<Orders>();
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string Sql = "SELECT Transactions.OrderID, Products.ProductID, Products.ProductName, Products.Price FROM Transactions JOIN Products ON Transactions.ProductID = Products.ProductID WHERE Transactions.UserID = @UserID";
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("UserId", UserID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Orders order = new Orders();
                    order.OrderID = Convert.ToInt32(reader["OrderID"]);
                    order.ProductID = Convert.ToInt32(reader["ProductID"]);
                    order.ProductName = Convert.ToString(reader["ProductName"]);
                    order.Price = Convert.ToString(reader["Price"]);
                    orders.Add(order);
                }
            }
            return orders;
        }
    }
}
