using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai1.Models;

namespace bai1.Controllers
{
    public class DanhMucController : Controller
    {
        WEBEntities1 db = new WEBEntities1();
        public ActionResult danhmuc()
        {
            List<DanhMuc> listdanhmuc = db.DanhMucs.Select(n => n).ToList();

            return PartialView(listdanhmuc);   
        }
        public ActionResult Detail(String id)
        {
            List<SanPham> list = (from sp in db.SanPhams where sp.MaDM == id select sp).ToList();
            return View(list);
        }

    }
}
