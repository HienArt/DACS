using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        public ActionResult Index()
        {
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            ViewBag.MaTacGia = new SelectList(db.TacGias.ToList(), "MaTacGia", "TenTacGia");
            var sachMoi = db.Saches.Where(n=>n.Moi==1).ToList();
            return View(sachMoi);
        }


        [HttpPost]
        public ActionResult Index(int MaChuDe, int MaNXB,int MaTacGia)
        {
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            ViewBag.MaTacGia = new SelectList(db.TacGias.ToList(), "MaTacGia", "TenTacGia");
            var sach = db.Saches.Where(s => s.MaChuDe == MaChuDe && s.MaNXB == MaNXB && s.MaTacGia == MaTacGia);
            if (sach == null)
            {
                return RedirectToAction("Index", "Search");
            }
            return View(sach);
        }


        public ActionResult SachMoi()
        {
            var sachMoi = db.Saches.Take(3).ToList();
            return View(sachMoi);
        }

        //public ActionResult detailBook(int maSach = 0)
        //{
        //    Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == maSach);
        //    if (sach == null)
        //    {
        //        Response.StatusCode = 404;
        //        return null;
        //    }
        //    return View(sach);
        //}

        [HttpGet]
        public ActionResult detailBook(int maSach)
        {
            //Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == maSach);
            //if (sach == null)
            //{
            //    Response.StatusCode = 404;
            //    return null;
            //}
            var sach = db.Saches.Find(maSach);
            ViewBag.sach = sach;
            var review = new Review()
            {
                MaSach = sach.MaSach
            };
            return View("detailBook", review);
        }

        [HttpPost]
        public ActionResult SendReview(Review review, double rating)
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("dangNhap", "User");
            }
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            review.DatePost = DateTime.Now;
            review.MaKH = kh.MaKH;
            review.Rating = rating;
            db.Reviews.Add(review);
            db.SaveChanges();
            return RedirectToAction("detailBook", "Home", new { @maSach = review.MaSach });
        }

    }
}