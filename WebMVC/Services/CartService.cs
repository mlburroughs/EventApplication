using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;
using WebMVC.Models.CartModels;
using WebMVC.Models.OrderModels;

namespace WebMVC.Services
{
    public class CartService : ICartService
    {
        private readonly IConfiguration _config;
        private readonly IHttpClient _apiclient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IConfiguration config , IHttpClient client, IHttpContextAccessor httpContextAccessor )
        {
            _config = config;
            _apiclient = client;
            _httpContextAccessor = httpContextAccessor;

        }
        public Task AddItemToCart(ApplicationUser user, Dictionary<string, int> quantities)
        {
            throw new NotImplementedException();
        }

        public Task ClearCart(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> GetCart(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Order MapCartToOrder(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> SetQuantities(Cart cart)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> UpdateCart(Cart cart)
        {
            throw new NotImplementedException();
        }
    }
}
