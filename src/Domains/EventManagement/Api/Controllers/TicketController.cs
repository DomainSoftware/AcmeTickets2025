using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AcmeTickets2025.Domains.EventManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;

        public TicketController(ILogger<TicketController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> RequestTickets([FromBody] TicketRequest request, [FromServices] NServiceBus.IMessageSession messageSession)
        {
            _logger.LogInformation("Received ticket request: {@Request}", request);
            var evt = new TicketRequestedEvent
            {
                Quantity = request.Quantity,
                EventId = request.EventId,
                CustomerId = request.CustomerId,
                RequestedAt = DateTime.UtcNow
            };
            await messageSession.Publish(evt);
            return Ok(new { message = "Ticket request received and event published." });
        }
    }

    public class TicketRequest
    {
        public int Quantity { get; set; }
        public string? EventId { get; set; }
        public string? CustomerId { get; set; }
    }

    public class TicketRequestedEvent : NServiceBus.IEvent
    {
        public int Quantity { get; set; }
        public string? EventId { get; set; }
        public string? CustomerId { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}
