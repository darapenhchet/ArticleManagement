using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment.Views.Home
{
    public class ErrorPageController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Oops(int id)
        {
            Response.StatusCode = id;
            return View();
        }
    }
}
