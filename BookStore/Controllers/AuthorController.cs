using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        BookStoreEntities db = new BookStoreEntities();
        // GET: Author
        public PartialViewResult Author()
        {
            var authorBook = db.TacGias.ToList();
            return PartialView(authorBook);
        }
    }
}