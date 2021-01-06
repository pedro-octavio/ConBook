using CONBook.Data.Core.Interfaces;
using CONBook.Domain.Core.Interfaces;
using CONBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CONBook.Domain.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await bookRepository.GetAllAsync();

            return books;
        }

        public async Task<Book> GetByIdAsync(string id)
        {
            var book = await bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                throw new Exception("Book doens't exists.");
            }

            return book;
        }

        public async Task<string> AddAsync(Book book)
        {
            var bookId = await bookRepository.AddAsync(book);

            return bookId;
        }

        public async Task UpdateAsync(Book book)
        {
            await bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(string id)
        {
            var book = await GetByIdAsync(id);

            await bookRepository.DeleteAsync(book);
        }
    }
}
