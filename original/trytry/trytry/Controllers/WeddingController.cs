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
    public class WeddingController : Controller
    {
        hotelEntities8 dc = new hotelEntities8();
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        [HttpGet]
        public ActionResult Index()
        {
            List<wedding1> lists = new List<wedding1>();
            lists = dc.wedding1.ToList();
            return View(lists);
        }



        // GET: Wedding/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wedding/Create
        [HttpPost]
        public ActionResult Create(wedding1 weddingmodel)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(weddingmodel.ImageFile.FileName);
                string extension = Path.GetExtension(weddingmodel.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                weddingmodel.image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                weddingmodel.ImageFile.SaveAs(filename);
                using (hotelEntities8 dc = new hotelEntities8())
                {

                    dc.wedding1.Add(weddingmodel);
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

       
        // GET: Wedding/Edit/5
        public ActionResult Edit(int id)
        {
            wedding1 weddingmodel = new wedding1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding1 where HallId = @HallId";
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
        public ActionResult Edit(wedding1 weddingmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update wedding1 set CityName = @CityName, HallName = @HallName, facilities = @facilities, capacity = @capacity, budget = @budget, address = @address where HallId = @HallId";
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
            wedding1 weddingmodel = new wedding1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from wedding1 where HallId = @HallId";
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
                string query = "Delete From wedding1 where HallId = @HallId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HallId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
