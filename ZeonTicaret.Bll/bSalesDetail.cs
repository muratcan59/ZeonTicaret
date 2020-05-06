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
    public static class bSalesDetail
    {
        public static List<SalesDetail> GetAll()
        {
            var list = new List<SalesDetail>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.SalesDetails.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static SalesDetail GetById(int id)
        {
            var data = new SalesDetail();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.SalesDetails.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static SalesDetail Add(SalesDetail model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.SalesDetails.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static SalesDetail Update(SalesDetail model)
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
                var data = db.SalesDetails.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
