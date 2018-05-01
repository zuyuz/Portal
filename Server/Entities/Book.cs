using System;

namespace AspNetCoreSpa.Server.Entities
{
    public class Book : IEntityBase
    {
        public Book() { }

        public Book(string path)
        {
            Id = 0;
            Title = "NewTitle";
            Author = "NewAuthor";
            Country = "Ukraine";
            Language = "UKR";
            Genre = "NewGenre";
            Publisher = "NewPublisher";
            Published = DateTime.Now;
            PathToFile = path;
        }

        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime Published { get; set; }
        public string PathToFile { get; set; }
    }
}
