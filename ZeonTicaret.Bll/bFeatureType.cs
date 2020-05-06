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
    public static class bFeatureType
    {
        public static List<FeatureType> GetAll()
        {
            var list = new List<FeatureType>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.FeatureTypes.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static FeatureType GetById(int id)
        {
            var data = new FeatureType();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.FeatureTypes.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static FeatureType Add(FeatureType model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.FeatureTypes.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static FeatureType Update(FeatureType model)
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
                var data = db.FeatureTypes.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
