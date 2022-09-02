using EventRequestApi.Models.Entities;

namespace EventRequestApi.Models
{
    public class EventDTO
    {
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual BillingAndShippingAddressDTO BillTo { get; set; } = null!;
        public virtual BillingAndShippingAddressDTO ShipTo { get; set; } = null!;
    }

    public class BillingAndShippingAddressDTO
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;
    }
}
