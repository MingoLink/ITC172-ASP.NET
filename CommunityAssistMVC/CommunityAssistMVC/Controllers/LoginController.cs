using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Controllers
{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName, Password")]LoginClass lc)
        {
            int results = db.usp_Login(lc.UserName, lc.Password);
            int revKey = 0;
            Message msg = new Message();


            if (results != -1)
            {
                var pkey= (from r in db.People
                          where r.PersonEmail.Equals(lc.UserName)
                          select r.PersonKey).FirstOrDefault();
                revKey = (int) pkey;
                Session["ReviewerKey"] = revKey;

                msg.MessageText = "Welcome, " + lc.UserName;
            }
            else
            {
                msg.MessageText = "Whoops, invalid login";
            }
            return View("Result", msg);
        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

        
    }
}