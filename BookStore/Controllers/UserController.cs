using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult dangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult dangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
            }
            return RedirectToAction("dangKy");
        }


        [HttpGet]
        public ActionResult dangNhap()
        {
            return View();
        }


        [HttpPost]
        public ActionResult dangNhap(FormCollection f)
        {
            string staiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == staiKhoan && n.MatKhau == sMatKhau);
            if(kh != null)
            {
                //ViewBag.ThongBao = "Dang nhap thanh cong ";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index","Home");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            return View();
        }
    }
}