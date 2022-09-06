namespace Dto
{
    public class EventDto
    {
        public string? Name { get; set; }
        public string? Sku { get; set; }
        public decimal? Price { get; set; }

        public BillOrShipDto? BillTo { get; set; }
        public BillOrShipDto? ShipTo { get; set; }
    }
}