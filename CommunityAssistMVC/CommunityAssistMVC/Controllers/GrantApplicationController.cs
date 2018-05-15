using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Controllers
{
    public class GrantApplicationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: GrantApplication
        public ActionResult Index()
        {
            if (Session["ReviewerKey"] == null)
            {
                //Message msg = new Message("You must be logged in to add a book");
                //return RedirectToAction("Result", msg");

                return RedirectToAction("Index", "Login");
            }
            ViewBag.Grants = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
            
        }

        


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey,GrantApplicationDate,GrantTypeKey,GrantApplicationRequestAmount,GrantApplicationReason," +
            "GrantApplicationStatusKey")]GrantApplication g)
        {
            try
            {
                g.GrantAppicationDate = DateTime.Now;
                g.PersonKey = (int)Session["ReviewerKey"];
                g.GrantApplicationStatusKey = (int)1;
                
                db.GrantApplications.Add(g);
                db.SaveChanges();

                Message msg = new Message("Thank you for your Grant Application");
                return RedirectToAction("Result", msg);

            }
            catch(Exception e)
            {
                Message msg = new Message();
                msg.MessageText = e.Message;
                return RedirectToAction("Result", msg);
            }

        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }

    }
}