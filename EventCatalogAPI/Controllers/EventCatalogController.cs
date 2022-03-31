using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;

        public EventCatalogController(EventContext context,IConfiguration configuration)
        {
            _context = context;
            _config = configuration;

        }
        [HttpGet("[action]")]
        public async Task<IActionResult> EventCategories() //The name of the thread
        {
            //This task (thread) will query the data base and get all the event categories and convert them to a list 
            var categories = await _context.EventCategories.ToListAsync();
            return Ok(categories);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var types = await _context.EventTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventMetroCity()
        {
            var cities = await _context.EventMetroCities.ToListAsync();
            return Ok(cities);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventOrganizer()
        {
            var organizers = await _context.EventOrganizers.ToListAsync();
            return Ok(organizers);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventItem(
            [FromQuery]int pageIndex=0, 
            [FromQuery]int pageSize=3)
        {
            var items= await _context.Events
                 .OrderBy(e => e.Name)
                 .Skip(pageIndex * pageSize)
                 .Take(pageSize)
                 .ToListAsync();

            items= ChangePictureUrl(items);
            return Ok(items);
            
        }
        
        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {
            items.ForEach(item => 
            item.MainEventImageUrl=item.MainEventImageUrl.Replace("http://externalcatalogbaseurltobereplaced",
            _config["Externalbaseurl"]));

            return (items);
        }
    }
}
