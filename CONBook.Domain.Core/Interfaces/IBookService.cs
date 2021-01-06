using CONBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONBook.Domain.Core.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(string id);
        Task<string> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(string id);
    }
}
