using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bai1.Models;

namespace bai1.Models
{
    public class Item
    {
        private SanPham sanpham = new SanPham();
        private int quantity;

        public Item() { }
        public Item(SanPham sanpham,int quantity)
        {

            this.sanpham = sanpham;
            this.quantity = quantity;

        }
        public SanPham Sanpham
        {
            get { return sanpham; }
            set { sanpham = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

    }
}