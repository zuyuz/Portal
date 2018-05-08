using System;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreSpa.Server.Entities
{
    public class Book : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime Published { get; set; }
    }
}
