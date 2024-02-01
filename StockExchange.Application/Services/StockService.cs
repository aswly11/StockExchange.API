using Microsoft.AspNetCore.SignalR;
using StockExchange.Application.IServices;
using StockExchange.Domain.Entities;
using StockExchange.Infrastructure.IRepositories;


namespace StockExchange.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IGenericRepository<Stock> _stockRepository;
        public StockService(IGenericRepository<Stock> stockRepository)
        {
            _stockRepository = stockRepository;
        }       


        public IEnumerable<Stock> GetAll()
        {
            return _stockRepository.GetAll();
        }

        public Stock GetById(int id)
        {
            return _stockRepository.GetById(id);
        }

        public void Insert(Stock Stock)
        {
            _stockRepository.Insert(Stock);
            _stockRepository.Save();
        }

        public void Update(Stock Stock)
        {
            _stockRepository.Update(Stock);
            _stockRepository.Save();
        }
        public void Delete(int id)
        {
            _stockRepository.Delete(id);
            _stockRepository.Save();
        }

        public Stock GetByIdAsNoTracking(int id)
        {

            return _stockRepository.GetByIdAsNoTracking(id);

        }

    }
}
