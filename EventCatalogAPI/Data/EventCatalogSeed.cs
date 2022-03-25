using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventCatalogSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();//Runs all or updates migrations that have not been applied

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetEventTypes()); // Bulk Insert
                context.SaveChanges();
            }

            if (!context.EventCategories.Any())
            {
                context.EventCategories.AddRange(GetEventCategories()); // Bulk Insert
                context.SaveChanges();
            }

            if (!context.EventMetroCities.Any())
            {
                context.EventMetroCities.AddRange(GetEventMetroCities()); // Bulk Insert
                context.SaveChanges();
            }

            if (!context.EventOrganizers.Any())
            {
                context.EventOrganizers.AddRange(GetEventOrganizers()); // Bulk Insert
                context.SaveChanges();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange(GetEvents()); // Bulk Insert
                context.SaveChanges();
            }
        }

        //Adding Event Types
        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                new EventType{Type="Appearance/Signing"},
                new EventType{Type="Attraction"},
                new EventType{Type="Camp/Trip/Retreat"},
                new EventType{Type="Class/Training/Workshop"},
                new EventType{Type="Concert/Performance"},
                new EventType{Type="Conference"},
                new EventType{Type="Convention"},
                new EventType{Type="Dinner/Gala"},
                new EventType{Type="Festival/Fair"},
                new EventType{Type="Game/Competition"},
                new EventType{Type="Meeting/Networking Event"},
                new EventType{Type="Other"},
                new EventType{Type="Party/Social Gathering"},
                new EventType{Type="Race/Endurance Event"},
                new EventType{Type="Rally"},
                new EventType{Type="Screening"},
                new EventType{Type="Seminar/Talk"},
                new EventType{Type="Tour"},
                new EventType{Type="Tournament"},
                new EventType{Type="Exposition"}
            };
        }

        //Adding Event Categories
        private static IEnumerable<EventCategory> GetEventCategories()
        {
            return new List<EventCategory>
            {
                new EventCategory{Category="Auto/Boat/Air"},
                new EventCategory{Category="Business/Professional"},
                new EventCategory{Category="Charity/Causes"},
                new EventCategory{Category="Community/Culture"},
                new EventCategory{Category="Family/Education"},
                new EventCategory{Category="Fashion/Beauty"},
                new EventCategory{Category="Film/Media/Entertainment"},
                new EventCategory{Category="Food/Drink"},
                new EventCategory{Category="Government/Politics"},
                new EventCategory{Category="Health/Wellness"},
                new EventCategory{Category="Hobbies/Special Interest"},
                new EventCategory{Category="Home/Lifestyle"},
                new EventCategory{Category="Music"},
                new EventCategory{Category="Other"},
                new EventCategory{Category="Performing/Visual Arts"},
                new EventCategory{Category="Religion/Spirituality"},
                new EventCategory{Category="School Activites"},
                new EventCategory{Category="Science/Technology"},
                new EventCategory{Category="Seasonal/Holiday"},
                new EventCategory{Category="Sports/Fitness"},
                new EventCategory{Category="Travel/Outdoor"},
            };
        }

        //Adding Event MetroCities
        private static IEnumerable<EventMetroCity> GetEventMetroCities()
        {
            return new List<EventMetroCity>
            {
                new EventMetroCity{MetroCity="Atlanta"},
                new EventMetroCity{MetroCity="Austin"},
                new EventMetroCity{MetroCity="Boise"},
                new EventMetroCity{MetroCity="Boston"},
                new EventMetroCity{MetroCity="Charlotte"},
                new EventMetroCity{MetroCity="Chicago"},
                new EventMetroCity{MetroCity="Dallas/Fort Worth"},
                new EventMetroCity{MetroCity="Denver"},
                new EventMetroCity{MetroCity="Houston"},
                new EventMetroCity{MetroCity="Las Vegas"},
                new EventMetroCity{MetroCity="Los Angeles"},
                new EventMetroCity{MetroCity="Miami"},
                new EventMetroCity{MetroCity="Minneapolis/Saint Paul"},
                new EventMetroCity{MetroCity="Nashville"},
                new EventMetroCity{MetroCity="New Orleans"},
                new EventMetroCity{MetroCity="New York City"},
                new EventMetroCity{MetroCity="Orlando"},
                new EventMetroCity{MetroCity="Philadelphia"},
                new EventMetroCity{MetroCity="Phoenix"},
                new EventMetroCity{MetroCity="Portland"},
                new EventMetroCity{MetroCity="Saint Louis"},
                new EventMetroCity{MetroCity="Salt Lake City"},
                new EventMetroCity{MetroCity="San Diego"},
                new EventMetroCity{MetroCity="San Francisco/San Jose/Oakland"},
                new EventMetroCity{MetroCity="Seattle/Tacoma"},
            };
        }

        //Adding Event Organizers - More to be added
        private static IEnumerable<EventOrganizer> GetEventOrganizers()
        {
            return new List<EventOrganizer>
            {
                new EventOrganizer{OrganizerName="A-List Events"},
                new EventOrganizer{OrganizerName="Fun Runs"},
                new EventOrganizer{OrganizerName="County Fair"},
                new EventOrganizer{OrganizerName="Seattle Tulip Festival"},
                new EventOrganizer{OrganizerName="Science Fiction Convention"},
            };
        }

        //Adding Events - More to be added
        private static IEnumerable<EventItem> GetEvents()
        {
            return new List<EventItem>
            {
                new EventItem{Name="5th Annual Seattle Tulip Festival",
                              Description="Join us for the 5th Annual Tulip Festival!",
                              EventDateTime = new DateTime(2022, 05, 27, 10, 0, 0),
                              MainEventImageUrl ="Placeholder",//come back
                              Price=12.99M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Flowers",
                              Tag2="Family Friendly",
                              EventTypeId=8,
                              EventCategoryId=7,
                              EventMetroCityId=12,
                              EventOrganizerId=4
                              }
            };
        }

    }
}
