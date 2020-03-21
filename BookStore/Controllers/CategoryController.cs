using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Category
        public PartialViewResult CategoryPartial()
        {
            var cateBook = db.ChuDes.ToList();
            return PartialView(cateBook);
        }

        public ViewResult categoryBook(int maChuDe = 0)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == maChuDe);
            if(cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> lstSach = db.Saches.Where(n => n.MaChuDe == maChuDe).OrderBy(n => n.GiaBan).ToList();
            if(lstSach.Count == 0)
            {
                ViewBag.Sach = "Khong co sach thuoc chu de nay";
            }
            return View(lstSach);
        }
    }
}