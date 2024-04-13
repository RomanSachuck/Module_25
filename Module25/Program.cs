using Module25.Entities;
using Module25.Repositories;

namespace Module25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                Genre genre1 = new Genre { Name = "Драма" };
                Genre genre2 = new Genre { Name = "Роман" };
                Genre genre3 = new Genre { Name = "Поэма" };
                db.Genres.AddRange(genre1, genre2, genre3);

                Author author1 = new Author { FirstName = "Михаил", LastName = "Лермонтов" };
                Author author2 = new Author { FirstName = "Василий", LastName = "Шукшин" };
                Author author3 = new Author { FirstName = "Федор", LastName = "Достоевсикй" };
                Author author4 = new Author { FirstName = "Лев", LastName = "Толстой" };
                db.Authors.AddRange(author1, author2, author3, author4);

                Book book1 = new Book { Title = "Мцыри", YearOfRelease = 1838, Genre = genre3, Author = author1 };
                Book book2 = new Book { Title = "Герой нашего времени", YearOfRelease = 1838, Genre = genre2, Author = author1 };
                Book book3 = new Book { Title = "Любавины", YearOfRelease = 1965, Genre = genre2, Author = author2 };
                Book book4 = new Book { Title = "Преступление и наказание", YearOfRelease = 1866, Genre = genre2, Author = author3 };
                Book book5 = new Book { Title = "Власть тьмы", YearOfRelease = 1887, Genre = genre1, Author = author4 };
                db.Books.AddRange(book1, book2, book3, book4, book5);

                User user1 = new User { FirstName = "Артем", Email = "email1@gmail.com" };
                User user2 = new User { FirstName = "Юрий", Email = "email2@gmail.com" };
                User user3 = new User { FirstName = "Виктор", Email = "email3@gmail.com" };
                db.Users.AddRange(user1, user2, user3);

                db.SaveChanges();
            }

            using (var db = new AppContext())
            {
                BookRepository bookRepository = new BookRepository(db);
                UserRepository userRepository = new UserRepository(db);

                //Здесь вызываются необходимые методы:
                //...
            }
        }
    }
}
