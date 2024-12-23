namespace SportsEventsAdminApplication.Models
{
    public class ShoppingCart
    {

        public string? OwnerId { get; set; }

        public SportsEventApplicationUser? Owner { get; set; }

        public virtual ICollection<TicketInShoppingCart>? TicketsInShoppingCarts { get; set; }
    }
}
