using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class QLChuDeController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: QLChuDe
        public ActionResult Index()
        {
            return View(db.ChuDes.OrderBy(n => n.MaChuDe).ToList());
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemMoi(ChuDe cd)
        {
            db.ChuDes.Add(cd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaChuDe)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }
        [HttpPost]
        public ActionResult ChinhSua(ChuDe cd)
        {
                db.Entry(cd).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaChuDe)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(cd);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaChuDe)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
         
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.Remove(cd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}