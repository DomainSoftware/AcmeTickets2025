namespace AcmeTickets2025.Domains.EventManagement.Shared.Events
{
    public class TicketRequestedEvent
    {
        public int Quantity { get; set; }
        public string? EventId { get; set; }
        public string? CustomerId { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
