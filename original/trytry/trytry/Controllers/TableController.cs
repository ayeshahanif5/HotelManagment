﻿using System;
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
    public class TableController : Controller
    {
        hotelEntities8 dc = new hotelEntities8();
        string connectionstring = @"Data Source=DESKTOP-1M6H1PO\ANUMSQL;Initial Catalog=hotel;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        public ActionResult Index()
        {
            List<tableadmin1> lists = new List<tableadmin1>();
            lists = dc.tableadmin1.ToList();
            return View(lists);
        }

       

        // GET: Table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Table/Create
        [HttpPost]
        public ActionResult Create(tableadmin1 tablemodel)
        {
            try
            {
                string filename = Path.GetFileNameWithoutExtension(tablemodel.ImageFile.FileName);
                string extension = Path.GetExtension(tablemodel.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                tablemodel.image = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                tablemodel.ImageFile.SaveAs(filename);
                using (hotelEntities8 dc = new hotelEntities8())
                {

                    dc.tableadmin1.Add(tablemodel);
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

        // GET: Table/Edit/5
        public ActionResult Edit(int id)
        {
            tableadmin1 tablemodel = new tableadmin1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from tableadmin1 where TableId = @TableId";
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
        public ActionResult Edit(tableadmin1 tablemodel)
        {
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Update tableadmin1 set HallName = @HallName, address = @address, CityName = @CityName where TableId = @TableId";
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
            tableadmin1 tablemodel = new tableadmin1();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string query = "Select * from tableadmin1 where TableId = @TableId";
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
                string query = "Delete From tableadmin1 where TableId = @TableId";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TableId", id);


                cmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }
    }
}
