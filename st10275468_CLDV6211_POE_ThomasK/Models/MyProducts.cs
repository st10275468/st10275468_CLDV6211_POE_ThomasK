using System.Data.SqlClient;
namespace st10275468_CLDV6211_POE_ThomasK.Models

{
    public class MyProducts
    {

        public MyProducts() { }
        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);


        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Catagory { get; set; }
        public string Availability { get; set; }

        public static List<MyProducts> GetMyProducts(int? userID)
        {
            List<MyProducts> myProducts = new List<MyProducts>();

            using (SqlConnection con = new SqlConnection(con_string))
            {

                string Sql = "SELECT ProductID, ProductName, Price, Availability, Catagory FROM Products WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.Parameters.AddWithValue("UserID", userID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    MyProducts myProduct = new MyProducts();
                    myProduct.ProductID = Convert.ToInt32(reader["ProductID"]);
                    myProduct.Name = reader["ProductName"].ToString();
                    myProduct.Price = reader["Price"].ToString();
                    myProduct.Catagory = reader["Catagory"].ToString();
                    myProduct.Availability = reader["Availability"].ToString();
                    myProducts.Add(myProduct);
                }

            }
            return myProducts;
        }

    }
    public class DisplayMyProduct : MyProducts
    {
        public DisplayMyProduct() { }

        public DisplayMyProduct(int ProductID, string ProductName, string Price, string Catagory, string Availability)
        {
            this.ProductID = ProductID;
            this.Name = ProductName;
            this.Price = Price;
            this.Catagory = Catagory;
            this.Availability = Availability;
        }

        public static List<DisplayMyProduct> SelectMyProducts(int? userID)
        {
            List<DisplayMyProduct> myProducts = new List<DisplayMyProduct>();
            string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    string Sql = "SELECT ProductID, ProductName, Price, Availability, Catagory FROM Products WHERE UserID = @UserID";
                    SqlCommand cmd = con.CreateCommand();
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DisplayMyProduct myProduct = new DisplayMyProduct();
                        myProduct.ProductID = Convert.ToInt32(reader["ProductID"]);
                        myProduct.Name = reader["ProductName"].ToString();
                        myProduct.Price = reader["Price"].ToString();
                        myProduct.Catagory = reader["Catagory"].ToString();
                        myProduct.Availability = reader["Availability"].ToString();
                        myProducts.Add(myProduct);
                    }
                    reader.Close();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured while retrieving your products");
            }
            return myProducts;
        }
    }
}