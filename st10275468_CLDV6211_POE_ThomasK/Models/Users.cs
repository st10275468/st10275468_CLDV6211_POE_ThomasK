using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
namespace st10275468_CLDV6211_POE_ThomasK.Models
{
    public class Users
    {
        public Users() { }
        public static string con_string = "Server=tcp:st10275468-server.database.windows.net,1433;Initial Catalog=st10275468-database;Persist Security Info=False;User ID=st10275468;Password=Capecobras@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public int insert_User(Users m)
        {
            try
            {
                string sql = "INSERT INTO Users (UserName, UserSurname, UserEmail, UserPassword) VALUES (@Name, @Surname, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Surname", m.Surname);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                cmd.Parameters.AddWithValue("@Password", m.Password);
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
    }
}
