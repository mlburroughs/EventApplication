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
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime EventTime { get; set; }
        public string MainEventImageUrl { get; set; }
        public List<string> AdditionalEventImagesUrls { get; set; }
        public decimal Price { get; set; }
        public ImmutableList<string> RefundPolicy { get; set; }
        public List<string> EventTags { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

        public int EventCatagoryId { get; set; }
        public virtual EventCatagory EventCatagory { get; set; }
    }
}
