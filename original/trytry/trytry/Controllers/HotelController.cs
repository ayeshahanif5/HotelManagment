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
    public class HotelController : Controller
    {
        string connectionstring = @"Data Source=DESKTOP-OT0GBTM;Initial Catalog=hotel;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from hotel";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                
                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

      

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View(new HotelModel());
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(HotelModel hotelmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into hotel(hotelname,address,facilities,budget,avaliablerooms) values (@hotelname,@address,@facilities,@budget,@avaliablerooms)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@hotelname",hotelmodel.hotelname);

                cmd.Parameters.AddWithValue("@address",hotelmodel.address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@facilities", hotelmodel.facilities);
               
                cmd.Parameters.AddWithValue("@budget", hotelmodel.budget);
                cmd.Parameters.AddWithValue("@avaliablerooms", hotelmodel.avaliablerooms);
                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }
        }

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            HotelModel hotelmodel = new HotelModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from hotel where hotelid = @hotelid";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@Hotelid", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                hotelmodel.HotelId = Convert.ToInt32(dt.Rows[0][0].ToString());
                hotelmodel.hotelname = dt.Rows[0][2].ToString();
                hotelmodel.address = dt.Rows[0][3].ToString();
                hotelmodel.facilities = dt.Rows[0][5].ToString();

                hotelmodel.budget = Convert.ToInt32(dt.Rows[0][7].ToString());
                hotelmodel.avaliablerooms = dt.Rows[0][8].ToString();
                return View(hotelmodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(HotelModel hotelmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update hotel set hotelname = @hotelname, address = @address, facilities = @facilities, budget = @budget, avaliablerooms = @avaliablerooms where HotelId = @HotelId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HotelId", hotelmodel.HotelId);

                cmd.Parameters.AddWithValue("@hotelname", hotelmodel.hotelname);

                cmd.Parameters.AddWithValue("@address", hotelmodel.address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@facilities", hotelmodel.facilities);

                cmd.Parameters.AddWithValue("@budget", hotelmodel.budget);
                cmd.Parameters.AddWithValue("@avaliablerooms", hotelmodel.avaliablerooms);
                cmd.ExecuteNonQuery();
                
            }
            return RedirectToAction("Index");
            
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            HotelModel hotelmodel = new HotelModel();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from hotel where hotelid = @hotelid";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@Hotelid", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                hotelmodel.HotelId = Convert.ToInt32(dt.Rows[0][0].ToString());
                hotelmodel.hotelname = dt.Rows[0][2].ToString();
                hotelmodel.address = dt.Rows[0][3].ToString();
                hotelmodel.facilities = dt.Rows[0][5].ToString();

                hotelmodel.budget = Convert.ToInt32(dt.Rows[0][7].ToString());
                hotelmodel.avaliablerooms = dt.Rows[0][8].ToString();
                return View(hotelmodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete From hotel where HotelId = @HotelId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HotelId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
