using ArticleManagement.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticleManagement.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        //
        // GET: /Admin/Users/

        public ActionResult Index()
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersDAO userDAO = new UsersDAO();
            IEnumerable<UsersModel> users = new List<UsersModel>();
            users = userDAO.ListAllUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel user)
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersDAO usersDAO = new UsersDAO();
            if (usersDAO.CreateUser(user))
            {
                return Json(new
                {
                    MESSAGE = "1"
                });
            }else{
                return Json(new
                {
                    MESSAGE = "0"
                });
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersModel user = new UsersModel();
            UsersDAO userDAO = new UsersDAO();
            user = userDAO.GetDetailsUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(UpdateUserModel user)
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersDAO userDAO = new UsersDAO();
            if (userDAO.UpdateUser(user))
            {
                return Json(new
                {
                    MESSAGE = "1"
                });
            }
            else
            {
                return Json(new
                {
                    MESSAGE = "0"
                });
            }
        }

        [HttpPost]
        public ActionResult Login(SignInModel user)
        {
            UsersDAO usersDAO = new UsersDAO();
            UsersModel userLogin = new UsersModel();
            userLogin = usersDAO.SignIn(user);
            if (userLogin != null)
            {
                Session["USER"] = userLogin;
                return RedirectToAction("index", "articles");
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            Session["USER"] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersDAO usersDAO = new UsersDAO();
            if (usersDAO.DeleteUser(id))
            {
                return Json(new
                {
                    MESSAGE = "1"
                });
            }
            else
            {
                return Json(new
                {
                    MESSAGE = "0"
                });
            }

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersModel user = new UsersModel();
            UsersDAO usersDAO = new UsersDAO();
            user = usersDAO.GetDetailsUser(id);
            return View(user);
        }

        public ActionResult Search(String Search)
        {
            if (!checkSession())
            {
                return RedirectToAction("login");
            }
            UsersDAO userDAO = new UsersDAO();
            IEnumerable<UsersModel> users = new List<UsersModel>();
            users = userDAO.ListAllUsers(Search);
            return Json(new
            {
                USERS = users
            });
        }

        private Boolean checkSession()
        {
            if (Session["USER"] == null)
            {
                return false;
            }
            return true;
        }
    }
}
