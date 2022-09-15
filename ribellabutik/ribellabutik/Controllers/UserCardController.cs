using ribellabutik.Models;
using ribellabutik.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ribellabutik.Controllers
{
    public class PayServiceModel
    {
        public string MerchantCode { get; set; }
        public string MerchantPassword { get; set; }
        public string CardNo { get; set; }
        public string ExpM { get; set; }
        public string ExpY { get; set; }
        public string CVV { get; set; }
        public decimal Price { get; set; }
    }
    public class UserCardController : Controller
    {
        Db_model db = new Db_model();
        // GET: UserCard
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                int id = ((User)Session["user"]).ID;
                return View(db.UserCards.Where(x => x.User_ID == id).ToList());
            }
            return RedirectToAction("Login", "User");
        }
        public ActionResult Add(int? id, int? adet)
        {

            if (id != null)
            {
                if (Session["user"] != null)
                {
                    UserCard ucc = db.UserCards.FirstOrDefault(x => x.Product_ID == id);

                    if (ucc == null)
                    {
                        UserCard uc = new UserCard();
                        uc.User_ID = ((User)Session["user"]).ID;
                        uc.Product_ID = Convert.ToInt32(id);
                        uc.Quantity = adet ?? 1;
                        uc.CreationDate = DateTime.Now;
                        db.UserCards.Add(uc);
                        db.SaveChanges();
                    }
                    else
                    {
                        ucc.Quantity = ucc.Quantity + (adet ?? 1);
                        db.SaveChanges();
                    }

                }
                else
                {

                    return RedirectToAction("Login", "User");
                }

            }
            return RedirectToAction("Shop", "Home");
        }
        

        public ActionResult increase(int id)
        {
            UserCard uc = db.UserCards.Find(id);
            uc.Quantity += 1;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult decrease(int id)
        {
            UserCard uc = db.UserCards.Find(id);
            if (uc.Quantity != 1)
            {
                uc.Quantity -= 1;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Buyproducts()
        {
            if (Session["user"] != null)
            {
                int id = ((User)Session["user"]).ID;
                List<UserCard> userCartList = db.UserCards.Where(x => x.User_ID == id).ToList();

                ViewBag.semitotal = userCartList.Sum(x => x.Quantity * x.Product.Price) * 0.82m;
                ViewBag.totalTax = userCartList.Sum(x => x.Quantity * x.Product.Price) * 0.18m;
                ViewBag.total = userCartList.Sum(x => x.Quantity * x.Product.Price);
                return View();
            }
            return RedirectToAction("Login", "User");
        }
        [HttpPost]
        public ActionResult Buyproducts(PayViewModel model)
        {
            int id = ((User)Session["user"]).ID;
            List<UserCard> userCardList = db.UserCards.Where(x => x.User_ID == id).ToList();
            decimal price = userCardList.Sum(x => x.Quantity * x.Product.Price);

            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("https://localhost:44360/API/PayService");
                        PayServiceModel requesModel = new PayServiceModel()
                        {
                            MerchantCode = "123456789",
                            MerchantPassword = "1234567",
                            CardNo = model.CardNumber,
                            ExpM = model.ExpM,
                            ExpY = model.ExpY,
                            CVV = model.Cvv,
                            Price = price
                        };
                        var postTask = client.PostAsJsonAsync<PayServiceModel>("PayService", requesModel);
                        postTask.Wait();
                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var stringResp = result.Content.ReadAsStringAsync();
                            if (stringResp.Result == "\"101\"")
                            {
                                return RedirectToAction("PaySuccess", "USerCard");
                            }
                            else if (stringResp.Result == "\"401\"")
                            {
                                ViewBag.semitotal = userCardList.Sum(x => x.Quantity * x.Product.Price) * 0.82m;
                                ViewBag.totalTax = userCardList.Sum(x => x.Quantity * x.Product.Price) * 0.18m;
                                ViewBag.total = userCardList.Sum(x => x.Quantity * x.Product.Price);

                                ViewBag.result = "Bakiye Yetersiz";

                            }
                        }
                    }
                }
                catch
                {

                    
                }
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Paysuccess()
        {
            return View();
        }

        public ActionResult DeleteBasket(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            UserCard uc = db.UserCards.Find(id);

            db.UserCards.Remove(uc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult OrderDetail()
        {
            if (Session["user"] != null)
            {
                int id = ((User)Session["user"]).ID;
                return View(db.UserCards.Where(x => x.User_ID == id).ToList());
            }
            return RedirectToAction("Login", "User");
        }
    }
}