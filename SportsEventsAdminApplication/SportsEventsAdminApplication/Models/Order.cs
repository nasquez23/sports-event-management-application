namespace SportsEventsAdminApplication.Models
{
    public class Order
    {


        public Guid Id { get; set; }    
        public string? userId { get; set; }
        public SportsEventApplicationUser? Owner { get; set; }
        public IEnumerable<TicketInOrder>? TicketsInOrder { get; set; }

    }
}
