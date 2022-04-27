using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CartAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart),(int)HttpStatusCode.OK)]
        public async Task<IActionResult>Get(string id)
        {
            var basket= await _repository.GetCartAsync(id);
            return Ok(basket);
        }

      
    }
}
