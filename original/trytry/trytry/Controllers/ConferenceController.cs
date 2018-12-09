using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using trytry.Models;
using System.IO;
using System.Data.Entity.Infrastructure;

namespace trytry.Controllers
{
    public class ConferenceController : Controller
    {
        hotelEntities7 dc = new hotelEntities7();
        string connectionstring = @"Data Source=.;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        [HttpGet]
        public ActionResult Index()
        {
            List<conferenceadmin1> lists = new List<conferenceadmin1>();
            lists = dc.conferenceadmin1.ToList();
            return View(lists);

        }

       
        // GET: Conference/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conference/Create
        [HttpPost]
        public ActionResult Create(conferenceadmin1 conferencemodel)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(conferencemodel.ImageFile.FileName);
                string extension = Path.GetExtension(conferencemodel.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                conferencemodel.image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                conferencemodel.ImageFile.SaveAs(filename);
                using (hotelEntities7 dc = new hotelEntities7())
                {
                    
                    dc.conferenceadmin1.Add(conferencemodel);
                    dc.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                return View(ex);

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Successful";
            return RedirectToAction("Index");
        }

        // GET: Conference/Edit/5
        public ActionResult Edit(int id)
        {
            conferenceadmin1 conferencemodel = new conferenceadmin1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conferenceadmin1 where HallId = @HallId";
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
                conferencemodel.fooditems = dt.Rows[0][5].ToString();
               

                
                
                return View(conferencemodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Conference/Edit/5
        [HttpPost]
        public ActionResult Edit(conferenceadmin1 conferencemodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update conferenceadmin1 set CityName = @CityName, HallName = @HallName, facilities = @facilities,fooditems=@fooditems, capacity = @capacity, budget = @budget, address = @address where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", conferencemodel.HallId);

                cmd.Parameters.AddWithValue("@CityName", conferencemodel.CityName);

                cmd.Parameters.AddWithValue("@HallName", conferencemodel.HallName);
                cmd.Parameters.AddWithValue("@fooditems", conferencemodel.fooditems);
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
            conferenceadmin1 conferencemodel = new conferenceadmin1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from conferenceadmin1 where HallId = @HallId";
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
                conferencemodel.fooditems = dt.Rows[0][5].ToString();
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
                string query = "Delete From conferenceadmin1 where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
