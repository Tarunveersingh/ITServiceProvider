using ITServiceProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITServiceProvider.Controllers
{
    public class HomeController : Controller
    {
        //create the instance of he model class
        DatabaseModel databaseModel= new DatabaseModel();




        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        [HttpPost]
        public ActionResult MessagePass(Contact contact)
        {
            //Pass the data to store the record into the table 

            databaseModel.Addcontact("insert into FeedBack(Name,Email,Message) values('" + contact.txtName + "','" + contact.txtEmail + "','" + contact.txtMessage + "')");

            return View("feedback");



        }






        public ActionResult feedback()
        {
            ViewBag.Title = "Home Page";

            return View();
        }





    }
}
