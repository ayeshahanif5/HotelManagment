using trytry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

using System.Data.SqlClient;

using System.IO;
using System.Data.Entity.Infrastructure;

namespace trytry.Controllers
{
    public class CityController : Controller
    {
        hotelEntities6 dc = new hotelEntities6();
        string connectionstring = @"Data Source=ABDULREHMAN;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        private object db;

        [HttpGet]
        public ActionResult Index()
        {
            List<City> lists = new List<City>();
            lists = dc.Cities.ToList();
            return View(lists);
        }

      
        [HttpGet]
        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City city)
        {

            try
            {
                string filename = Path.GetFileNameWithoutExtension(city.ImageFile.FileName);
                string extension = Path.GetExtension(city.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                city.image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                city.ImageFile.SaveAs(filename);
                using (hotelEntities6 dc = new hotelEntities6())
                {
                    //if (dc.Cities.Any(x => x.CityName == city.CityName))
                    //{
                    //    ViewBag.DuplicateMessage = "CityName already exist.";
                    //    return View(city);
                    //}
                    dc.Cities.Add(city);
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
         [HttpGet]  
        
        //public ActionResult View(int id)
        //{
        //    City citymodel = new City();
        //    using (hotelEntities2 db =new hotelEntities2())
        //    {
        //        citymodel = db.Cities.Where(x => x.CityId == id).FirstOrDefault();
        //    }
        //    return View(citymodel);
        //}

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            City citymodel = new City();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from City where CityId = @CityId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@CityId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                citymodel.CityId = Convert.ToInt32(dt.Rows[0][0].ToString());
                citymodel.CityName = dt.Rows[0][1].ToString();
               
                return View(citymodel);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(City citymodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update City set CityName = @CityName where CityId = @CityId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CityId", citymodel.CityId);

                cmd.Parameters.AddWithValue("@CityName", citymodel.CityName);

            
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            City citymodel = new City();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from City where CityId = @CityId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@CityId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                citymodel.CityId = Convert.ToInt32(dt.Rows[0][0].ToString());
                citymodel.CityName = dt.Rows[0][1].ToString();
               
                return View(citymodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: City/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete From City where CityId = @CityId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CityId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}
