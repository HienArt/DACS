using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
   
    public class QLTacGiaController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: QLTacGia
        public ActionResult Index()
        {
            return View(db.TacGias.OrderBy(n => n.MaTacGia).ToList());
        }

        public ActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(TacGia tg)
        {
            db.TacGias.Add(tg);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaTacGia)
        {
            TacGia tg = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tg);
        }

        [HttpPost]
        public ActionResult ChinhSua(TacGia tg)
        {
            db.Entry(tg).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaTacGia)
        {
            TacGia tg = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(tg);
        }

        [HttpPost,ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaTacGia)
        {

            TacGia tg = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (tg == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TacGias.Remove(tg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}