using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeonTicaret.Bll;
using ZeonTicaret.Model;
using ZeonTicaret.Ui.Models;

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

        [HttpPost]
        public JsonResult Add(Product model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {               
                bProduct.Add(model);
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

        public ActionResult Update(int id)
        {
            var data = bProduct.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult Update(Product model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bProduct.Update(model);
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

        public JsonResult Delete(int id)
        {
            bProduct.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ProductFeatures()
        {
            var list = bProductFeature.GetAll();
            return View(list);
        }

        public ActionResult AddProductFeature()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddProductFeature(ProductFeature model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bProductFeature.Add(model);
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

        public ActionResult UpdateProductFeature(int id)
        {
            var data = bProductFeature.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult UpdateProductFeature(ProductFeature model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bProductFeature.Update(model);
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
    }
}