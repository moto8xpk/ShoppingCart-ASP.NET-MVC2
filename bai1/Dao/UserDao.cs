using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bai1.Models;


namespace bai1.Dao
{
    public class UserDao
    {
        WEBEntities1 db = null;
        public UserDao()
        {
            db = new WEBEntities1();    
        }
        public long Insert(NguoiDung entity)
        {
            db.NguoiDungs.Add(entity);
            db.SaveChanges();
            return entity.MaND;
        }
        public NguoiDung GetById(string userName)
        {
            return db.NguoiDungs.SingleOrDefault(x => x.TenND == userName);
        }

    }
    
}