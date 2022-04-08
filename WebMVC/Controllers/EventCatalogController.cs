using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Services;

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
            var itemsOnPage = 5;
            var catalog= await _service.GetEventItemsAsync(page ?? 0,itemsOnPage, typeFilterApplied, categoryFilterApplied, organizerFilterApplied, cityFilterApplied);
           
            return View(catalog);
        }
    }
}
