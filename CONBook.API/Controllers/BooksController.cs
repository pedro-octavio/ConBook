using CONBook.Application.Core.Interfaces;
using CONBook.Application.DTOs.RequestDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CONBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookApplicationService bookApplicationService;

        public BooksController(IBookApplicationService bookApplicationService)
        {
            this.bookApplicationService = bookApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await bookApplicationService.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        {
            var book = await bookApplicationService.GetByIdAsync(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookDTO bookDTO)
        {
            var bookId = await bookApplicationService.AddAsync(bookDTO);

            return Ok(bookId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateBookDTO bookDTO)
        {
            await bookApplicationService.UpdateAsync(bookDTO);

            return Ok("Book updated successfully");
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(string id)
        {
            await bookApplicationService.DeleteAsync(id);

            return Ok("Book deleted successfully");
        }
    }
}
