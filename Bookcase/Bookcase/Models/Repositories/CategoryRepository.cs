using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookcase.Models.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly DbContext _dbContext;

        public DbSet<Category> Set => _dbContext.Set<Category>();

        public CategoryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<Category>> GetAll()
        {
            return Task.FromResult(Set.AsQueryable());
        }

        public async Task<Category> FindById(int id)
        {
            return await Set.FindAsync(id);
        }

        public async Task Update(Category updatedModel)
        {
            var targetCategory = Set.FindAsync(updatedModel.CategoryID);

            if (targetCategory != null)
            {
                Set.Update(updatedModel);
                await Save();
            }
        }

        public async Task Remove(int id)
        {
            Category targetCategory = Set.FindAsync(id).Result;

            if (targetCategory != null)
            {
                Set.Remove(targetCategory);
                await Save();
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
