using StockExchange.Domain.Entities;

namespace StockExchange.Application.IServices
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(int id);
        Order GetByIdAsNoTracking(int id);
        void Insert(Order novel);
        void Update(Order novel);
        void Delete(int id);

    }
}
