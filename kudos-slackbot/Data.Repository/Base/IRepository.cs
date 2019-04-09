namespace Data.Repository.Base
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync(params object[] args);

        Task InsertAsync(T entity);
    }
}
