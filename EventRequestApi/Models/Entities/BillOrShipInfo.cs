using System;
using System.Collections.Generic;

namespace EventRequestApi.Models.Entities
{
    public partial class BillOrShipInfo
    {
        public BillOrShipInfo()
        {
            EventBillTos = new HashSet<Event>();
            EventShipTos = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;

        public virtual ICollection<Event> EventBillTos { get; set; }
        public virtual ICollection<Event> EventShipTos { get; set; }
    }
}
