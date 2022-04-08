using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class CatalogService: ICatalogService

    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;

        public CatalogService(IConfiguration config , IHttpClient client)
        {

            _baseUrl = $"{config["EventCatalogUrl"]}/api/EventCatalog";
            _client = client;
        }

        // Fills in the Event Categories drop down list 

        public async Task<IEnumerable<SelectListItem>> GetEventCategoriesAsync()
        {
            var EventCategoryUrl= APIPaths.Catalog.GetAllEventCategories(_baseUrl);
            var dataString = await _client.GetStringAsync(EventCategoryUrl);

            var items = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                     Value=null,
                     Text = "All",
                     Selected=true

                 }

            };
            var categories= JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = category.Value<string>("id"),
                    Text= category.Value<string>("category")
                    
                }) ;

            }
            return items;
        }

        // Fills in the Event Types drop down list 

        public async Task<IEnumerable<SelectListItem>> GetEventTypesAsync()
        {
            var EvenTypeUrl = APIPaths.Catalog.GetAllEventTypes(_baseUrl);
            var dataString = await _client.GetStringAsync(EvenTypeUrl);

            var items = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                     Value=null,
                     Text = "All",
                     Selected=true

                 }

            };
            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(new SelectListItem
                {
                    Value = type.Value<string>("id"),
                    Text = type.Value<string>("type")

                });

            }
            return items;
        }

        // Fills in the Event Metro Cities drop down list 

        public async Task<IEnumerable<SelectListItem>> GetEventCitiesAsync()
        {
            var EventCityUrl = APIPaths.Catalog.GetAllEventCities(_baseUrl);
            var dataString = await _client.GetStringAsync(EventCityUrl);

            var items = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                     Value=null,
                     Text = "All",
                     Selected=true

                 }

            };
            var cities = JArray.Parse(dataString);
            foreach (var city in cities)
            {
                items.Add(new SelectListItem
                {
                    Value = city.Value<string>("id"),
                    Text = city.Value<string>("metroCity")

                });

            }
            return items;
        }

        // Fills in the Event Organizers drop down list 

        public async Task<IEnumerable<SelectListItem>> GetEventOrganizers()
        {
            var EventOrgUrl = APIPaths.Catalog.GetAllEventCities(_baseUrl);
            var dataString = await _client.GetStringAsync(EventOrgUrl);

            var items = new List<SelectListItem>
            {
                 new SelectListItem
                 {
                     Value=null,
                     Text = "All",
                     Selected=true

                 }

            };
            var organizers = JArray.Parse(dataString);
            foreach (var organizer in organizers)
            {
                items.Add(new SelectListItem
                {
                    Value = organizer.Value<string>("id"),
                    Text = organizer.Value<string>("organizerName")

                });

            }
            return items;
        }

        public async Task<EventCatalog> GetEventItemsAsync(int page , int size , int? type, int? category,  int?organizer, int?city)
        {
            var EventItemUrl = APIPaths.Catalog.GetAllEventItems(_baseUrl,page,size,type,category,organizer,city );
            var dataString = await _client.GetStringAsync(EventItemUrl);
            return JsonConvert.DeserializeObject<EventCatalog>(dataString);
        }
    }
}
