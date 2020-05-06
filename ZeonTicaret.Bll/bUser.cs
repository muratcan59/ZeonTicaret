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
    public static class bUser
    {
        public static List<User> GetAll()
        {
            var list = new List<User>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Users.Where(x => x.IsDelete == false).ToList();
            }
            return list;
        }

        public static User GetById(string id)
        {
            var data = new User();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Users.FirstOrDefault(x => x.Id == id);
            }
            return data;
        }

        public static User Add(User model)
        {
            model.CreateDate = DateTime.Now;
            model.IsDelete = false;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Users.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static User Update(User model)
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
                var data = db.Users.Find(id);
                data.IsDelete = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }        
    }
}
