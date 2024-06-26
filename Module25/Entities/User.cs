﻿namespace Module25.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
