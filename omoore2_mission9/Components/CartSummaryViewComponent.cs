using Microsoft.AspNetCore.Mvc;
using omoore2_mission9.Models;
namespace omoore2_mission9.Components//This view component is for displaying the cart summary on the navbar
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}