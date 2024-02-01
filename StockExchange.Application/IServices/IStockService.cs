using StockExchange.Domain.Entities;

namespace StockExchange.Application.IServices
{
    public interface IStockService
    {
        IEnumerable<Stock> GetAll();
        Stock GetById(int id);
        Stock GetByIdAsNoTracking(int id);
        void Insert(Stock novel);
        void Update(Stock novel);
        void Delete(int id);

    }
}
