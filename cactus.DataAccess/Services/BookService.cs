using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using cactus.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace cactus.DataAccess.Services
{
    public class BookService
    {
        public async Task<List<Book>> GetBooks()
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Books.ToListAsync();
            }
        }
        public async Task<Book> GetBookById(int bookId)
        {
            using (var dbContext = new cactusDbContext())
            {
                return await dbContext.Books.FindAsync(bookId);
            }
        }
        public async Task<Book> CreateBook(Book book)
        {
            using (var dbContext = new cactusDbContext())
            {
                dbContext.Books.Add(book);
                await dbContext.SaveChangesAsync();
                return book;
            }
        }
    }
}
