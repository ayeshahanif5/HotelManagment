﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using trytry.Models;

namespace trytry.Controllers
{
    public class TableController : Controller
    {
<<<<<<< HEAD
        string connectionstring = @"Data Source=DELL;Initial Catalog=hotel;Integrated Security=True";
=======
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True";
>>>>>>> 2fabd8ac4f2c71a90f40a834c1ca6af90e262e73
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from tablebooking";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);

                ada.Fill(dt);
                con.Close();

            }
            return View(dt);
        }

       

        // GET: Table/Create
        public ActionResult Create()
        {
            return View(new tablebooking());
        }

        // POST: Table/Create
        [HttpPost]
<<<<<<< HEAD
        public ActionResult Create (TableModel tablemodel)
=======
        public ActionResult Create(tablebooking tablemodel)
>>>>>>> 2fabd8ac4f2c71a90f40a834c1ca6af90e262e73
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "insert into tablebooking(CityName,HallName,address) values (@CityName,@HallName,@address)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@CityName", tablemodel.CityName);

                cmd.Parameters.AddWithValue("@HallName", tablemodel.HallName);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@address", tablemodel.address);

               
                cmd.ExecuteNonQuery();
                //}   // TODO: Add insert logic here
                con.Close();

                return RedirectToAction("Index");
            }
        }

        // GET: Table/Edit/5
        public ActionResult Edit(int id)
        {
            tablebooking tablemodel = new tablebooking();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from tablebooking where TableId = @TableId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@TableId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                tablemodel.TableId = Convert.ToInt32(dt.Rows[0][0].ToString());
                tablemodel.CityName = dt.Rows[0][1].ToString();
                tablemodel.HallName = dt.Rows[0][2].ToString();
                tablemodel.address = dt.Rows[0][3].ToString();

                
                return View(tablemodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Table/Edit/5
        [HttpPost]
        public ActionResult Edit(tablebooking tablemodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update tablebooking set HallName = @HallName, address = @address, CityName = @CityName where TableId = @TableId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TableId", tablemodel.TableId);

                cmd.Parameters.AddWithValue("@HallName", tablemodel.HallName);

                cmd.Parameters.AddWithValue("@address", tablemodel.address);
                //cmd.Parameters.AddWithValue("@roomtype", hotelmodel.roomtype);
                cmd.Parameters.AddWithValue("@CityName", tablemodel.CityName);

                
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Table/Delete/5
        public ActionResult Delete(int id)
        {
            tablebooking tablemodel = new tablebooking();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from tablebooking where TableId = @TableId";
                SqlDataAdapter ada = new SqlDataAdapter(query, con);
                ada.SelectCommand.Parameters.AddWithValue("@TableId", id);
                ada.Fill(dt);
                con.Close();
            }
            if (dt.Rows.Count == 1)
            {
                tablemodel.TableId = Convert.ToInt32(dt.Rows[0][0].ToString());
                tablemodel.CityName = dt.Rows[0][1].ToString();
                tablemodel.HallName = dt.Rows[0][2].ToString();
                tablemodel.address = dt.Rows[0][3].ToString();

               
                return View(tablemodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Table/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Delete From tablebooking where TableId = @TableId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TableId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
