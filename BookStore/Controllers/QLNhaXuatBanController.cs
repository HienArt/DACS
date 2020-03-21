using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
  
    public class QLNhaXuatBanController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: QLNhaXuatBan
        public ActionResult Index()
        {
            return View(db.NhaXuatBans.OrderBy(n => n.MaNXB).ToList());
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ThemMoi(NhaXuatBan nxb)
        {
            db.NhaXuatBans.Add(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ChinhSua(int MaNXB)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nxb);
        }
        [HttpPost]
        public ActionResult ChinhSua(NhaXuatBan nxb)
        {
            db.Entry(nxb).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Xoa(int MaNXB)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nxb);
        }

        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaNXB)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);

            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaXuatBans.Remove(nxb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}