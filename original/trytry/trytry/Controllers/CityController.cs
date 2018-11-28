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
    public class CityController : Controller
    {
        string connectionstring = @"Data Source=DESKTOP-OT0GBTM;Initial Catalog=hotel;Integrated Security=True";
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

      

        // GET: City/Create
        public ActionResult Create()
        {
            return View(new CityModel());
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(CityModel citymodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into City(CityName) values (@CityName)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CityName", citymodel.CityName);

           
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return RedirectToAction("Index");
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            CityModel citymodel = new CityModel();
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
        public ActionResult Edit(CityModel citymodel)
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
            CityModel citymodel = new CityModel();
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
    }
}
