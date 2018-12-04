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
        string connectionstring = @"Data Source=DELL;Initial Catalog=hotel;Integrated Security=True";
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
               
                //City objmainProperty = new City();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    City objProperty = new City();
                //    objProperty.image = (byte[])dr["image"];
                //    objmainProperty.image = objProperty.image;
                //}
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
        public ActionResult Create(City citymodel,HttpPostedFileBase image1)
        {
         
            //if(image1 != null)
            //{
            //    citymodel.image = new byte[image1.ContentLength];
                
            //    image1.InputStream.Read(citymodel.image, 0, image1.ContentLength);

            //}
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                //string filepath = Path.GetFileName(image1.FileName);
                //string savedfilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(image1.FileName));
                //image1.SaveAs(Server.MapPath("~/Desktop/Images/" + filepath));
                string query = "insert into City(CityName,image) values (@CityName,@image)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CityName", citymodel.CityName);
                cmd.Parameters.AddWithValue("@image", citymodel.image);
                //


                //string fileName = Path.GetFileNameWithoutExtension(citymodel.ImageFile.FileName);
                //string extension = Path.GetExtension(citymodel.ImageFile.FileName);
                //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //citymodel.image = "~/Image/" + fileName;
                //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                //citymodel.ImageFile.SaveAs(fileName);
                //using (hotelEntities2 db = new hotelEntities2())
                //{
                //    db.Cities.Add(citymodel);
                //    db.SaveChanges();
                //}



                cmd.ExecuteNonQuery();
                con.Close();

               
            }
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
