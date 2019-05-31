using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace bai1.Models
{
    public class RegisterModel
    {
        [Key]
        public long MaND { get; set; }

        [Display(Name="Username")]
        [Required(ErrorMessage ="You must input the Username.")]
        public String TenND { get; set; }

        [Display(Name = "Password")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Password lenght must more than 6 character.")]
        [Required(ErrorMessage = "You must input the Password.")]
        public String MatKhau { get; set; }
        //[Display(Name = "Confirm Password")]
        //[Compare("Password",ErrorMessage ="Confirm Password and Password aren't sync.")]
        //public String ConfirmPassword { get; set; }
        [Display(Name = "Email Address")]
        public String Email { get; set; }
        [Display(Name = "Phone Number")]
        public String SoDienThoai { get; set; }
        [Display(Name = "Address")]
        public String DiaChi { get; set; }


    }
    public class ValidationUser
    {
        WEBEntities1 db = new WEBEntities1();
        public Boolean checkUser(String tenND)
        {
            //viet cau truy van
                return db.NguoiDungs.Count(x => x.TenND == tenND) > 0;
        }
        public Boolean checkEmail(String email)
        {
            //viet cau truy van
            return db.NguoiDungs.Count(x => x.Email == email) > 0;
        }
    }
}