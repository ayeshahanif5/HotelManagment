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
    public class ConferenceController : Controller
    {
        string connectionstring = @"Data Source=DELL;Initial Catalog=hotel;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conference";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

       
        // GET: Conference/Create
        public ActionResult Create()
        {
            return View(new conference());
        }

        // POST: Conference/Create
        [HttpPost]
        public ActionResult Create(conference conferencemodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into conference(CityName,HallName,facilities,capacity,budget,address) values(@CityName,@HallName,@facilities,@capacity,@budget,@address)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CityName", conferencemodel.CityName);

                cmd.Parameters.AddWithValue("@HallName", conferencemodel.HallName);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@facilities", conferencemodel.facilities);
                cmd.Parameters.AddWithValue("@capacity", conferencemodel.capacity);

                cmd.Parameters.AddWithValue("@budget", conferencemodel.budget);
                cmd.Parameters.AddWithValue("@address", conferencemodel.address);
                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }
        }

        // GET: Conference/Edit/5
        public ActionResult Edit(int id)
        {
            conference conferencemodel = new conference();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conference where HallId = @HallId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HallId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                conferencemodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
                conferencemodel.CityName = dt.Rows[0][1].ToString();
                conferencemodel.HallName = dt.Rows[0][2].ToString();
                conferencemodel.facilities = dt.Rows[0][3].ToString();
                conferencemodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());
                conferencemodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
                conferencemodel.address = dt.Rows[0][10].ToString();
               

                
                
                return View(conferencemodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Conference/Edit/5
        [HttpPost]
        public ActionResult Edit(conference conferencemodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update conference set CityName = @CityName, HallName = @HallName, facilities = @facilities, capacity = @capacity, budget = @budget, address = @address where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", conferencemodel.HallId);

                cmd.Parameters.AddWithValue("@CityName", conferencemodel.CityName);

                cmd.Parameters.AddWithValue("@HallName", conferencemodel.HallName);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@facilities", conferencemodel.facilities);
                cmd.Parameters.AddWithValue("@capacity", conferencemodel.capacity);

                cmd.Parameters.AddWithValue("@budget", conferencemodel.budget);
                cmd.Parameters.AddWithValue("@address", conferencemodel.address);
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Conference/Delete/5
        public ActionResult Delete(int id)
        {
            conference conferencemodel = new conference();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conference where HallId = @HallId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HallId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                conferencemodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
                conferencemodel.CityName = dt.Rows[0][1].ToString();
                conferencemodel.HallName = dt.Rows[0][2].ToString();
                conferencemodel.facilities = dt.Rows[0][3].ToString();
                conferencemodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());
                conferencemodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
                conferencemodel.address = dt.Rows[0][10].ToString();

                return View(conferencemodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Conference/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete From conference where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
