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
    public class BookingsController : Controller
    {
        string connectionstring = @"Data Source=.;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bookings/Create
        public ActionResult Room_Booking()
        {
            return View(new hotel());
        }

        // POST: Bookings/Create
        [HttpPost]
        public ActionResult Room_Booking(hotel hotel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                //string filepath = Path.GetFileName(image1.FileName);
                //string savedfilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(image1.FileName));
                //image1.SaveAs(Server.MapPath("~/Desktop/Images/" + filepath));
                string query = "insert into hotel(avaliablerooms,checkindate,checkoutdate) values (@avaliablerooms,@checkindate,@checkoutdate)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@avaliablerooms", hotel.avaliablerooms);
                cmd.Parameters.AddWithValue("@checkindate", hotel.checkindate);
                cmd.Parameters.AddWithValue("@checkoutdate", hotel.checkoutdate);
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

        // GET: Bookings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bookings/Edit/5
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

        // GET: Bookings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bookings/Delete/5
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
