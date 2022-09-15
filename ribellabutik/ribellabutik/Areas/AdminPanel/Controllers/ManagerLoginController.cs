using ribellabutik.Areas.AdminPanel.Model.ViewModel;
using ribellabutik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ribellabutik.Areas.AdminPanel.Controllers
{
    public class ManagerLoginController : Controller
    {
        Db_model db = new Db_model();
        // GET: AdminPanel/ManagerLogin

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.Managers.Count(x => x.Mail == model.Mail && x.Password == model.Password) > 0)
                {
                    Manager m = db.Managers.FirstOrDefault(x => x.Mail == model.Mail && x.Password == model.Password);
                    Session["manager"] = m;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public ActionResult LogOut()
        {
            Session.Remove("user");
            return RedirectToAction("Login", "ManagerLogin");
        }
    }
}