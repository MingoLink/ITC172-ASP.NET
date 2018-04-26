using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Controllers
{
    public class RegisterController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();

        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "LastName, FirstName, Email," +
                                                  "PlainPassword, Apartment, Street," +
                                                  "City, State, Zipcode, Phone")] NewPerson r) 

        {
            Message msg = new Message();
            int result = db.usp_Register(r.LastName, r.FirstName, r.Email,r.Phone, r.PlainPassword,r.Apartment,
                r.Street,r.City,r.State,r.Zipcode);
            if (result != -1)
            {
                msg.MessageText = "Welcome! Congrats on Registering, " + r.FirstName + " " + r.LastName;
            }
            else
            {
                msg.MessageText = "Something went wrong! You need to try again.";
            }

            return View("Result", msg);

        }

        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}