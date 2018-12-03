using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using trytry.Models;
using System.Configuration;

namespace trytry.Controllers
{
    public class HomeController : Controller
    {
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True";
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

        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login());


        }

        [HttpPost]

        public ActionResult Login(Login loginmodel)
        {
            //string mainconn = ConfigurationManager.ConnectionStrings["hotelEntities2"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string sqlquery = "select Email,Password from [dbo].[Sign_In] where Email=@Email and Password=@Password";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
            sqlcomm.Parameters.AddWithValue("@Email", loginmodel.Email);
            sqlcomm.Parameters.AddWithValue("@Password", loginmodel.Password);

            //DataSet ds = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter(sqlcomm);
            //da.Fill(ds);
            //con.Close();


            //bool loginSuccessful = ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0));

            //if (loginSuccessful)
            //{
            //    Console.WriteLine("Success!");
            //}
            //else
            //{
            //    Console.WriteLine("Invalid username or password");
            //}





            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {
                Console.WriteLine("Success!");
                return RedirectToAction("Cities");
            }
            else
            {

                Console.WriteLine("Invalid username or password");
            }
            con.Close();
            return View();
        }

    }
}