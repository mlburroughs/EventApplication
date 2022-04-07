using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class EventItem
    {
        //Basic Information
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventDateTime { get; set; }

        //Images
        public string MainEventImageUrl { get; set; }
        public string AdditionalEventImagesUrl1 { get; set; }
        public string AdditionalEventImagesUrl2 { get; set; }
        public string AdditionalEventImagesUrl3 { get; set; }
        public string AdditionalEventImagesUrl4 { get; set; }

        //Price
        public decimal Price { get; set; }
        public string RefundPolicy { get; set; }

        //Tags
        public string Tag1 { get; set; }
        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }

        //Foreign Keys
        public int EventTypeId { get; set; }
        public int EventCategoryId { get; set; }
        public int EventMetroCityId { get; set; }
        public int EventOrganizerId { get; set; }

        //Navigational Properties
        public string EventType { get; set; }
        public string  EventCategory { get; set; }
        public string EventMetroCity { get; set; }
        public string EventOrganizer { get; set; }

    }
}
