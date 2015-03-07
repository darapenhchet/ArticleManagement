using ArticleManagement.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArticleManagement.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        //
        // GET: /Admin/Articles/

        public ActionResult Index()
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            ArticleDAO articleDAO = new ArticleDAO();
            IEnumerable<ArticleModel> articles = new List<ArticleModel>();
            articles = articleDAO.ListAllArticles();
            return View(articles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            CategoryDAO categoryDAO = new CategoryDAO();
            IEnumerable<CategoryModel> categories = new List<CategoryModel>();
            categories = categoryDAO.ListAllCategories();
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleModel article)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            ArticleDAO articleDAO = new ArticleDAO();
            if (articleDAO.CreateArticle(article))
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
            IEnumerable<CategoryModel> categories = new List<CategoryModel>();
            categories = categoryDAO.ListAllCategories();
            ViewData["Categories"] = categories;

            ArticleModel article = new ArticleModel();
            ArticleDAO articleDAO = new ArticleDAO();
            article = articleDAO.GetArticle(id);
            return View(article);
        }

        [HttpPost]
        public ActionResult Update(UpdateArticleModel article)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            ArticleDAO articleDAO = new ArticleDAO();
            if (articleDAO.UpdateArticle(article))
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
            ArticleDAO articleDAO = new ArticleDAO();
            if (articleDAO.DeleteArticle(id))
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
            ArticleModel article = new ArticleModel();
            ArticleDAO articleDAO = new ArticleDAO();
            article = articleDAO.GetArticle(id);
            return View(article);
        }

        public ActionResult Search(String Search)
        {
            if (!checkSession())
            {
                return RedirectToAction("login","users");
            }
            ArticleDAO articleDAO = new ArticleDAO();
            IEnumerable<ArticleModel> articles = new List<ArticleModel>();
            articles = articleDAO.ListAllArticles(Search);
            //return RedirectToAction("Index");
            return Json(new
            {
                ARTICLES = articles
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
