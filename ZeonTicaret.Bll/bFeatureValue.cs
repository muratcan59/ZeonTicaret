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
    public static class bFeatureValue
    {
        public static List<FeatureValue> GetAll()
        {
            var list = new List<FeatureValue>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.FeatureValues.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static List<FeatureValue> GetFeatureValueByTypes(int fTypeId)
        {
            var list = new List<FeatureValue>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.FeatureValues.Where(x => x.IsDelete == false && x.FeatureTypeId == fTypeId).ToList();
            }
            return list;
        }

        public static FeatureValue GetById(int id)
        {
            var data = new FeatureValue();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.FeatureValues.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static FeatureValue Add(FeatureValue model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.FeatureValues.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static FeatureValue Update(FeatureValue model)
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
                var data = db.FeatureValues.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
