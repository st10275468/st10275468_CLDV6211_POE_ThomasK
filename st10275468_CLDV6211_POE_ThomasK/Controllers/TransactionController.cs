using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class TransactionController : Controller
    {
        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Products.con_string))
                {

                    string sql = "INSERT INTO Transactions (UserID, ProductID) VALUES (@UserID, @ProductID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}