using Microsoft.Exchange.WebServices.Data;
using SportsEvent.Domain.Domain;
using SportsEvent.Domain.DTO;
using SportsEvent.Repository.Interface;
using SportsEvent.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsEvent.Domain;
using EmailMessage = SportsEvent.Domain.EmailMessage;


namespace SportsEvent.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {

        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<TicketInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<TicketInOrder> _ticketInOrderRepository;
        private readonly IEmailService _emailService;
        private readonly IRepository<Order> _orderRepository;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<TicketInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository, IRepository<Ticket> ticketRepository, IRepository<TicketInOrder> ticketInOrderRepository, IEmailService emailService, IRepository<Order> orderRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _ticketInOrderRepository = ticketInOrderRepository;
            _emailService = emailService;
            _orderRepository = orderRepository;
        }

        public bool AddToShoppingConfirmed(TicketInShoppingCart model, string userId)
        {
            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser.ShoppingCart;


            if(userShoppingCart.TicketsInShoppingCarts==null)
            {
                userShoppingCart.TicketsInShoppingCarts=new List<TicketInShoppingCart>();    
            }

            userShoppingCart.TicketsInShoppingCarts.Add(model);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public bool deleteTicketFromShoppingCart(string userId, Guid ticketId)
        {
            if(ticketId!=null)
            {
                var loggedInUser= _userRepository.Get(userId);
                var userShoppingCart = loggedInUser.ShoppingCart;
                var ticket=userShoppingCart?.TicketsInShoppingCarts?.Where(x=>x.TicketId==ticketId).FirstOrDefault();
            
            userShoppingCart?.TicketsInShoppingCarts?.Remove(ticket);

                _shoppingCartRepository.Update(userShoppingCart);
                return true;
            
            
            
            }

            return false;
        }

        public ShoppingCartDTO getShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);
            var userShoppingCart = loggedInUser?.ShoppingCart;

            var allTickets = userShoppingCart?.TicketsInShoppingCarts?.ToList();

            var totalPrice = allTickets.Select(x => (x.Ticket.Price * x.Quantity)).Sum();

            ShoppingCartDTO dto = new ShoppingCartDTO
            {
                Tickets = allTickets,
                TotalPrice = totalPrice,
            };
            return dto;
        }

        public bool order(string userId)
        {
            if(userId!=null)
            {
                var loggedInUser= this._userRepository.Get(userId);

                var userShoppingCart=loggedInUser?.ShoppingCart;
               EmailMessage message = new EmailMessage();
                message.Subject = "Successfull Order";
                message.MailTo = loggedInUser.Email;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    userId = userId,
                    Owner = loggedInUser
                };
                _orderRepository.Insert(order);

                List<TicketInOrder> ticketInOrder = new List<TicketInOrder>();

                var lista = userShoppingCart.TicketsInShoppingCarts.Select(
                    x => new TicketInOrder
                    {
                        Id = Guid.NewGuid(),
                        TicketId = x.Ticket.Id,
                        Ticket = x.Ticket,
                        OrderId = order.Id,
                        Order = order,
                        Quantity = x.Quantity
                    }
                    ).ToList();


                StringBuilder sb = new StringBuilder();

                var totalPrice = 0.0;

                sb.AppendLine("Your order is completed. The order conatins: ");

                for (int i = 1; i <= lista.Count(); i++)
                {
                    var currentItem = lista[i - 1];
                    totalPrice += currentItem.Quantity * currentItem.Ticket.Price;
                    sb.AppendLine(i.ToString() + ". " + currentItem.Ticket.MatchId + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Ticket.Price);
                }

                sb.AppendLine("Total price for your order: " + totalPrice.ToString());
               message.Content = sb.ToString();

                ticketInOrder.AddRange(lista);

                foreach (var product in ticketInOrder)
                {
                    _ticketInOrderRepository.Insert(product);
                }

                loggedInUser.ShoppingCart.TicketsInShoppingCarts.Clear();
                _userRepository.Update(loggedInUser);
                 this._emailService.SendEmailAsync(message);

                return true;
            }
            return false;
        }
    }
}


