using StockExchange.Domain.Entities;

namespace StockExchange.Services
{
    public interface IStockSignalRService
    {
        Task StockChangeNotification(List<Stock> stocks);



        Task UpdateStockPrice(string stockSymbol, decimal newPrice);
        Task NewOrder(string stockSymbol, string orderType, int quantity);
    }
}
