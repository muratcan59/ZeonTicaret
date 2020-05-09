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
    public class CategoryController : Controller
    {
        public ActionResult List()
        {
            var list = bCategory.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Category model, HttpPostedFileBase foto)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                int resimId = 0;
                if (foto != null && foto.ContentLength > 0)
                {
                    string dir = Server.MapPath("~/Uploads/Categories/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var path = Path.Combine(dir, foto.FileName);
                    foto.SaveAs(path);
                    Photo resim = new Photo();
                    resim.Path = "/Uploads/Categories/" + foto.FileName;
                    bPhoto.Add(resim);
                    if (resim.Id != 0)
                    {
                        resimId = resim.Id;
                    }
                }
                if (resimId != 0)
                {
                    model.PhotoId = resimId;
                }
                bCategory.Add(model);
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
            var data = bCategory.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult Update(Category model, HttpPostedFileBase foto)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                int resimId = 0;
                if (foto != null && foto.ContentLength > 0)
                {
                    string dir = Server.MapPath("~/Uploads/Categories/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var path = Path.Combine(dir, foto.FileName);
                    foto.SaveAs(path);
                    Photo resim = new Photo();
                    resim.Path = "/Uploads/Categories/" + foto.FileName;
                    bPhoto.Add(resim);
                    if (resim.Id != 0)
                    {
                        resimId = resim.Id;
                    }
                }
                if (resimId != 0)
                {
                    model.PhotoId = resimId;
                }
                bCategory.Update(model);
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
            bCategory.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FeatureTypes()
        {
            var list = bFeatureType.GetAll();
            return View(list);
        }

        public ActionResult AddFeatureType()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddFeatureType(FeatureType model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {                
                bFeatureType.Add(model);
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

        public ActionResult UpdateFeatureType(int id)
        {
            var data = bFeatureType.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult UpdateFeatureType(FeatureType model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bFeatureType.Update(model);
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

        public JsonResult DeleteFeatureType(int id)
        {
            bFeatureType.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult FeatureValues()
        {
            var list = bFeatureValue.GetAll();
            return View(list);
        }

        public ActionResult AddFeatureValue()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddFeatureValue(FeatureValue model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bFeatureValue.Add(model);
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

        public ActionResult UpdateFeatureValue(int id)
        {
            var data = bFeatureValue.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult UpdateFeatureValue(FeatureValue model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bFeatureValue.Update(model);
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

        public JsonResult DeleteFeatureValue(int id)
        {
            bFeatureValue.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}