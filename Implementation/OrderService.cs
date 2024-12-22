using SportsEvent.Domain.Domain;
using SportsEvent.Repository.Implementation;
using SportsEvent.Repository.Interface;
using SportsEvent.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Service.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository orderRepository;


        public OrderService(IOrderRepository orderRepository)
        { 
            this.orderRepository = orderRepository;
        }


        public List<Order> GetAllOrders()
        {
            return this.orderRepository.GetAllOrders();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return orderRepository.GetDetailsForOrder(id);
        }
    }
}
