using StockExchange.Domain.Entities;
using StockExchange.Infrastructure.IRepositories;

namespace OrderExchange.Application.Services
{
    internal class OrderService
    {
        private readonly IGenericRepository<Order> _OrderRepository;

        public OrderService(IGenericRepository<Order> OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }


        public IEnumerable<Order> GetAll()
        {
            return _OrderRepository.GetAll();
        }

        public Order GetById(int id)
        {
            return _OrderRepository.GetById(id);
        }

        public void Insert(Order Order)
        {
            _OrderRepository.Insert(Order);
            _OrderRepository.Save();
        }

        public void Update(Order Order)
        {
            _OrderRepository.Update(Order);
            _OrderRepository.Save();
        }
        public void Delete(int id)
        {
            _OrderRepository.Delete(id);
            _OrderRepository.Save();
        }

        public Order GetByIdAsNoTracking(int id)
        {

            return _OrderRepository.GetByIdAsNoTracking(id);

        }
    }
}
