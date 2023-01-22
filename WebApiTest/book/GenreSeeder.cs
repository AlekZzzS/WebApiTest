using Microsoft.EntityFrameworkCore;
namespace WebApiTest.book


{
    public static class GenreSeeder
    {     
        public static void Seed(ApplicationDbContext db)
        {
            if (!db.Genres.Any())
            {
                db.Genres.AddRange(
                    new Genre { Name = "Fiction" },
                    new Genre { Name = "Non-Fiction" },
                    new Genre { Name = "Mystery" }
                );
                db.SaveChanges();
            }
        }
    }   
}
