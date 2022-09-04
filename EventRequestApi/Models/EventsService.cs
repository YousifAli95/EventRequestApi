using EventRequestApi.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

            //Checking if shippping info already exists in the table.
            var existingShippingInfo = GetBillOrShipInfoFromTable(@event.ShipTo);
            if(existingShippingInfo is not null)
            {
                @event.ShipTo = null;
                @event.ShipToId = existingShippingInfo.Id;
            }

            //Checking if billing info already exists in the table.
            var existingBillingInfo = GetBillOrShipInfoFromTable(@event.BillTo);
            if (existingBillingInfo is not null)
            {
                @event.BillTo = null;
                @event.BillToId = existingBillingInfo.Id;
            }

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

        protected BillOrShipInfo? GetBillOrShipInfoFromTable(BillOrShipInfo billOrShipInfo) {
            return _eventsContext.BillOrShipInfos.
                SingleOrDefault(o => o.Name + o.Address + o.State + o.City + o.Zip ==
                billOrShipInfo.Name + billOrShipInfo.Address + billOrShipInfo.State + billOrShipInfo.City + billOrShipInfo.Zip);

        }
    }
}
