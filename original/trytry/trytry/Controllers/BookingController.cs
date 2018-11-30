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
    public class BookingController : Controller
    {
<<<<<<< HEAD
        string connectionstring = @"Data Source=DELL;Initial Catalog=hotel;Integrated Security=True";
=======
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True";
>>>>>>> 2fabd8ac4f2c71a90f40a834c1ca6af90e262e73
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WeddingBooking()
        {
            return View();
        }

        public ActionResult TableBooking()
        {
            return View();
        }

        public ActionResult ConferenceBooking()
        {
            return View();
        }

        public ActionResult RoomBooking()
        {
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        // GET: Booking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
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

        // GET: Booking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Booking/Edit/5
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

        // GET: Booking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Booking/Delete/5
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
