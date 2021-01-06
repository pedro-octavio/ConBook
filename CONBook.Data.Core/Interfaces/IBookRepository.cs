using CONBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONBook.Data.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(string id);
        Task<string> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
    }
}
