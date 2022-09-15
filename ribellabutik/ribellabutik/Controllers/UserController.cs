using ribellabutik.Models;
using ribellabutik.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ribellabutik.Controllers
{
    public class UserController : Controller
    {
        Db_model db = new Db_model();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User u = db.Users.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);

                if (u != null)
                {
                    Session["user"] = u;
                    return RedirectToAction("Index","Home");
                }
            }
            return View(model);
        }
        public ActionResult SingUp(User model)
        {
            if (ModelState.IsValid)
            {
                model.CreationDate = DateTime.Now;
                db.Users.Add(model);
                db.SaveChanges();
                return RedirectToAction("Login","User");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Remove("user");
            return RedirectToAction("Index","Home");
        }
    }
}