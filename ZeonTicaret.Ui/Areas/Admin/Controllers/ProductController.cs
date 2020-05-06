using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeonTicaret.Bll;

namespace ZeonTicaret.Ui.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult List()
        {
            var list = bProduct.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }
    }
}