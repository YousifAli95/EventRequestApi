using EventRequestApi.Models;
using EventRequestApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EventRequestApi.Controllers
{
    public class EventsController : ControllerBase
    {
        EventsService eventsService;

        public EventsController(EventsService eventsService)
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
        public HttpResponseMessage Post([FromBody] EventDto eventDTO )
        {
            try
            {
                eventsService.AddEvent(eventDTO);
                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

    }
    }

