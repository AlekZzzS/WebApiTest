using Microsoft.AspNetCore.Mvc;
using WebApiTest.book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BooksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return _db.Books.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = _db.Books.Find(id);
            if 

            (book == null)
    {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            Console.WriteLine("start");
            _db.Books.Add(book);
            _db.SaveChanges();
            return CreatedAtAction("Get", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {
            var existingBook = _db.Books.Find(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Title = book.Title;
            existingBook.YearOfPublication = book.YearOfPublication;
            existingBook.Genre = book.Genre;
            existingBook.Authors = book.Authors;
            existingBook.Edition = book.Edition;
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
