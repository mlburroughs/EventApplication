using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;
using WebMVC.Models;
using WebMVC.ViewModels;

namespace WebMvc.ViewComponents
{
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public Cart(ICartService cartSvc) => _cartSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user) 
        {

            
            var vm = new CartComponentViewModdel();
            try
            {
                var cart = await _cartSvc.GetCart(user);

                vm.ItemsInCart = cart.Items.Count;
                vm.TotalCost = cart.Total();
                return View(vm);
            }
            catch(BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit mode
                ViewBag.IsBasketInoperative = true;
            }
            
            return View(vm);
        }

    }
}
