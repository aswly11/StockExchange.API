using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace StockExchange.Hubs
{
    [Authorize]
    public class StockHub : Hub
    {
        // The hub method for broadcasting stock prices to all connected clients
        public async Task BroadcastStockPrice(string stockSymbol, decimal price)
        {
            await Clients.All.SendAsync("ReceiveStockPrice", stockSymbol, price);
        }

        // The hub method for broadcasting order information to all connected clients
        public async Task BroadcastOrder(string stockSymbol, string orderType, int quantity)
        {
            await Clients.All.SendAsync("ReceiveOrder", stockSymbol, orderType, quantity);
        }
    }
}
