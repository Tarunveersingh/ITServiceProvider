using ITServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITServiceProvider.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        ITStoreEntities iTStoreEntities = new ITStoreEntities();

        public ActionResult MemberList()
        {
            return View(iTStoreEntities.Members.ToList());
        }

        public ActionResult OurTeam()
        {
            return View(iTStoreEntities.Members.ToList());
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
        public ActionResult Create([Bind(Exclude = "id")] Member member)
        {
            if (!ModelState.IsValid)
                return View();
            iTStoreEntities.Members.Add(member);
            iTStoreEntities.SaveChanges();
            return RedirectToAction("MemberList");





        }

        // GET: Team/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in iTStoreEntities.Members where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Team/Edit/5
        [HttpPost]
        public ActionResult Edit(Member memberID)
        {
            var orignalRecord = (from m in iTStoreEntities.Members where m.id == memberID.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            iTStoreEntities.Entry(orignalRecord).CurrentValues.SetValues(memberID);

            iTStoreEntities.SaveChanges();
            return RedirectToAction("MemberList");



        }

        // GET: Team/Delete/5
        public ActionResult Delete(Member memberID)
        {
            var d = iTStoreEntities.Members.Where(x => x.id ==memberID.id).FirstOrDefault();
            iTStoreEntities.Members.Remove(d);
            iTStoreEntities.SaveChanges();
            return RedirectToAction("MemberList");
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
