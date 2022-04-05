using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
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
        public async Task<IActionResult> EventItems(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items = await _context.Events
                                .OrderBy(c => c.Name)
                                .Skip(pageIndex * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> EventItems(
            [FromQuery] int? eventTypeId,
            [FromQuery] int? eventCategoryId,
            [FromQuery] int? eventMetroCityId,
            [FromQuery] int? eventOrganizerId,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<EventItem>)_context.Events;
            if (eventTypeId.HasValue)
            {
                query = query.Where(c => c.EventTypeId == eventTypeId);
            }
            if (eventCategoryId.HasValue)
            {
                query = query.Where(c => c.EventCategoryId == eventCategoryId);
            }
            if (eventMetroCityId.HasValue)
            {
                query = query.Where(c => c.EventMetroCityId == eventMetroCityId);
            }
            if (eventOrganizerId.HasValue)
            {
                query = query.Where(c => c.EventOrganizerId == eventOrganizerId);
            }
            var itemsCount = _context.Events.LongCountAsync();
            var items = await query
                                .OrderBy(c => c.Name)
                                .Skip(pageIndex * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };
            return Ok(model);
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
