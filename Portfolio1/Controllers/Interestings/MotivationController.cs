﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio1.Controllers.Interestings
{
    [Authorize]
    public class MotivationController : Controller
    {
        // GET: Motivation
        public ActionResult Index()
        {
            return View();
        }
    }
}