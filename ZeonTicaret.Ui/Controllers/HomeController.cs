using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeonTicaret.Bll;

namespace ZeonTicaret.Ui.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Basket()
        {
            return PartialView();
        }

        public PartialViewResult Sliders()
        {
            var list = bPhoto.GetAllSliders();
            return PartialView(list);
        }

        public PartialViewResult NewProducts()
        {
            var list = bPhoto.GetAllProducts();
            return PartialView(list);
        }

        public PartialViewResult Services()
        {
            return PartialView();
        }

        public PartialViewResult Brands()
        {
            var list = bBrand.GetAll();
            return PartialView(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}