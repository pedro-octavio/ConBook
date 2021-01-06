using AutoMapper;
using CONBook.Application.Core.Interfaces;
using CONBook.Application.DTOs.RequestDTOs;
using CONBook.Application.DTOs.ResponseDTOs;
using CONBook.Domain.Core.Interfaces;
using CONBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONBook.Application.Services.Services
{
    public class BookApplicationService : IBookApplicationService
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookApplicationService(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<GetAllBooksDTO>> GetAllAsync()
        {
            var books = await bookService.GetAllAsync();

            return mapper.Map<IEnumerable<GetAllBooksDTO>>(books);
        }

        public async Task<GetBookDTO> GetByIdAsync(string id)
        {
            var book = await bookService.GetByIdAsync(id);

            return mapper.Map<GetBookDTO>(book);
        }

        public async Task<string> AddAsync(AddBookDTO bookDTO)
        {
            var book = mapper.Map<Book>(bookDTO);

            book.Id = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 10);

            return await bookService.AddAsync(book);
        }

        public async Task UpdateAsync(UpdateBookDTO bookDTO)
        {
            var book = mapper.Map<Book>(bookDTO);

            await bookService.UpdateAsync(book);
        }

        public async Task DeleteAsync(string id)
        {
            await bookService.DeleteAsync(id);
        }
    }
}
