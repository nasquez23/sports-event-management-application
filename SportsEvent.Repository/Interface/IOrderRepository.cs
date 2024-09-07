using SportsEvent.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsEvent.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetDetailsForOrder(BaseEntity id);
       
    }
}
