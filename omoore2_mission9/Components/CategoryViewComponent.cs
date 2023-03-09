using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using omoore2_mission9.Models;
//Manages the category page
namespace omoore2_mission9.Components
{
    public class CategoryViewComponent : ViewComponent
    {

        private IBookRepository repo { get; set; }
        public CategoryViewComponent (IBookRepository temp)
        {
            repo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookCategory"];
            var cats = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cats);
        }
    }
}
