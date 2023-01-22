namespace WebApiTest.book
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfPublication { get; set; }
        public string Genre { get; set; }
        public List<Author> Authors { get; set; }
        public int Edition { get; set; }
    }
}