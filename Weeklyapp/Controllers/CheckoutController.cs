using Microsoft.AspNetCore.Mvc;
using Weeklyapp.Services;
using Weeklyapp.DataLayer.Entities;
using Weeklyapp.DataLayer.Services.Data;

namespace Weeklyapp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly CheckoutService checkoutService;

        public CheckoutController(CheckoutService checkoutService)
        {
            this.checkoutService = checkoutService;
        }

        public IActionResult Details(int id)
        {
            var checkoutDetails = checkoutService.GetCheckoutDetails(id);
            if (checkoutDetails == null)
            {
                return NotFound();
            }
            return View(checkoutDetails);
        }
    }
}
