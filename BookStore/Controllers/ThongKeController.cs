using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace BookStore.Controllers
{
    public class ThongKeController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: ThongKe
        public ActionResult Index()
        {
            ViewBag.Songuoitruycap = HttpContext.Application["Songuoitruycap"].ToString();//lay so luong nguoi truy cap tu application da duoc tao
            ViewBag.Songuoidangonline = HttpContext.Application["Songuoidangonline"].ToString();
            ViewBag.TongDH = ThongKeDH();
            ViewBag.TKDT = ThongKeDoanhThu();
            ViewBag.Thanhvien = ThongKeThanhVien();
            ViewBag.Chude = ThongKeCD();
            ViewBag.NXB = ThongKeNXB();
            ViewBag.Tacgia = ThongKeTG();
            ViewBag.Sach = ThongKeSanPham();
            ViewBag.Ngaygio = DateTime.Now;

            return View();
        }

        public double ThongKeDH()
        {
            double ddh = db.DonHangs.Count();
            return ddh;
        }


        public decimal ThongKeDoanhThu()
        {
            decimal TongDoanhThu = db.ChiTietDonHangs.Sum(n => n.SoLuong * n.DonGia).Value;
            return TongDoanhThu; // thống kê tổng doanh thu
        }

        public double ThongKeThanhVien()
        {
            // đếm đơn đặt hàng
            double sltv = db.KhachHangs.Count();
            return sltv;
        }


        public double ThongKeCD()
        {
            // đếm đơn đặt hàng
            double slncc = db.ChuDes.Count();
            return slncc;
        }
        public int ThongKeSanPham()
        {
            // đếm số lượng sản phẩm
            int sanpham = db.Saches.Sum(n => n.SoLuongTon).Value;
            return sanpham;
        }

        public int ThongKeNXB()
        {
            // đếm số lượng sản phẩm
            int sanpham = db.NhaXuatBans.Count();
            return sanpham;
        }

        public int ThongKeTG()
        {
            // đếm số lượng sản phẩm
            int sanpham = db.TacGias.Count();
            return sanpham;
        }

    }
}