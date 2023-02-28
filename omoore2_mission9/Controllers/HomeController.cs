using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using omoore2_mission9.Models;
using omoore2_mission9.Models.ViewModels;

namespace omoore2_mission9.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;

        public HomeController(IBookRepository temp)
        {
            repo = temp;
        }
        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = repo.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            var blah = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);

            return View(x);
        }

        //same thing as above, just in lambda form: public IActionResult Index() => View();
    }
}
