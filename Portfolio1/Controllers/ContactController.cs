using Portfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Net;

namespace Portfolio1.Controllers
{
    public class ContactController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SendMail sendingData = null)
        {

            if(ModelState.IsValid)
            {
                return View("Thanks",sendingData);
            }
            else
            {
                return View(sendingData);
            }
        }

    }
}