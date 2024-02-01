using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using StockExchange.Domain.Entities;
using StockExchange.Domain.Enums;
using StockExchange.Hubs;
using System.Text.Json;

namespace StockExchange.Services
{
    public class StockSignalRService : IStockSignalRService
    {
        private readonly IHubContext<StockHub> _hubContext;

        public StockSignalRService(IHubContext<StockHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task UpdateStockPrice(string stockSymbol, decimal newPrice)
        {
            // Update the stock price in your data store and then broadcast the update
            await _hubContext.Clients.All.SendAsync("ReceiveStockPrice", stockSymbol, newPrice);
        }

        public async Task NewOrder(string stockSymbol, string orderType, int quantity)
        {
            // Process the order and then broadcast the update
            await _hubContext.Clients.All.SendAsync("ReceiveOrder", stockSymbol, orderType, quantity);
        }

        public async Task StockChangeNotification(List<Stock> stocks)
        {
            await _hubContext.Clients.All.SendAsync("StockChangeNotification", stocks);
        }
    }
}
