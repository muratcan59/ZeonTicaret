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
    public static class bBrand
    {
        public static List<Brand> GetAll()
        {
            var list = new List<Brand>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Brands.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static Brand GetById(int id)
        {
            var data = new Brand();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Brands.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static Brand Add(Brand model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Brands.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Brand Update(Brand model)
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
                var data = db.Brands.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
