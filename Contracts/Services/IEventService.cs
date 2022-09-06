using Dto;
using Models.Entities;

namespace Contracts.Services
{
    public interface IEventService
    {
        public void AddEvent(Event @event);

        public Task<EventDto[]> GetAllEventsAsync();
    }
}