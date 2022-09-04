using EventRequestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace EventRequestApi.Models
{
    public class EventsService
    {
        EventsContext _eventsContext;

        public EventsService(EventsContext eventsContext)
        {
            this._eventsContext = eventsContext;
        }

        internal void AddEvent(EventDto eventDto)
        {       

            string serializedEvent = JsonSerializer.Serialize(eventDto);
            Event @event = JsonSerializer.Deserialize<Event>(serializedEvent);
            _eventsContext.Events.Add(@event);
            _eventsContext.SaveChanges();

        }

        internal async Task<EventDto[]> GetAllEventsAsync()
        {
            return await _eventsContext.Events.Select(o => new EventDto
            {
                Name = o.Name,
                Sku = o.Sku,
                Price = o.Price,
                BillTo = new BillingAndShippingAddressDto
                {
                    Address = o.BillTo.Address,
                    Name = o.BillTo.Name,
                    State = o.BillTo.State,
                    Zip = o.BillTo.Zip,
                    City = o.BillTo.City,

                },
                ShipTo = new BillingAndShippingAddressDto
                {
                    Address = o.ShipTo.Address,
                    Name = o.ShipTo.Name,
                    State = o.ShipTo.State,
                    Zip = o.ShipTo.Zip,
                    City = o.ShipTo.City,
                }

            }).ToArrayAsync();
        }
    }
}
