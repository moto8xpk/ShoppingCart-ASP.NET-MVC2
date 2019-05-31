using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace bai1.Models
{
    public class CartModel
    {
        [Key]
        public long MaHD { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "You must input the Address.")]
        public String DiaChi { get; set; }
    }
}