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

        internal void AddEvent(string serializedJsonObject)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            Event events = JsonSerializer.Deserialize<Event>(serializedJsonObject, options);

            var jsonObject = JObject.Parse(serializedJsonObject);
            var serializedShipTo = (jsonObject["shipTo"]).ToString();
            var serializedBillTo = (jsonObject["billTo"]).ToString();

            BillingAndShippingAddress shippingInformation = JsonSerializer.Deserialize<BillingAndShippingAddress>(serializedShipTo, options);
            BillingAndShippingAddress billingInformation = JsonSerializer.Deserialize<BillingAndShippingAddress>(serializedBillTo, options);

            _eventsContext.BillingAndShippingAddresses.Add(shippingInformation);
            _eventsContext.BillingAndShippingAddresses.Add(billingInformation);
            _eventsContext.SaveChanges();

            events.BillToId = billingInformation.Id;
            events.ShipToId = shippingInformation.Id;
            _eventsContext.Events.Add(events);
            _eventsContext.SaveChanges();

        }

        internal async Task<EventDTO[]> GetAllEventsAsync()
        {
            return await _eventsContext.Events.Select(o => new EventDTO
            {
                Name = o.Name,
                Sku = o.Sku,
                Price = o.Price,
                BillTo = new BillingAndShippingAddressDTO
                {
                    Address = o.BillTo.Address,
                    Name = o.BillTo.Name,
                    State = o.BillTo.State,
                    Zip = o.BillTo.Zip,
                    City = o.BillTo.City,

                },
                ShipTo = new BillingAndShippingAddressDTO
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
