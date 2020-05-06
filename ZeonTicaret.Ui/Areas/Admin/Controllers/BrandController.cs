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
    public class BrandController : Controller
    {
        public ActionResult List()
        {
            var list = bBrand.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Brand model, HttpPostedFileBase foto)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                int resimId = 0;
                if (foto != null && foto.ContentLength > 0)
                {
                    string dir = Server.MapPath("~/Uploads/Brands/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var path = Path.Combine(dir, foto.FileName);
                    foto.SaveAs(path);
                    Photo resim = new Photo();
                    resim.Path = "/Uploads/Brands/" + foto.FileName;
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
                bBrand.Add(model);
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
            var data = bBrand.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult Update(Brand model, HttpPostedFileBase foto)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                int resimId = 0;
                if (foto != null && foto.ContentLength > 0)
                {
                    string dir = Server.MapPath("~/Uploads/Brands/");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    var path = Path.Combine(dir, foto.FileName);
                    foto.SaveAs(path);
                    Photo resim = new Photo();
                    resim.Path = "/Uploads/Brands/" + foto.FileName;
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
                bBrand.Update(model);
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
            bBrand.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}