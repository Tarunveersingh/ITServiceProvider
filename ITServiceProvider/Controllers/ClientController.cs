using ITServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITServiceProvider.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        ITStoreEntities iTStoreEntities = new ITStoreEntities();

        public ActionResult ClientList()
        {
            return View(iTStoreEntities.Clients.ToList());
        }

        public ActionResult HappyClient()
        {
            return View(iTStoreEntities.Clients.ToList());
        }


        // GET: Team/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Team/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Team/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] Client client)
        {
            if (!ModelState.IsValid)
                return View();
            iTStoreEntities.Clients.Add(client);
            iTStoreEntities.SaveChanges();
            return RedirectToAction("clientList");





        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in iTStoreEntities.Clients where m.ID == id select m).First();
            return View(IdToEdit);
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(Client ClientID)
        {
            var orignalRecord = (from m in iTStoreEntities.Clients where m.ID == ClientID.ID select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            iTStoreEntities.Entry(orignalRecord).CurrentValues.SetValues(ClientID);

            iTStoreEntities.SaveChanges();
            return RedirectToAction("ClientList");



        }

        // GET: Team/Delete/5
        public ActionResult Delete(Client clientID)
        {
            var d = iTStoreEntities.Clients.Where(x => x.ID == clientID.ID).FirstOrDefault();
            iTStoreEntities.Clients.Remove(d);
            iTStoreEntities.SaveChanges();
            return RedirectToAction("ClientList");
        }

        // POST: Team/Delete/5
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
