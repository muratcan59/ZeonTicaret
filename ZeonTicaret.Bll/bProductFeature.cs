using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeonTicaret.Dal;
using ZeonTicaret.Model;

namespace ZeonTicaret.Bll
{
    public static class bProductFeature
    {
        public static List<ProductFeature> GetAll()
        {
            var list = new List<ProductFeature>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.ProductFeatures.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static ProductFeature GetById(int id)
        {
            var data = new ProductFeature();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.ProductFeatures.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static ProductFeature Add(ProductFeature model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.ProductFeatures.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static ProductFeature Update(ProductFeature model)
        {
            model.UpdateDate = DateTime.Now;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            return model;
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var data = db.ProductFeatures.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
