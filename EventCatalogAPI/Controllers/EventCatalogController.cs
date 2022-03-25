using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        private readonly EventContext _context;
        public EventCatalogController(EventContext context)
        {
            _context = context;
            
        }
        [HttpGet("action")]
        public async Task<IActionResult> EventCategories() // the name of the thread
        {
            //This task ( thread)will query the data base and get all the event categories and converet them to a list 
            var categories =await _context.EventCategories.ToListAsync();
            return Ok(categories);

        }

        [HttpGet("action")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

    }
}
