using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeonTicaret.Bll;
using ZeonTicaret.Model;
using ZeonTicaret.Ui.Models;

namespace ZeonTicaret.Ui.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sliders()
        {
            var list = bPhoto.GetAllSliders();
            return View(list);
        }

        public ActionResult AddSlider()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddSlider(Photo model, HttpPostedFileBase foto)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                if (foto != null && foto.ContentLength > 0)
                {
                    string dir = Server.MapPath("~/Uploads/Sliders/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var path = Path.Combine(dir, foto.FileName);
                    foto.SaveAs(path);
                    model.Path = "/Uploads/Brands/" + foto.FileName;
                    bPhoto.Add(model);
                }
                retVal.isSuccess = true;
                retVal.message = "Ekleme başarılı.";
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                retVal.isSuccess = false;
                retVal.message = ex.Message;
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult UpdateSlider(int id)
        {
            var data = bPhoto.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult UpdateSlider(Photo model, HttpPostedFileBase foto)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                if (foto != null && foto.ContentLength > 0)
                {
                    string dir = Server.MapPath("~/Uploads/Sliders/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var path = Path.Combine(dir, foto.FileName);
                    foto.SaveAs(path);
                    model.Path = "/Uploads/Brands/" + foto.FileName;
                    bPhoto.Update(model);
                }
                retVal.isSuccess = true;
                retVal.message = "Güncelleme başarılı.";
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                retVal.isSuccess = false;
                retVal.message = ex.Message;
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteSlider(int id)
        {
            bPhoto.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}