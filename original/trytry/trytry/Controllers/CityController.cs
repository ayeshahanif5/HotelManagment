using trytry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
<<<<<<< HEAD

using System.Data.SqlClient;
=======
using System.Linq;
using System.Data.SqlClient;

using System.IO;
using System.Data.Entity.Infrastructure;
>>>>>>> 2fabd8ac4f2c71a90f40a834c1ca6af90e262e73

using System.IO;
using System.Data.Entity.Infrastructure;

namespace trytry.Controllers.CityController
{
    public class CityController : Controller
    {
<<<<<<< HEAD
        string connectionstring = @"Data Source=DELL;Initial Catalog=hotel;Integrated Security=True";
=======
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True";
>>>>>>> 2fabd8ac4f2c71a90f40a834c1ca6af90e262e73
        private object db;

        [HttpGet]
        public ActionResult Index()
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
        // GET: City/Create
        public ActionResult Create()
        {
            return View(new City());
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(City citymodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into City(CityName) values (@CityName)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CityName", citymodel.CityName);

                //


                string fileName = Path.GetFileNameWithoutExtension(citymodel.ImageFile.FileName);
                string extension = Path.GetExtension(citymodel.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                citymodel.ImagePath = "~/Image/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                citymodel.ImageFile.SaveAs(fileName);
                //using (DbModels db = new DbModels()
                //{
                //    db.Images.Add(citymodel);




                //}



                cmd.ExecuteNonQuery();
                con.Close();

                return View();
            }
        }
         [HttpGet]  
        
        public ActionResult View(int id)
        {
            City citymodel = new City();
            using (DbModels db = new DbModels())
            {
                citymodel = db.Cities.Where(x => x.CityId == id).FirstOrDefault();
            }
            return View(citymodel);
        }

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
