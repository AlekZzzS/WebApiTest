using Microsoft.AspNetCore.Mvc;
using WebApiTest.book;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
      
public GenresController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            return _db.Genres.ToList();
        }
    }
}
