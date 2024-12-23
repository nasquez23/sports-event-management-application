using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsEvent.Domain.Domain;
using SportsEvent.Service.Interface;

namespace SportsEventApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {


        private readonly IOrderService _orderService;   



        public AdminController(IOrderService orderService) 
        {
            
            this._orderService= orderService;   
        }

        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return this._orderService.GetAllOrders();
        }


        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return this._orderService.GetDetailsForOrder(id);
        }




    }
}
