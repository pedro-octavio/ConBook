using CONBook.Application.DTOs.RequestDTOs;
using CONBook.Application.DTOs.ResponseDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONBook.Application.Core.Interfaces
{
    public interface IBookApplicationService
    {
        Task<IEnumerable<GetAllBooksDTO>> GetAllAsync();
        Task<GetBookDTO> GetByIdAsync(string id);
        Task<string> AddAsync(AddBookDTO bookDTO);
        Task UpdateAsync(UpdateBookDTO bookDTO);
        Task DeleteAsync(string id);
    }
}
