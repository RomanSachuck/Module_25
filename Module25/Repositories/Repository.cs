namespace Module25.Repositories
{
    public abstract class Repository<T>
        where T : class
    {
        protected AppContext _db;
        protected Repository(AppContext db) => _db = db;

        public abstract T GetObject(int id);
        public abstract List<T> GetAllObjects();
        public abstract void AddObject(T obj);
        public abstract void RemoveObject(T obj);
    }
}
