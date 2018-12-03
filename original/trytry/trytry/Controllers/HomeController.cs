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
    public class HomeController : Controller
    {
        string connectionstring = @"Data Source=ABDULREHMAN;Initial Catalog=hotel;Integrated Security=True";
        private object db;
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Gallery()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Cities()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();

                string query = "Select * from City";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }

            return View(dt);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpGet]
        public ActionResult Sign_In()
        {
            return View(new Sign_In());

           
        }
        [HttpPost]
        public ActionResult Sign_In(Sign_In SignInmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into Sign_In(UserName,Gender,DOB,Address,City,Email,Password,ConfirmPassword) values (@UserName,@Gender,@DOB,@Address,@City,@Email,@Password,@ConfirmPassword)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@UserName", SignInmodel.UserName);
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