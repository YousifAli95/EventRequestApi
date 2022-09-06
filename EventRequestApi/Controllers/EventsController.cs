using Models;
using Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Dto;
using Contracts.Services;

namespace EventRequestApi.Controllers
{
    public class EventsController : ControllerBase
    {
        IEventService eventsService;

        public EventsController(IEventService eventsService)
        {
            this.eventsService = eventsService;
        }

        [HttpGet("/all-events")]
        public async Task<EventDto[]> GetAllEvents()
        {
            EventDto[] allEvents = await eventsService.GetAllEventsAsync();
            return allEvents;
        }


        [HttpPost("/add-event")]
        public HttpResponseMessage Post([FromBody] Event @event )
        {
            try
            {
                eventsService.AddEvent(@event);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

    }
    }

