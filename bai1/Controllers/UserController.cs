using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai1.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Security;
using System.Security.Claims;
using WebMatrix.WebData;
using System.Security.Cryptography;
using bai1.Models;
using bai1.Dao;

namespace bai1.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "MaND,TenND,MatKhau,Email,SoDienThoai,DiaChi")] RegisterModel user)
        {
            WEBEntities1 db = new WEBEntities1();
            ValidationUser val = new ValidationUser();

            NguoiDung nd = new NguoiDung();

            //nd.MaND = user.MaND;
            nd.TenND = user.TenND;
            nd.MatKhau = Encryptor.MD5Hash(user.MatKhau);
            nd.Email = user.Email;
            nd.SoDienThoai = user.SoDienThoai;
            nd.DiaChi = user.DiaChi;


            if (ModelState.IsValid)
            {
                if (!val.checkUser(user.TenND) || !val.checkEmail(user.Email))
                {
                    db.NguoiDungs.Add(nd);
                    db.SaveChanges();
                    //FormsAuthentication.RedirectFromLoginPage(user.TenND, false);
                    return RedirectToAction("Register");
                }
                else
                {
                    ModelState.AddModelError("Register", "Invalid user or password");
                }
            }
            return View("Fail");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel user)
        {
            NguoiDung nguoiDung = new NguoiDung();
            String a1= Encryptor.MD5Hash(user.MatKhau);
            if (ModelState.IsValid)
            {
                using (WEBEntities1 db = new WEBEntities1())
                {
                    var v = db.NguoiDungs.Where(a => a.TenND.Equals(user.TenND) && a.MatKhau.Equals(a1)).FirstOrDefault();
                    if(v!=null)
                    {
                        Session["LogedMaND"] = v.MaND.ToString();
                        Session["LogedTenND"] = v.TenND.ToString();
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            return View(nguoiDung);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","User");
            
        }

        public ActionResult AfterLogin()
        {
            if(Session["LogedTenND"]!=null)
            {
                return View();
            }
            else
            return RedirectToAction("Login");
        }
    }
}