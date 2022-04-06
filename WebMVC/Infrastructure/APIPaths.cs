using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllEventTypes(string baseUri)
            {

                return $"{baseUri}/EventTypes";
            }

            public static string GetAllEventCategories(string baseUri)
            {

                return $"{baseUri}/EventCategories";
            }

            public static string GetAllEventCities(string baseUri)
            {

                return $"{baseUri}/EventMetroCity";
            }

            public static string GetAllEventOrganizers(string baseUri)
            {

                return $"{baseUri}/EventOrganizer";
            }

            public static string GetAllEventItems(string baseUri, int page, int size, int? type, int? category, int? organizer, int? city)
            {
                var filterQs = string.Empty;
                var preUri = string.Empty;

                if (category.HasValue)
                {
                    filterQs = $"EventCategoryId={category.Value}";
                }

                if (organizer.HasValue)
                {
                    filterQs = $"EventOrganizerId={organizer.Value}";
                }
                if (city.HasValue)
                {
                    filterQs = $"EventMetroCityId={city.Value}";
                }

                if (type.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ?
                        $"EventTypeId={type.Value}" :
                        $"&EventCategoryId={type.Value}" +
                        $"&EventMetroCityId={city.Value}" +
                        $"&EventOrganizerId={organizer.Value}";

                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/items?pageIndex={page}&pageSize={size}";
                }
                else
                {
                    preUri = $"{baseUri}/items/filter?pageIndex={page}&pageSize={size}&{filterQs}";
                }
                return preUri;

            }
        }
    }
}
