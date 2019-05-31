using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai1.Models;

namespace bai1.Controllers
{
    public class HomeController : Controller
    {
        WEBEntities1 db = new WEBEntities1();
        
            
        public ActionResult Index()
        {
            List<SanPham> lstproduct = db.SanPhams.Select(n => n).ToList();
            
            return View(lstproduct);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Detail(String id)
        {
            List<SanPham> list = (from sp in db.SanPhams where sp.MaSP == id select sp).ToList();
            return View(list);
        }
    }
}
