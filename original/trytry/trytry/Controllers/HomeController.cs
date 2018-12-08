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
        hotelEntities5 dc = new hotelEntities5();
        string connectionstring = @"Data Source=.;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
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
        [HttpGet]
       public ActionResult Book_Now()
        {
            return View(new roombooking());
        }
        [HttpPost]
        public ActionResult Book_Now(roombooking room,int HotelId)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //DateTime da = DateTime.Now;
                //string date = da.ToString("dd/MM/YYYY");
                con.Open();
                string query = "insert into roombooking2(HotellId,Name,Phoneno,Address,checkindate,checkoutdate) values('"+HotelId+"',@Name,@Phoneno,@Address,@checkindate,@checkoutdate)";
                SqlCommand cmd = new SqlCommand(query, con);
               // cmd.Parameters.AddWithValue("@HotelId", HotelId);
                cmd.Parameters.AddWithValue("@Name", room.Name);

                cmd.Parameters.AddWithValue("@Phoneno", room.Phoneno);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@Address", room.Address);
                cmd.Parameters.AddWithValue("@checkindate", room.checkindate);

                cmd.Parameters.AddWithValue("@checkoutdate", room.checkoutdate);

              cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }

                
        }



        [HttpGet]
        public ActionResult Book_Conference()
        {
            return View(new conferencebooking());
        }
        [HttpPost]
        public ActionResult Book_Conference(conferencebooking conference, int HotelId)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //DateTime da = DateTime.Now;
                //string date = da.ToString("dd/MM/YYYY");
                con.Open();
                string query = "insert into conferencebooking(HallId,Name,Address,[Phone No],Noofpeople,Time,checkindate,checkoutdate) values('" + HotelId + "',@Name,@Address,@Phone_No,@Noofpeople,@Time,@checkindate,@checkoutdate)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@HotelId", HotelId);
                cmd.Parameters.AddWithValue("@Name", conference.Name);

                cmd.Parameters.AddWithValue("@Address", conference.Address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@Phone_No", conference.Phone_No);
                cmd.Parameters.AddWithValue("@Noofpeople", conference.Noofpeople);
                cmd.Parameters.AddWithValue("@Time", conference.Time);
                cmd.Parameters.AddWithValue("@checkindate", conference.checkindate);

                cmd.Parameters.AddWithValue("@checkoutdate", conference.checkoutdate);

                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }


        }







        [HttpGet]
        public ActionResult Book_wedding()
        {
            return View(new weddingbooking());
        }
        [HttpPost]
        public ActionResult Book_wedding(weddingbooking wedding, int HotelId)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //DateTime da = DateTime.Now;
                //string date = da.ToString("dd/MM/YYYY");
                con.Open();
                string query = "insert into weddingbooking(HallId,Name,Address,[Phone No],Noofpeople,Time,checkindate,checkoutdate) values('" + HotelId + "',@Name,@Address,@Phone_No,@Noofpeople,@Time,@checkindate,@checkoutdate)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@HotelId", HotelId);
                cmd.Parameters.AddWithValue("@Name", wedding.Name);

                cmd.Parameters.AddWithValue("@Address", wedding.Address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@Phone_No", wedding.Phone_No);
                cmd.Parameters.AddWithValue("@Noofpeople", wedding.Noofpeople);
                cmd.Parameters.AddWithValue("@Time", wedding.Time);
                cmd.Parameters.AddWithValue("@checkindate", wedding.checkindate);

                cmd.Parameters.AddWithValue("@checkoutdate", wedding.checkoutdate);

                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }


        }










        [HttpGet]
        public ActionResult Book_table()
        {
            return View(new bookingtable());
        }
        [HttpPost]
        public ActionResult Book_table(bookingtable table, int HotelId)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //DateTime da = DateTime.Now;
                //string date = da.ToString("dd/MM/YYYY");
                con.Open();
                string query = "insert into bookingtable(TableId,Name,Address,[Phone No],personno,Time,checkindate) values('" + HotelId + "',@Name,@Address,@Phone_No,@personno,@Time,@checkindate)";
                SqlCommand cmd = new SqlCommand(query, con);
                // cmd.Parameters.AddWithValue("@HotelId", HotelId);
                cmd.Parameters.AddWithValue("@Name", table.Name);

                cmd.Parameters.AddWithValue("@Address", table.Address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@Phone_No", table.Phone_No);
                cmd.Parameters.AddWithValue("@personno", table.personno);
                cmd.Parameters.AddWithValue("@Time", table.Time);
                cmd.Parameters.AddWithValue("@checkindate", table.checkindate);

                

                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }


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

        public ActionResult Cities_wedding()
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

        public ActionResult Cities_conference()
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

        public ActionResult Cities_table()
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
        [HttpGet]
        public ActionResult Contact()
        {
            return View(new ContactUs());
        }

        [HttpPost]
        public ActionResult Contact(ContactUs contact)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into ContactUs(Name,Email,Telephone,Subject,Message) values(@Name,@Email,@Telephone,@Subject,@Message)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", contact.Name);

                cmd.Parameters.AddWithValue("@Email", contact.Email);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@Telephone", contact.Telephone);
                cmd.Parameters.AddWithValue("@Subject",contact.Subject);

                cmd.Parameters.AddWithValue("@Message", contact.Message);
               
                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }
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
            return View(new Sign_In());


        }

        [HttpPost]

        public ActionResult Login(Sign_In signin)
        {
            //string mainconn = ConfigurationManager.ConnectionStrings["hotelEntities2"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            string sqlquery = "select Email,Password from [dbo].[Sign_In] where Email=@Email and Password=@Password";
           
            SqlCommand sqlcomm = new SqlCommand(sqlquery, con);
            
            sqlcomm.Parameters.AddWithValue("@Email", signin.Email);
            sqlcomm.Parameters.AddWithValue("@Password", signin.Password);

       


            SqlDataReader sdr = sqlcomm.ExecuteReader();
            if (sdr.Read())
            {

                ViewData["Success"] = "Correct Email and Passowrd";
                return RedirectToAction("Cities","Home");

            }
            else if(signin.Email == "admin123@gmail.com" && signin.Password == "123")
            {
                return RedirectToAction("Index","Admin");

            }
           
            
            
            //else
            //{
            //    ViewData["Error Message"] = "Invalid Email and Password";

            //}
            con.Close();
            return View();
        }
     
        public ActionResult SHOW_Hotel(string cityname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from hotel where CityName = '"+cityname+"';";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

        public ActionResult SHOW_Wedding(string cityname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding1 where CityName = '" + cityname + "';";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }


        public ActionResult SHOW_conference(string cityname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conference where CityName = '" + cityname + "';";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

        public ActionResult SHOW_table(string cityname)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from tablebooking where CityName = '" + cityname + "';";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }
        //[HttpGet]
        //public act
        //[HttpPost]
        //public ActionResult SHOW_HOTEL(string Name)
        //{
        //    using (hotelEntities5 db = new hotelEntities5())
        //    {
        //        return View(db.hotels.Where(x => x.CityName == Name).FirstOrDefault());
        //    }





        //}
        [HttpPost]
        public ActionResult SHOW_CONFERENCE_HALL(int id)
        {
            //DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(connectionstring))
            //{
            //    con.Open();

            //    string query = "Select * from hotel where CityId = @id";
            //    SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //    ada.Fill(dt);
            //    con.Close();

            //}


            conference conferencemodel = new conference();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conference where HotelId = @HotelId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HotelId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                conferencemodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
                //conferencemodel.CityName = dt.Rows[0][1].ToString();
                //conferencemodel.HallName = dt.Rows[0][2].ToString();
                //conferencemodel.facilities = dt.Rows[0][3].ToString();
                //conferencemodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());
                //conferencemodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
                //conferencemodel.address = dt.Rows[0][10].ToString();




                return View(conferencemodel);
            }
            else
            {
                return View();
            }

        }





        [HttpPost]
        public ActionResult SHOW_WEDDING_HALL(int id)
        {
            //DataTable dt = new DataTable();
            //using (SqlConnection con = new SqlConnection(connectionstring))
            //{
            //    con.Open();

            //    string query = "Select * from hotel where CityId = @id";
            //    SqlDataAdapter ada = new SqlDataAdapter(query, con);

            //    ada.Fill(dt);
            //    con.Close();

            //}


            wedding1 conferencemodel = new wedding1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding1 where HotelId = @HotelId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HotelId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                conferencemodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
                //conferencemodel.CityName = dt.Rows[0][1].ToString();
                //conferencemodel.HallName = dt.Rows[0][2].ToString();
                //conferencemodel.facilities = dt.Rows[0][3].ToString();
                //conferencemodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());
                //conferencemodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
                //conferencemodel.address = dt.Rows[0][10].ToString();




                return View(conferencemodel);
            }
            else
            {
                return View();
            }




        }







        //public ActionResult SHOW_TABLE(int id)
        //{
        //    //DataTable dt = new DataTable();
        //    //using (SqlConnection con = new SqlConnection(connectionstring))
        //    //{
        //    //    con.Open();

        //    //    string query = "Select * from hotel where CityId = @id";
        //    //    SqlDataAdapter ada = new SqlDataAdapter(query, con);

        //    //    ada.Fill(dt);
        //    //    con.Close();

        //    //}


        //  wedding conferencemodel = new wedding();
        //    DataTable dt = new DataTable();
        //    using (SqlConnection con = new SqlConnection(connectionstring))
        //    {
        //        con.Open();
        //        string query = "Select * from wedding where HotelId = @HotelId";
        //        SqlDataAdapter ada = new SqlDataAdapter(query, con);
        //        ada.SelectCommand.Parameters.AddWithValue("@HotelId", id);
        //        ada.Fill(dt);
        //        con.Close();
        //    }
        //    if (dt.Rows.Count == 1)
        //    {
        //        conferencemodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
        //        //conferencemodel.CityName = dt.Rows[0][1].ToString();
        //        //conferencemodel.HallName = dt.Rows[0][2].ToString();
        //        //conferencemodel.facilities = dt.Rows[0][3].ToString();
        //        //conferencemodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());
        //        //conferencemodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
        //        //conferencemodel.address = dt.Rows[0][10].ToString();




        //        return View(conferencemodel);
        //    }
        //    else
        //    {
        //        return View();
        //    }

    }
}
