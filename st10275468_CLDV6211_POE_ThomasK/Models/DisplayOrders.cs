using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class DisplayOrders
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public int OrderID { get; set; }
      

        public DisplayOrders() { }

        public DisplayOrders(int oID,int pID, string pName, string pPrice )
        {
            
            OrderID = oID;
            ProductID = pID;
            ProductName = pName;
            Price = pPrice;

        }

        public static List<DisplayOrders> SelectOrders()
        {
            List<DisplayOrders> displayOrders = new List<DisplayOrders>();

            string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string sql = "SELECT Transactions.OrderID, Products.ProductID, Products.ProductName, Products.Price FROM Transactions JOIN Products ON Transactions.ProductID = Products.ProductID WHERE Transactions.UserID = @UserID";
                    SqlCommand cmd = con.CreateCommand();
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DisplayOrders order = new DisplayOrders();
                        order.OrderID = Convert.ToInt32(reader["OrderID"]);
                        order.ProductID = Convert.ToInt32(reader["ProductID"]);
                        order.ProductName = Convert.ToString(reader["ProductName"]);
                        order.Price = Convert.ToString(reader["Price"]);
                        displayOrders.Add(order);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex) {

                Console.WriteLine("Error occured while retreiving orders");
                    }
            return displayOrders;

        }
    }
}
