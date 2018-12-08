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
    public class HotelController : Controller
    {
        hotelEntities6 dc = new hotelEntities6();
        string connectionstring = @"Data Source=ABDULREHMAN;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        [HttpGet]
        public ActionResult Index()
        {
            List<hoteladmin> lists = new List<hoteladmin>();
            lists = dc.hoteladmins.ToList();
            return View(lists);
        }

      

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(hoteladmin room)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(room.ImageFile.FileName);
                string extension = Path.GetExtension(room.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                room.image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                room.ImageFile.SaveAs(filename);
                using (hotelEntities6 dc = new hotelEntities6())
                {
                    dc.hoteladmins.Add(room);
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

        // GET: Hotel/Edit/5
        public ActionResult Edit(int id)
        {
            hotel hotelmodel = new hotel();
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
        public ActionResult Edit(hotel hotelmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update hotel set hotelname = @hotelname, address = @address, facilities = @facilities, budget = @budget, avaliablerooms = @avaliablerooms where HotelId = @HotelId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HotelId", hotelmodel.HotelId);

                cmd.Parameters.AddWithValue("@hotelname", hotelmodel.hotelname);

                cmd.Parameters.AddWithValue("@address", hotelmodel.address);
                cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
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
            hotel hotelmodel = new hotel();
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
