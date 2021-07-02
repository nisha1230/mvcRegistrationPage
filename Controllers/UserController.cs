using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcRegistrationPage.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace mvcRegistrationPage.Controllers
{
    public class UserController : Controller
    {
        // GET: User 
        public ActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(UserClass uc)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBcon"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_RegisterData ";
            cmd.Parameters.AddWithValue("@First_Name", uc.First_Name);
            cmd.Parameters.AddWithValue("@Last_Name", uc.Last_Name);
            cmd.Parameters.AddWithValue("@Email_id", uc.Email);
            cmd.Parameters.AddWithValue("@Password", uc.Password);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
            
            Session["FirstName"] = uc.First_Name.ToString();
            return RedirectToAction("RegistrationDone", "User");         
           
        }
        public ActionResult Cancel(UserClass uc)
        {
             ModelState.Clear();
             return View();
        }

        public ActionResult RegistrationDone()
        {
            return View();
            
        }
      


    }
}