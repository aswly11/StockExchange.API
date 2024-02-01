namespace StockExchange.Infrastructure.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        IQueryable<T> GetAll();
        T GetById(object id);
        T GetByIdAsNoTracking(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();

    }
}
