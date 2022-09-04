using EventRequestApi.Models.Entities;

namespace EventRequestApi.Models
{
    public class EventDto
    {
        public string? Name { get; set; } 
        public string? Sku { get; set; } 
        public decimal? Price { get; set; }

        public BillingAndShippingAddressDto? BillTo { get; set; }
        public BillingAndShippingAddressDto? ShipTo { get; set; }
    }

    public class BillingAndShippingAddressDto
    {
        public string? Name { get; set; } 
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
    }
}
