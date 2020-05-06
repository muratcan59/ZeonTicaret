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
    public static class bOrderStatus
    {
        public static List<OrderStatus> GetAll()
        {
            var list = new List<OrderStatus>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.OrderStatuses.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static OrderStatus GetById(int id)
        {
            var data = new OrderStatus();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.OrderStatuses.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static OrderStatus Add(OrderStatus model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.OrderStatuses.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static OrderStatus Update(OrderStatus model)
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
                var data = db.OrderStatuses.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
