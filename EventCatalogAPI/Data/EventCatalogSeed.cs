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
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/1",
                              Price=12.99M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Flowers",
                              Tag2="Family Friendly",
                              EventTypeId=11,
                              EventCategoryId=4,
                              EventMetroCityId=25,
                              EventOrganizerId=2
                              },

                new EventItem{Name="Midwest Marathon",
                              Description="Run the streets of Chicago!",
                              EventDateTime = new DateTime(2022, 08, 20, 6, 0, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/2",
                              Price=79.99M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Marathon",
                              Tag2="Run",
                              EventTypeId=6,
                              EventCategoryId=20,
                              EventMetroCityId=9,
                              EventOrganizerId=4
                              },

                new EventItem{Name="South Bay Hackathon",
                              Description="Compete for $5000 prize, network, and meet exciting tech companies looking for talented developers. " +
                                          "Price includes admission, swag, and catered lunch.",
                              EventDateTime = new DateTime(2022, 07, 1, 11, 0, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/3",
                              Price=29.00M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Technology",
                              Tag2="Hackathon",
                              Tag3="Programming",
                              EventTypeId=19,
                              EventCategoryId=18,
                              EventMetroCityId=12,
                              EventOrganizerId=5
                              },

                new EventItem{Name="Winter Holiday Market",
                              Description="FREE ADMISSION. Find holidayc gifts form a variety of local vendors",
                              EventDateTime = new DateTime(2022, 12, 4, 12, 0, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/4",
                              Price=0.00M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Winter",
                              Tag2="Shopping",
                              EventTypeId=11,
                              EventCategoryId=19,
                              EventMetroCityId=11,
                              EventOrganizerId=5
                              },

                new EventItem{Name="Designing the James Webb Telescope",
                              Description="Join us for an evening with NASA's chief scientist to discover " +
                              "the history, present state in orbit, and future expectations of the James Webb Telescope.",
                              EventDateTime = new DateTime(2022, 6, 1, 7, 30, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/5",
                              Price=24.50M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Technology",
                              Tag2="Space",
                              Tag3="Telescope",
                              Tag4="James Webb",
                              EventTypeId=3,
                              EventCategoryId=18,
                              EventMetroCityId=14,
                              EventOrganizerId=5
                              },

                new EventItem{Name="Tour de Boise",
                              Description="Idaho's cycling event of the year.",
                              EventDateTime = new DateTime(2022, 10, 18, 5, 30, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/6",
                              Price=129.50M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Race",
                              EventTypeId=6,
                              EventCategoryId=20,
                              EventMetroCityId=6,
                              EventOrganizerId=4
                              },

                new EventItem{Name="Portland Music and Art Festival",
                              Description="Variety of music, vendors, and art exhibits showcasing Portland's local talent.",
                              EventDateTime = new DateTime(2022, 8, 1, 14, 00, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/7",
                              Price=29.50M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Music",
                              Tag2="Art",
                              EventTypeId=11,
                              EventCategoryId=13,
                              EventMetroCityId=23,
                              EventOrganizerId=5
                              },

                new EventItem{Name="Country Music Concert",
                              Description="Lineup of 3 award-winning country artists.",
                              EventDateTime = new DateTime(2023, 3, 1, 18, 00, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/8",
                              Price=59.50M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Music",
                              EventTypeId=15,
                              EventCategoryId=13,
                              EventMetroCityId=17,
                              EventOrganizerId=5
                              },

                new EventItem{Name="Women in Technology Meetup",
                              Description="Join us for an evening of networking with other women in tech.",
                              EventDateTime = new DateTime(2022, 5, 12, 18, 00, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/9",
                              Price=0.00M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Technology",
                              EventTypeId=9,
                              EventCategoryId=2,
                              EventMetroCityId=25,
                              EventOrganizerId=5
                              },

                new EventItem{Name="Pike Place Market Tour",
                              Description="Explore shops and stalls while learning about this famous " +
                              "Seattle landmark",
                              EventDateTime = new DateTime(2022, 6, 12, 18, 00, 0),
                              MainEventImageUrl ="http://externalcatalogbaseurltobereplaced/api/pic/10",
                              Price=0.00M,
                              RefundPolicy="Placeholder",//come back
                              Tag1="Technology",
                              EventTypeId=2,
                              EventCategoryId=4,
                              EventMetroCityId=25,
                              EventOrganizerId=5
                              }


            };
        }

    }
}
