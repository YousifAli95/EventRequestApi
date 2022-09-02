﻿using System;
using System.Collections.Generic;

namespace EventRequestApi.Models.Entities
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }
        public int BillToId { get; set; }
        public int ShipToId { get; set; }

        public virtual BillingAndShippingAddress BillTo { get; set; } = null!;
        public virtual BillingAndShippingAddress ShipTo { get; set; } = null!;
    }
}
