using KN_WEB.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KN_WEB.Controllers
{
    [ValidarAdmin]
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Monitor()
        {
            return View();
        }
    }
}