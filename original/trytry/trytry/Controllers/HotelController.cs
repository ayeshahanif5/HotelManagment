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
        hotelEntities8 dc = new hotelEntities8();
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        [HttpGet]
        public ActionResult Index()
        {
            List<hoteladmin1> lists = new List<hoteladmin1>();
            lists = dc.hoteladmin1.ToList();
            return View(lists);
        }

      

        // GET: Hotel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        public ActionResult Create(hoteladmin1 room)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(room.ImageFile.FileName);
                string extension = Path.GetExtension(room.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                room.image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                room.ImageFile.SaveAs(filename);
                using (hotelEntities8 dc = new hotelEntities8())
                {
                    dc.hoteladmin1.Add(room);
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
            hoteladmin1 hotelmodel = new hoteladmin1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from hoteladmin1 where HotelId = @HotelId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@HotelId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                hotelmodel.CityName = dt.Rows[0][11].ToString();
                hotelmodel.HotelId = Convert.ToInt32(dt.Rows[0][0].ToString());
                hotelmodel.hotelname = dt.Rows[0][2].ToString();
                hotelmodel.address = dt.Rows[0][3].ToString();
                hotelmodel.facilities = dt.Rows[0][5].ToString();

                hotelmodel.budget = Convert.ToInt32(dt.Rows[0][7].ToString());
                //hotelmodel.avaliablerooms = Convert.ToInt32(dt.Rows[0][8].ToString());
                return View(hotelmodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        public ActionResult Edit(hoteladmin1 hotelmodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update hoteladmin1 set CityName = @CityName,hotelname = @hotelname, address = @address, facilities = @facilities, budget = @budget where HotelId = @HotelId";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CityName", hotelmodel.CityName);
                cmd.Parameters.AddWithValue("@HotelId", hotelmodel.HotelId);

                cmd.Parameters.AddWithValue("@hotelname", hotelmodel.hotelname);

                cmd.Parameters.AddWithValue("@address", hotelmodel.address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@facilities", hotelmodel.facilities);

                cmd.Parameters.AddWithValue("@budget", hotelmodel.budget);
                //cmd.Parameters.AddWithValue("@avaliablerooms", hotelmodel.avaliablerooms);
                cmd.ExecuteNonQuery();
                
            }
            return RedirectToAction("Index");
            
        }

        // GET: Hotel/Delete/5
        public ActionResult Delete(int id)
        {
            hoteladmin1 hotelmodel = new hoteladmin1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from hoteladmin1 where hotelid = @hotelid";
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
                string query = "Delete From hoteladmin1 where HotelId = @HotelId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@HotelId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
