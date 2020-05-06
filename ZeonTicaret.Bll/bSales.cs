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
    public static class bSales
    {
        public static List<Sales> GetAll()
        {
            var list = new List<Sales>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Sales.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static Sales GetById(int id)
        {
            var data = new Sales();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Sales.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static Sales Add(Sales model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Sales.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Sales Update(Sales model)
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
                var data = db.Sales.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
