using Microsoft.EntityFrameworkCore;
using Module25.Entities;

namespace Module25.Repositories
{
    public class BookRepository : Repository<Book>
    {
        public BookRepository(AppContext db) : base(db) { }
        public override Book GetObject(int id) => _db.Books.FirstOrDefault(book => book.Id == id);
        public override List<Book> GetAllObjects() => _db.Books.ToList();
        public override void AddObject(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }
        public override void RemoveObject(Book book)
        {
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public void ChangeYearOfTheBookRelease(int id, int newReleaseYear)
        {
            var book = GetObject(id);
            book.YearOfRelease = newReleaseYear;
            _db.SaveChanges();
        }

        public void GiveBookToTheUser(int bookId, int userId)
        {
            if (GetObject(bookId).User == null)
            {
                var user = _db.Users.FirstOrDefault(u => u.Id == userId);
                user.Books.Add(GetObject(bookId));
                _db.SaveChanges();
            }
        }

        public List<Book> GetBookByGenreAndYears(string genre, int year1, int year2)
        {
            return _db.Books.Include(b => b.Genre)
                .Where(b => b.Genre.Name == genre && b.YearOfRelease >= year1 && b.YearOfRelease <= year2)
                .ToList();
        }

        public int GetAmountBookByAuthor(string lastNameAuthor)
        {
            return _db.Books.Include(b => b.Author)
                .Where(b => b.Author.LastName == lastNameAuthor)
                .Count();
        }

        public int GetAmountBookByGenre(string genre)
        {
            return _db.Books.Include(b => b.Genre)
                .Where(b => b.Genre.Name == genre)
                .Count();
        }

        public bool CheckAvailabilityBookByAuthorAndTitle(string lastNameAuthor, string title)
        {
            return _db.Books.Include(b => b.Author)
                .Any(b => b.Title == title && b.Author.LastName == lastNameAuthor);
        }

        public Book GetLatestPublishedBook()
        {
            return _db.Books.FirstOrDefault(b => b.YearOfRelease == 
            _db.Books.Select(b => b.YearOfRelease).Max());
        }

        public List<Book> GetAllBooksSortedAlphabetically()
        {
            return GetAllObjects()
                .OrderBy(b => b.Title)
                .ToList();
        }

        public List<Book> GetAllBooksSortedByDescYear()
        {
            return GetAllObjects()
                .OrderByDescending(b => b.YearOfRelease)
                .ToList();
        }
    }
}
