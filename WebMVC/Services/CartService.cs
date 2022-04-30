using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        private readonly string _baseUrl;

        public CartService(IConfiguration config , IHttpClient client, IHttpContextAccessor httpContextAccessor )
        {
            _config = config;
            _apiclient = client;
            _httpContextAccessor = httpContextAccessor; // To access and read the token 
            _baseUrl = $"{config["CartUrl"]}/api/Cart";

        }
        public async  Task AddItemToCart(ApplicationUser user, CartItem product)
        {
            var cart = await GetCart(user);
            var basketItem = cart.Items.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if (basketItem == null)
            {
                cart.Items.Add(product);
            }
            else
            {
                basketItem.Quantity++;
            }

            await UpdateCart(cart);
           
        }

        public async Task ClearCart(ApplicationUser user)
        {
            var token = await GetUserToken();
            var clearBasketUrl = APIPaths.Basket.CleanBasket(_baseUrl, user.Email);
            await _apiclient.DeleteAsync(clearBasketUrl, token);
            
        }

        public async Task<Cart> GetCart(ApplicationUser user)
        {
            //1- get the token 
            //2- get the url to make the actual api call using the url sent from the web and the user id 
            //3- make the actual call and return the cart 

            var token = await GetUserToken();
            var getBasketUrl = APIPaths.Basket.GetBasket(_baseUrl, user.Email);
            var dataString = await _apiclient.GetStringAsync(getBasketUrl, token);

            var response = JsonConvert.DeserializeObject<Cart>(dataString) ??
                new Cart
                {
                    BuyerId = user.Email
                
                };

            return response;
           
        }

        public Order MapCartToOrder(Cart cart)
        {
            var order = new Order();
            order.OrderTotal = 0;

            cart.Items.ForEach(x =>
            {
                order.OrderItems.Add(new OrderItem()
                {
                    ProductId = int.Parse(x.ProductId),

                    PictureUrl = x.PictureUrl,
                    ProductName = x.ProductName,
                    Units = x.Quantity,
                    UnitPrice = x.UnitPrice
                });
                order.OrderTotal += (x.Quantity * x.UnitPrice);
            });

            return order;
        }


        public async Task<Cart> UpdateCart(Cart cart)
        {
            var token =await  GetUserToken();
            var updateBasketUrl = APIPaths.Basket.UpdateBasket(_baseUrl);
            var response= await _apiclient.PostAsync(updateBasketUrl, cart, token);

            response.EnsureSuccessStatusCode();

            return cart;
        }

        private async Task<string> GetUserToken()
        {
            var context = _httpContextAccessor.HttpContext;
            return await context.GetTokenAsync("access token");
        }

        public async Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {
            var basket = await GetCart(user);
            basket.Items.ForEach(x =>
            { 
                if (quantities.TryGetValue(x.Id, out var quantity))
                 { 
                    x.Quantity = quantity;
                 }
            });

            return basket;
            
        }
    }
}
