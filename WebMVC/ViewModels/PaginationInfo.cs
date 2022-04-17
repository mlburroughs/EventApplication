using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels
{
    public class PaginationInfo
    {
        public long TotalItems { get; set; }
        public int ItemsPerPage { get; set; }

        public int ActualPage { get; set; }
        public int TotalPages { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }

        public int? TypeFilterApplied { get; set; }
        public int? CategoryFilterApplied { get; set; }
        public int? OrganizerFilterApplied { get; set; }
        public int? CityFilterApplied { get; set; }

    }
}
