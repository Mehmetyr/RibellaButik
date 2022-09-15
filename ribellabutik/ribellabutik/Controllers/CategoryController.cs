using ribellabutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ribellabutik.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Db_model db = new Db_model();
        public ActionResult Index()
        {
            List<Category> categoryList = db.Categories.Where(x => x.Status == true).ToList();
            return View(categoryList);
        }
        public ActionResult CategoryDetail(int id)
        {
            List<Product> categoris = db.Products.Where(x => x.Category.ID == id).ToList();
            return View(categoris);
        }
    }
}