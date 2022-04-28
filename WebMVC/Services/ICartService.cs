using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;
using WebMVC.Models.CartModels;
using WebMVC.Models.OrderModels;

namespace WebMVC.Services
{
    public interface ICartService
    {
        Task<Cart> GetCart(ApplicationUser user);
        Task<Cart> UpdateCart(Cart cart);
        Task<Cart> SetQuantities (ApplicationUser user, Dictionary<string,int> quantities);

        Task AddItemToCart(ApplicationUser user, CartItem product);

        Order MapCartToOrder(Cart cart);
        Task ClearCart(ApplicationUser user);
    }
}
