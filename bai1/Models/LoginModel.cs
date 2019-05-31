using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace bai1.Models
{
    public class LoginModel
    {
        [Display(Name ="Username ")]
        [Required(ErrorMessage ="You must input Username.")]
        public string TenND { get; set; }
        [Display(Name = "Password ")]
        [Required(ErrorMessage = "You must input Password.")]
        public string MatKhau { get; set; }
    }
    public class Validation
    {
        WEBEntities1 db = new WEBEntities1();
        public Boolean checkUser(String tenND)
        {
            //viet cau truy van
            return db.NguoiDungs.Count(x => x.TenND == tenND) == 1;
        }
        public Boolean checkMatKhau(String matKhau)
        {
            //viet cau truy van
            return db.NguoiDungs.Count(x => x.MatKhau == matKhau) ==1;
        }
    }
}