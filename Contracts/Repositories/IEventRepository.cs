﻿using Dto;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repositories
{
        public interface IEventRepository
        {
            public void AddEvent(Event @event);

            public Task<EventDto[]> GetAllEventsAsync();
    }
}
