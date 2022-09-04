using EventRequestApi.Models.Entities;

namespace EventRequestApi.Models
{
    public class EventDto
    {
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public decimal Price { get; set; }

        public virtual BillingAndShippingAddressDto BillTo { get; set; } = null!;
        public virtual BillingAndShippingAddressDto ShipTo { get; set; } = null!;
    }

    public class BillingAndShippingAddressDto
    {
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;
    }
}
