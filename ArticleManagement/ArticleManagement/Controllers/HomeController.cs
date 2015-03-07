using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Assignment.Areas.Admin.Models;
using System.Net;

namespace Assignment.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        [HandleError]
        public ActionResult Index(string msg)
        {
            ViewModel mymodel = new ViewModel();
            mymodel.AllPosts = ArticleDAO.List();
            return View(mymodel);
        }

        [HttpPost]
        public ActionResult Index(ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (AccountDAO.SignIn(model.SignIn))
                {
                    FormsAuthentication.SetAuthCookie(model.SignIn.Username, model.SignIn.Remember);
                    return RedirectToAction("Index", "Admin");
                }
            }
            ModelState.AddModelError("", "SignIn data is incorrect!");
            return View();
        }

        [HttpGet]
        public ActionResult ViewPost(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(ArticleDAO.Detail(id));
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Other()
        {
            return View();
        }

        
    }
}
