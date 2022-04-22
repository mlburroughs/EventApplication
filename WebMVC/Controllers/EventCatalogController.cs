using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;
using Microsoft.AspNetCore.Authorization;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly ICatalogService _service;

        public EventCatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int?page, int?typeFilterApplied, int? categoryFilterApplied, int?organizerFilterApplied, int? cityFilterApplied)
        {
            var itemsOnPage = 6;

            var catalog= await _service.GetEventItemsAsync(page ?? 0,itemsOnPage, typeFilterApplied, categoryFilterApplied, organizerFilterApplied, cityFilterApplied);

            var viewmodel = new EventCatalogIndexViewModel
            {
                EventTypes = await _service.GetEventTypesAsync(),
                EventCategories = await _service.GetEventCategoriesAsync(),
                EventOrganizers = await _service.GetEventOrganizers(),
                EventMetroCities = await _service.GetEventCitiesAsync(),
                EventItems = catalog.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = catalog.PageIndex,
                    ItemsPerPage = catalog.PageSize,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage),

                       // Use these properties to keep the state of the page 
                    TypeFilterApplied = typeFilterApplied,
                    CategoryFilterApplied = categoryFilterApplied,
                    OrganizerFilterApplied = organizerFilterApplied,
                    CityFilterApplied = cityFilterApplied
                },

                // Use these properties to keep the state of the page 
                TypeFilterApplied = typeFilterApplied,
                CategoryFilterApplied= categoryFilterApplied,
                OrganizerFilterApplied= organizerFilterApplied,
                CityFilterApplied= cityFilterApplied
            };
           
            return View(viewmodel);
        }

        [Authorize]
        public IActionResult About()
        {
            return View();
        }
    }
}
