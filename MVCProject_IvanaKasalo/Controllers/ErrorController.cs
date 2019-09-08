using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProject_IvanaKasalo.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult PageNotFound()
        {
            return View();
        }

        // GET: Error/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }    
}
