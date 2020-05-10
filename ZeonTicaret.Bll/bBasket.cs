using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeonTicaret.Dal;
using ZeonTicaret.Model;

namespace ZeonTicaret.Bll
{
    public static class bBasket
    {
        public static Basket Add(Basket model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                if (db.Baskets.Any(x => x.ProductId == model.ProductId))
                {
                    db.Baskets.FirstOrDefault(x => x.ProductId == model.ProductId).Amount++;
                }
                else
                {
                    db.Baskets.Add(model);
                }               
                db.SaveChanges();
            }
            return model;
        }

        public static double Sum()
        {
            double toplam = 0;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                toplam = db.Baskets.Sum(x => x.Price);
            }
            return toplam;
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var data = db.Baskets.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
