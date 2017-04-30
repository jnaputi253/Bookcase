using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Bookcase.Models.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly DbContext _dbContext;

        public DbSet<Book> Set => _dbContext.Set<Book>();

        public BookRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IQueryable<Book>> GetAll()
        {
            IQueryable<Book> books = Set.Include(book => book.Category);

            return Task.FromResult(books);
        }

        public Task<Book> FindById(int id)
        {
            return Set.FindAsync(id);
        }

        public async Task Update(Book updatedBook)
        {
            Book originalBook = this.FindById(updatedBook.BookID).Result;

            if (originalBook != null)
            {
                Set.Update(updatedBook);
                await Save();
            }
        }

        public async Task Remove(int id)
        {
            Book targetBook = this.FindById(id).Result;

            if (targetBook != null)
            {
                Set.Remove(targetBook);
                await Save();
            }
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

