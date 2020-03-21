using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class NXBController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
     
        public PartialViewResult nhaXuatBan()
        {
            var nxbBook = db.NhaXuatBans.ToList();
            return PartialView(nxbBook);
        }
    }
}