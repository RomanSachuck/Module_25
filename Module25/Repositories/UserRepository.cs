using Module25.Entities;

namespace Module25.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(AppContext db) : base(db) { }
        public override User GetObject(int id) => _db.Users.FirstOrDefault(user => user.Id == id);
        public override List<User> GetAllObjects() => _db.Users.ToList();
        public override void AddObject(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }
        public override void RemoveObject(User user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public void ChangeUserName(int id, string newUserName)
        {
            var user = GetObject(id);
            user.FirstName = newUserName;
            _db.SaveChanges();
        }

        public bool CheckUsersBookAvailability(User user, Book book) => user.Books.Contains(book);

        public int GetAmountBooksFromUser(User user) => user.Books.Count();
    }
}
