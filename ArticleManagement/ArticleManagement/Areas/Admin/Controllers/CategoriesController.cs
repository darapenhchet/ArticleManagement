using ArticleManagement.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticleManagement.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        //
        // GET: /Admin/Categories/

        public ActionResult Index()
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            IEnumerable<CategoryModel> categories = new List<CategoryModel>();
            categories = categoryDAO.ListAllCategories();
            return View(categories);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryModel category)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            if (categoryDAO.CreateCategory(category))
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
        public ActionResult Update(int id)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            CategoryModel category = new CategoryModel();
            category = categoryDAO.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Update(UpdateCategoryModel category)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            if (categoryDAO.UpdateCategory(category))
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
            //return View();
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            if(categoryDAO.DeleteCategory(id))
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
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryModel category = new CategoryModel();
            CategoryDAO categoryDAO = new CategoryDAO();
            category = categoryDAO.GetCategory(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Search(String Search)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            IEnumerable<CategoryModel> categories = new List<CategoryModel>();
            categories = categoryDAO.ListAllCategories(Search);
            //return RedirectToAction("Index");
            return Json(new
            {
                CATEGORIES = categories
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
