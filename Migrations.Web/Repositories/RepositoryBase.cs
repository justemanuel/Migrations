using Microsoft.EntityFrameworkCore;
using Migrations.Web.Contracts;
using Migrations.Web.Models.NorthwindDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Migrations.Web.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public NorthwindContext Context { get; set; }

        public RepositoryBase(NorthwindContext context)
        {
            Context = context;
        }

        public void Create(T item)
        {
            Context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            return await Context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> FindById(int id)
        {
            return await Context.Set<T>()
                .FindAsync(id);
        }

        public void Update(T item)
        {
            Context.Set<T>().Update(item);
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return await Context.Set<T>().AsNoTracking()
                .Where(expression)
                .ToListAsync();
        }
    }
}
