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
    public class WeddingController : Controller
    {
        string connectionstring = @"Data Source=DELL;Initial Catalog=hotel;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

       

        // GET: Wedding/Create
        public ActionResult Create()
        {
            return View(new wedding());
        }

        // POST: Wedding/Create
        [HttpPost]
        public ActionResult Create(wedding weddingmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into wedding(CityName,HallName,facilities,capacity,budget,address) values (@CityName,@HallName,@facilities,@capacity,@budget,@address)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CityName", weddingmodel.CityName);
                cmd.Parameters.AddWithValue("@HallName", weddingmodel.HallName);
                cmd.Parameters.AddWithValue("@facilities", weddingmodel.facilities);
                cmd.Parameters.AddWithValue("@capacity", weddingmodel.capacity);
                cmd.Parameters.AddWithValue("@budget", weddingmodel.budget);
                cmd.Parameters.AddWithValue("@address", weddingmodel.address);


                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("Index");
        }

        // GET: Wedding/Edit/5
        public ActionResult Edit(int id)
        {
            wedding weddingmodel = new wedding();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding where HallId = @HallId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HallId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                weddingmodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
                weddingmodel.CityName = dt.Rows[0][1].ToString();
                weddingmodel.HallName = dt.Rows[0][2].ToString();
                weddingmodel.facilities = dt.Rows[0][3].ToString();
                weddingmodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());
                weddingmodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
                weddingmodel.address = dt.Rows[0][10].ToString();

                return View(weddingmodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Wedding/Edit/5
        [HttpPost]
        public ActionResult Edit(wedding weddingmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update wedding set CityName = @CityName, HallName = @HallName, facilities = @facilities, capacity = @capacity, budget = @budget, address = @address where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", weddingmodel.HallId);
                cmd.Parameters.AddWithValue("@CityName", weddingmodel.CityName);
                cmd.Parameters.AddWithValue("@HallName", weddingmodel.HallName);
                cmd.Parameters.AddWithValue("@facilities", weddingmodel.facilities);
                cmd.Parameters.AddWithValue("@capacity", weddingmodel.capacity);
                cmd.Parameters.AddWithValue("@budget", weddingmodel.budget);
                cmd.Parameters.AddWithValue("@address", weddingmodel.address);

                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Wedding/Delete/5
        public ActionResult Delete(int id)
        {
            wedding weddingmodel = new wedding();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding where HallId = @HallId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HallId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                weddingmodel.HallId = Convert.ToInt32(dt.Rows[0][0].ToString());
                weddingmodel.CityName = dt.Rows[0][1].ToString();
                weddingmodel.HallName = dt.Rows[0][2].ToString();
                weddingmodel.facilities = dt.Rows[0][3].ToString();
                weddingmodel.capacity = Convert.ToInt32(dt.Rows[0][6].ToString());

                weddingmodel.budget = Convert.ToInt32(dt.Rows[0][9].ToString());
                weddingmodel.address = dt.Rows[0][10].ToString();
                return View(weddingmodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Wedding/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete From wedding where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
