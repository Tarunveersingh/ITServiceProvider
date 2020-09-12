using ITServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITServiceProvider.Controllers
{
    public class AdminController : Controller
    {
        DatabaseModel databaseModel = new DatabaseModel();

        ITStoreEntities iTStoreEntities = new ITStoreEntities();

        // GET: Admin
        public ActionResult ContactList()
        {
            return View(iTStoreEntities.FeedBacks.ToList());
        }

        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult WorkingArea()
        {
            return View();
        }

        public ActionResult Wrong()
        {
            return View();
        }



        [HttpPost]
        public ActionResult loginAuthication(Login login)
        {
            //Pass the data to store the record into the table 

            DataTable tbl = new DataTable();
            tbl = databaseModel.CheckLogin("select * from LoginTable where UserName='" + login.txtUserName + "'and UserPassword='" + login.txtPassword + "'");

            if (tbl.Rows.Count > 0)
            {
                return View("WorkingArea");
            }
            else
            {
                return View("Wrong");
            }



        }



        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
