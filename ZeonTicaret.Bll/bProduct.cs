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
    public static class bProduct
    {
        public static List<Product> GetAll()
        {
            var list = new List<Product>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Products.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static Product GetById(int id)
        {
            var data = new Product();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Products.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static Product Add(Product model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Products.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Product Update(Product model)
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
                var data = db.Products.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
