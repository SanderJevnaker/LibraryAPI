using System;
namespace Library.DTO
{
    public class BooksDTO
    {
        public int Id { get; set; }
        public DateTime? Published { get; set; }
        public string? Title { get; set; }
        public int? Isbn { get; set; }
        public string? Subject { get; set; }
        public string? Author { get; set; }
        public string? Version { get; set; }
        public string? Shelf { get; set; }
        public string? Language { get; set; }


        public BooksDTO()
        {
        }
    }
}

