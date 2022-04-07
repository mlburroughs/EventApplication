using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface ICatalogService
    {
        public Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync();


        // Fills in the Event Types drop down list 

        public  Task<IEnumerable<SelectListItem>> GetEventTypesAsync();


        // Fills in the Event Metro Cities drop down list 

        public  Task<IEnumerable<SelectListItem>> GetEventCitiesAsync();


        // Fills in the Event Organizers drop down list 

        public  Task<IEnumerable<SelectListItem>> GetEventOrganizers();

        public Task<EventCatalog> GetEventItemsAsync(int page, int size, int? type, int? category, int? organizer, int? city);
        


    }
}
