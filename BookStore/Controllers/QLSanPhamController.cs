using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using System.IO;

namespace BookStore.Controllers
{
    [Authorize(Roles = "QuanTri")]
    public class QLSanPhamController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: QLSanPham
        public ActionResult Index()
        {
            return View(db.Saches.OrderBy(n=>n.MaSach).ToList());
        }
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(Sach sach,HttpPostedFileBase fileUpload)
        {
           
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe");
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB");
            if (fileUpload == null)
            {

                ViewBag.ThongBao = "Chon hinh anh";
                return View();
            }
            if (ModelState.IsValid)
            {
                //Luu ten file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Luu duong dan file
                var path = Path.Combine(Server.MapPath("~/HASP"), fileName);
                //Kiem tra hinh anh da ton tai chua 
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hinh ảnh đã tồn tại";

                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                sach.AnhBia = fileUpload.FileName;
                db.Saches.Add(sach);
                db.SaveChanges();
            }
            return View();
        }


        [HttpGet]
        public ActionResult ChinhSua(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if(sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe",sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB",sach.MaNXB);
            return View(sach);
        }
        [HttpPost]
        public ActionResult ChinhSua(Sach sach)
        {
            ViewBag.MaChude = new SelectList(db.ChuDes.ToList(), "MaChuDe", "TenChuDe",sach.MaChuDe);
            ViewBag.MaNXB = new SelectList(db.NhaXuatBans.ToList(), "MaNXB", "TenNXB",sach.MaNXB);                       
            db.Entry(sach).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();     
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sach);
        }

        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == MaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Saches.Remove(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}