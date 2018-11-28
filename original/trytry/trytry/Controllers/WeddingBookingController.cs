using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace trytry.Controllers
{
    public class WeddingBookingController : Controller
    {
        string connectionstring = @"Data Source=DESKTOP-OT0GBTM;Initial Catalog=hotel;Integrated Security=True";
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

        // GET: WeddingBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeddingBooking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeddingBooking/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WeddingBooking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeddingBooking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WeddingBooking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeddingBooking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
