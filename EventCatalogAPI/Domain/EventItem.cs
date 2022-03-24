using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{

    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string MainEventImageUrl { get; set; }
        public List<string> AdditionalEventImagesUrls { get; set; }
        public decimal Price { get; set; }
        public ImmutableList<string> RefundPolicy { get; set; }
        public List<string> Tags { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

        public int EventCategoryId { get; set; }
        public virtual EventCategory EventCategory { get; set; }

        public int EventMetroCityId { get; set; }
        public virtual EventMetroCity EventMetroCity { get; set; }

        public int EventOrganizerId { get; set; }
        public EventOrganizer EventOrganizerName { get; set; }
    }
}
