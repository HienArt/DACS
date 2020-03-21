using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{

    //[Authorize(Roles = "QuanTri")]
    public class SearchController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Search

        [HttpPost]
        public ActionResult ResultSearch(FormCollection f)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Khong co ket qua tim kiem nao";
                return View(db.Saches.OrderBy(n => n.TenSach));
            }

            return View(lstKQTK.OrderBy(n=>n.TenSach));
        }



        public ActionResult Index()
        {
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            ViewBag.MaTacGia = new SelectList(db.TacGias.ToList(), "MaTacGia", "TenTacGia");
            var sach = db.Saches.ToList();
            return View(sach);
        }

        [HttpPost]
        public ActionResult Index(int MaChuDe,int MaNXB,int MaTacGia)
        {
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            ViewBag.MaTacGia = new SelectList(db.TacGias.ToList(), "MaTacGia", "TenTacGia");
            var sach = db.Saches.Where(s => s.MaChuDe == MaChuDe && s.MaNXB == MaNXB && s.MaTacGia == MaTacGia);
            return View(sach);
        }
    }
}