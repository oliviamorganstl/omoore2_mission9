using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using omoore2_mission9.Infrastructure;
using omoore2_mission9.Models;

namespace omoore2_mission9.Pages
{ //This page manages the classes for the Basket page
    public class BasketModel : PageModel
    {

        private IBookRepository repo { get; set; }

        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }
        public BasketModel(IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
        }

        public IActionResult OnPost(int bookID, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookID == bookID);

            //basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();

            basket.AddItem(b, 1, b.Price);

            //HttpContext.Session.SetJson("basket", basket);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookID, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookID == bookID).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
