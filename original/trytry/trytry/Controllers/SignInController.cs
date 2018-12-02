using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using trytry.Models;


namespace trytry.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        string connectionstring = @"Data Source=ABDULREHMAN;Initial Catalog=hotel;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from Sign_In";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

        public ActionResult Register()
        {
            return View(new Sign_In());
        }

        [HttpPost]
        public ActionResult Register(Sign_In SignInmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into Sign_In(User_Name,Gender,DOB,Address,City,Email,Password,ConfirmPassword) values (@User_Name,@Gender,@DOB,@Address,@City,@Email,@Password,@ConfirmPassword)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@User_Name", SignInmodel.User_Name);
                cmd.Parameters.AddWithValue("@Gender", SignInmodel.Gender);
                cmd.Parameters.AddWithValue("@DOB", SignInmodel.DOB);
                cmd.Parameters.AddWithValue("@Address", SignInmodel.Address);
                cmd.Parameters.AddWithValue("@City", SignInmodel.City);
                cmd.Parameters.AddWithValue("@Email", SignInmodel.Email);
                cmd.Parameters.AddWithValue("@Password", SignInmodel.Password);
                cmd.Parameters.AddWithValue("@ConfirmPassword", SignInmodel.ConfirmPassword);
                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }
        }

    }
}
    
