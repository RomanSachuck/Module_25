namespace Module25.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int? UserId {  get; set; } 
        public User? User { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
