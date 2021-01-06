using CONBook.Data.Core.Interfaces;
using CONBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONBook.Data.Services.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDataContext applicationDataContext;

        public BookRepository(ApplicationDataContext applicationDataContext)
        {
            this.applicationDataContext = applicationDataContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await applicationDataContext.Books.ToListAsync();

            return books;
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            var book = await applicationDataContext.Books.FindAsync(id);

            if (book != null)
            {
                applicationDataContext.Entry(book).State = EntityState.Detached;
            }

            return book;
        }

        public async Task<string> AddAsync(Book book)
        {
            var bookAdded = await applicationDataContext.Books.AddAsync(book);

            await applicationDataContext.SaveChangesAsync();

            return bookAdded.Entity.Id;
        }

        public async Task UpdateAsync(Book book)
        {
            applicationDataContext.Books.Update(book);

            await applicationDataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            applicationDataContext.Books.Remove(book);

            await applicationDataContext.SaveChangesAsync();
        }
    }
}
