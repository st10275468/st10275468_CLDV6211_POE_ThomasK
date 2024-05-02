using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class Login
    {
        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int SelectUser(string name, string password)
        {
            int userID = -1;

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT UserID FROM Users WHERE UserName = @Name AND UserPassword = @Password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        userID = Convert.ToInt32(result);
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return userID;
            }

        }

    }
}
