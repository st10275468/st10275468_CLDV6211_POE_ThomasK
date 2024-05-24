using Microsoft.AspNetCore.Mvc;
using st10275468_CLDV6211_POE_ThomasK.Models;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace st10275468_CLDV6211_POE_ThomasK.Controllers
{
    public class TransactionController : Controller
    {
        public int? UserID { get; set; }
        IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        
        [HttpPost]
        public ActionResult PlaceOrder(string userID, int productID)
        {
            UserID = httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            try
            {
                
                using (SqlConnection con = new SqlConnection(Products.con_string))
                {
                    con.Open();
                    string checkUserSql = "SELECT COUNT(1) FROM Users WHERE UserID = @UserID";

                    using (SqlCommand checkUserCmd = new SqlCommand(checkUserSql, con))
                    {
                        checkUserCmd.Parameters.AddWithValue("@UserID", UserID);
                        int userExists = (int)checkUserCmd.ExecuteScalar();
                        if (userExists == 0)
                        {
                            return View("Error", new ErrorViewModel
                            {
                                RequestId = HttpContext.TraceIdentifier,
                                ErrorMessage = "User does not exist."
                            });
                        }

                    }
                   
                    string sql = "INSERT INTO Transactions (ProductID, UserID) VALUES (@ProductID,@UserID)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        
                        int rowsAffected = cmd.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("ShopProducts", "Home");
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
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier,
                    ErrorMessage = ex.Message
                };
                return View("Error", errorViewModel);
            }
        }
    }
}