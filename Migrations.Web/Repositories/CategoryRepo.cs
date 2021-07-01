using Migrations.Web.Contracts;
using Migrations.Web.Models.NorthwindDB;
using Migrations.Web.Models.NorthwindDB.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Migrations.Web.Repositories
{
    public class CategoryRepo : RepositoryBase<Category>, ICategory
    {
        public CategoryRepo(NorthwindContext context) : base(context)
        {
        }

        public void CreateCategory(Category item)
        {
            Create(item);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await FindAll();
        }

        public async Task<Category> GetOne(int id)
        {
            return await FindById(id);
        }

        public void UpdateCategory(Category item)
        {
            Update(item);
        }

        public void DeleteCategory(Category item)
        {
            Delete(item);
        }
    }
}
