using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.ViewModels
{
    public class EventCatalogIndexViewModel
    {
        public IEnumerable<SelectListItem> EventTypes { get; set; }
        public IEnumerable<SelectListItem> EventCategories { get; set; }
        public IEnumerable<SelectListItem> EventOrganizers { get; set; }
        public IEnumerable<SelectListItem> EventMetroCities { get; set; }
        public IEnumerable<EventItem> EventItems { get; set; }

        public PaginationInfo PaginationInfo { get; set; }

        public int? TypeFilterApplied { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? OrganizerFilterApplied { get; set; }
        public int? CityFilterApplied { get; set; }


    }
}
