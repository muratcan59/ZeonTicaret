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
    public static class bCargo
    {
        public static List<Cargo> GetAll()
        {
            var list = new List<Cargo>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Cargos.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static Cargo GetById(int id)
        {
            var data = new Cargo();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Cargos.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static Cargo Add(Cargo model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Cargos.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Cargo Update(Cargo model)
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
                var data = db.Cargos.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
