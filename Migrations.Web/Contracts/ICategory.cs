using Migrations.Web.Models.NorthwindDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Migrations.Web.Contracts
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetOne(int id);
        void CreateCategory(Category item);
        void UpdateCategory(Category item);
        void DeleteCategory(Category item);
    }
}
