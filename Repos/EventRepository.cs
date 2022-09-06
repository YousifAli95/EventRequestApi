
using Contracts.Repositories;
using Dto;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Repos
{
    public class EventRepository: IEventRepository
    {
        EventsContext _eventsContext;

        public EventRepository(EventsContext eventsContext)
        {
            _eventsContext = eventsContext;
        }

        public void AddEvent(Event @event)
        {            
            _eventsContext.Events.Add(@event);
            _eventsContext.SaveChanges();
        }

        public async Task<EventDto[]> GetAllEventsAsync()
        {
            return await _eventsContext.Events.Select(o => new EventDto
            {
                Name = o.Name,
                Sku = o.Sku,
                Price = o.Price,
                BillTo = new BillOrShipDto
                {
                    Address = o.BillTo.Address,
                    Name = o.BillTo.Name,
                    State = o.BillTo.State,
                    Zip = o.BillTo.Zip,
                    City = o.BillTo.City,

                },
                ShipTo = new BillOrShipDto
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