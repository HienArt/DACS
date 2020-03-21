using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class GioHang
    {
        BookStoreEntities db = new BookStoreEntities();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double thanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int maSach)
        {
            iMaSach = maSach;
            Sach sach = db.Saches.Single(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}