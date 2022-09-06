
using Contracts.Repositories;
using Contracts.Services;
using Dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EventService: IEventService
    {
        EventsContext _eventsContext;
        IEventRepository _eventRepository;


        public EventService(EventsContext eventsContext, IEventRepository eventRepository)
        {
            _eventsContext = eventsContext;
            this._eventRepository = eventRepository;
        }
        public async Task<EventDto[]> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }
        public void AddEvent(Event @event)
        {
            //Checking if shippping info already exists in the "BillOrShipInfo" table.
            var existingShippingInfo = GetBillOrShipInfoFromTable(@event.ShipTo);
            if (existingShippingInfo is not null)
            {
                @event.ShipTo = null;
                @event.ShipToId = existingShippingInfo.Id;
            }

            //Checking if billing info already exists in "BillOrShipInfo" the table. 
            var existingBillingInfo = GetBillOrShipInfoFromTable(@event.BillTo);
            if (existingBillingInfo is not null)
            {
                @event.BillTo = null;
                @event.BillToId = existingBillingInfo.Id;
            }
            
            _eventRepository.AddEvent(@event);
        }

        protected BillOrShipInfo? GetBillOrShipInfoFromTable(BillOrShipInfo billOrShipInfo)
        {
            return _eventsContext.BillOrShipInfos.
                SingleOrDefault(o => o.Name + o.Address + o.State + o.City + o.Zip ==
                billOrShipInfo.Name + billOrShipInfo.Address + billOrShipInfo.State + billOrShipInfo.City + billOrShipInfo.Zip);
        }
    }
}
