using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventOrganizer
    {
        public int Id { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerImageUrl { get; set; }
        public string OrganizerBio { get; set; }
        public string OrganizerPageUrl { get; set; }
    }
}
