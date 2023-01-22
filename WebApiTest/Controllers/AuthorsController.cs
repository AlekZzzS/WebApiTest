using Microsoft.AspNetCore.Mvc;
using WebApiTest.book;
using WebApiTest;

namespace WebApiTest.Controllers { 


public class AuthorsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

public AuthorsController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get()
    {
        return _db.Authors.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Author> Get(int id)
    {
        var author = _db.Authors.Find(id);
        if (author == null)
        {
            return NotFound();
        }
        return author;
    }

    [HttpPost]
    public ActionResult<Author> Post([FromBody] Author author)
    {
        _db.Authors.Add(author);
        _db.SaveChanges();
        return CreatedAtAction("Get", new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Author author)
    {
        var existingAuthor = _db.Authors.Find(id);
        if (existingAuthor == null)
        {
            return NotFound();
        }
        existingAuthor.Name = author.Name;
        existingAuthor.DateOfBirth = author.DateOfBirth;
        existingAuthor.Books = author.Books;
        _db.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var author = _db.Authors.Find(id);
        if (author == null)            
    {
            return NotFound();
        }
        _db.Authors.Remove(author);
        _db.SaveChanges();
        return NoContent();
    }
}
}
