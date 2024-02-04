using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Application.IServices;
using StockExchange.Domain.Entities;

namespace OrderExchange.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_OrderService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Order = _OrderService.GetById(id);
            if (Order == null)
                return NotFound();

            return Ok(Order);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Order Order)
        {
            _OrderService.Insert(Order);
            
            return Ok(Order);

        }



        [HttpPut]
        public IActionResult Put([FromBody] Order Order)
        {

            var Exist = _OrderService.GetByIdAsNoTracking(Order.Id);
            if (Exist == null)
            {
                return NotFound("Order Not Found");
            }

            _OrderService.Update(Order);
            return Ok(Order);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Exist = _OrderService.GetByIdAsNoTracking(id);
            if (Exist == null)
            {
                return NotFound("Order Not Found");
            }
            _OrderService.Delete(id);
            return Ok(id);

        }
    }

}
