using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Application.IServices;
using StockExchange.Application.Services;
using StockExchange.Domain.Entities;
using StockExchange.Services;

namespace StockExchange.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockController : ControllerBase
    {

        private readonly IStockService _stockService;
        private readonly IStockSignalRService _stockSignalRService;

        public StockController(IStockService stockService, IStockSignalRService stockSignalRService)
        {
            _stockService = stockService;
            _stockSignalRService = stockSignalRService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_stockService.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Stock = _stockService.GetById(id);
            if (Stock == null)
                return NotFound();

            return Ok(Stock);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Stock stock)
        {
            _stockService.Insert(stock);
          await  _stockSignalRService.StockChangeNotification(stock);
            return Ok(stock);

        }



        [HttpPut]
        public IActionResult Put([FromBody] Stock stock)
        {

            var Exist = _stockService.GetByIdAsNoTracking(stock.Id);
            if (Exist == null)
            {
                return NotFound("Stock Not Found");
            }

            _stockService.Update(stock);
            return Ok(stock);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Exist = _stockService.GetByIdAsNoTracking(id);
            if (Exist == null)
            {
                return NotFound("Stock Not Found");
            }
            _stockService.Delete(id);
            return Ok(id);

        }
    }

}
