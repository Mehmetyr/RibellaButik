using ribellabutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ribellabutik.Controllers
{
    public class HomeController : Controller
    {
        Db_model db = new Db_model();
        // GET: Home
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Shop()
        {
            List<Product> productsList = db.Products.Where(s => s.SellStatus == true).ToList();
            return View(productsList);
        }


    }
}