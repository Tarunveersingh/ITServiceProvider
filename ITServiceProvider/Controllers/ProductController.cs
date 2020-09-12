using ITServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITServiceProvider.Controllers
{
    public class ProductController : Controller
    {


        ITStoreEntities iTStoreEntities = new ITStoreEntities();


        public ActionResult AllProduct()
        {
            return View(iTStoreEntities.Products.ToList());
        }

        public ActionResult OurProduct()
        {
            return View(iTStoreEntities.Products.ToList());
        }


        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Product product)
        {

            if (!ModelState.IsValid)
                return View();
            iTStoreEntities.Products.Add(product);
            iTStoreEntities.SaveChanges();
            return RedirectToAction("AllProduct");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in iTStoreEntities.Products where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product productID)
        {

            var orignalRecord = (from m in iTStoreEntities.Products where m.id == productID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            iTStoreEntities.Entry(orignalRecord).CurrentValues.SetValues(productID);

            iTStoreEntities.SaveChanges();
            return RedirectToAction("AllProduct");

        }

        // GET: Product/Delete/5
        public ActionResult Delete(Product productID)
        {

            var d = iTStoreEntities.Products.Where(x => x.id == productID.id).FirstOrDefault();
            iTStoreEntities.Products.Remove(d);
            iTStoreEntities.SaveChanges();
            return RedirectToAction("AllProduct");
        }

        // POST: Product/Delete/5
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
