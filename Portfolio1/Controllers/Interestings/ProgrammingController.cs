using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio1.Controllers.Interestings
{
    [Authorize]
    public class ProgrammingController : Controller
    {
        // GET: Programowanie
        public ActionResult Index()
        {
            return View();
        }
    }
}