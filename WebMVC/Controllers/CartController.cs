using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Models.CartModels;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IIdentityService<ApplicationUser> _identityService;
        private readonly ICatalogService _catalogService;

        public CartController(ICartService cartService, IIdentityService<ApplicationUser> identityService , ICatalogService catalogService)
        {
            _cartService = cartService;
            _identityService = identityService;
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities, string action)
        {
            if (action == "[ Checkout ]")
            {
                return RedirectToAction("Create", "Order");
            }


            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(basket);

            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit  mode                 
                HandleBrokenCircuitException();
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(EventItem eventDetails)
        {
            try
            {
                if (eventDetails.Id > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var product = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        ProductName = eventDetails.Name,
                        PictureUrl = eventDetails.MainEventImageUrl,
                        UnitPrice = eventDetails.Price,
                        ProductId = eventDetails.Id.ToString()
                    };
                    await _cartService.AddItemToCart(user, product);
                }
                return RedirectToAction("Index", "EventCatalog");
            }
            catch (BrokenCircuitException)

            {
                // Catch error when CartApi is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "EventCatalog");
        }
            private void HandleBrokenCircuitException()
            {
                TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
            }
        
    }
}
