using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using cactus.DataAccess.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cactus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }

        [HttpGet]
        public async Task<List<Book>> Get()
        {
            var books = await _bookService.GetBooks();
            return books;
        }
        [HttpGet]
        [Route("getbyId")]
        public async Task<Book> Get(int id)
        {
            var book = await _bookService.GetBookById(id);
            return book;
        }

        [HttpPost]
        public async Task<Book> Post([FromBody] Book book)
        {
            return await _bookService.CreateBook(book);
        }
    }
}
