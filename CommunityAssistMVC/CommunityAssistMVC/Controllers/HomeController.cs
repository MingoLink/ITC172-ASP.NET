using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models; // reference models

namespace CommunityAssistMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //initialize entities classes
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            //pass the collection categories to the index as a list
            return View(db.GrantTypes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}