using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai1.Models;

namespace bai1.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppingCart/
        private WEBEntities1 db = new WEBEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Delete(String id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");
        }
        public ActionResult SaveCart(String id)
        {
            WEBEntities1 db = new WEBEntities1();

            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");
        }
        public ActionResult OrderNow(String id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.SanPhams.Find(id),1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List <Item>)Session["cart"];
                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(db.SanPhams.Find(id), 1));
                else
                    cart[index].Quantity++;
                Session["cart"] = cart;
            }
            return View("Cart");
        }
        [HttpPost]
        public ActionResult OrderNow( CartModel cart1)
        {
            WEBEntities1 db = new WEBEntities1();
            HoaDon HD = new HoaDon();
            ThongTinHoaDon TTHD = new ThongTinHoaDon();
            String b;
            b = Session["LogedMaND"].ToString();

            long a;
            a = Convert.ToInt64(b);

            HD.NgayLap = DateTime.Now;
            HD.MaND = a;
            HD.DiaChi = cart1.DiaChi;

            String a1;
            String a2;
            String a3;
            String aMaHD="0";
            a1 = HD.NgayLap.ToString();
            a2 = HD.MaND.ToString();
            a3 = HD.DiaChi.ToString();


            string studentName;
            if (ModelState.IsValid)
            {

                db.HoaDons.Add(HD);
                db.SaveChanges();

                //using (var ctx = new WEBEntities1())
                //{
                //    //Get student name of string type
                //    studentName = ctx.Database.SqlQuery<string>("Select MaHD from HoaDon where MaND = "+a2+",NgayLap ='"+a1+"'").FirstOrDefault<string>();
                // }
                HoaDon a5;
                using (var ctx = new WEBEntities1())
                {
                    
                    List<HoaDon> listHD = (from hd in db.HoaDons  select hd).ToList<HoaDon>();
                    a5 = listHD.Last();
                }
                
                foreach (Item item in (List<Item>)Session["cart"])
                {
                    TTHD.MaSP = item.Sanpham.MaSP;
                    TTHD.SoLuong = item.Quantity;
                    TTHD.Gia = item.Sanpham.Gia;
                    TTHD.MaHD = a5.MaHD;
                    if (ModelState.IsValid)
                    {

                        db.ThongTinHoaDons.Add(TTHD);
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index", "Home");


            }
            else
                return View("Fail", "User");


        }
        private int isExisting(String id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for(int i=0;i<cart.Count;i++)
            
                if(cart[i].Sanpham.MaSP==id)
                {
                    return i;
                }
            return -1;
            
        }
        //private long getMaHD(long mand, DateTime ngaylap)
        //{
        //    WEBEntities1 db = new WEBEntities1();


        //    return db.HoaDons.Select(h => h.MaND.Equals(mand) && h.NgayLap.Equals(ngaylap));
        //}
    }

}
