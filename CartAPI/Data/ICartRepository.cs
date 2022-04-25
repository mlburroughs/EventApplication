using CartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartAPI.Data
{
    public interface ICartRepository
    {
           Task<Cart> GetCartAsync(string cartId);
           Task<Cart> UpdateCartAsync(Cart basket);
           Task<bool> DeleteCartAsync(string cartId);

    }
}
