using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Migrations.Web.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(int id);
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
