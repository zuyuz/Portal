using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCoreSpa.Server.Entities;

namespace AspNetCoreSpa_master.Server.Entities
{
    public class UserOffer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string UserEmail { get; set; }

        public string Description { get; set; }

        public Price Price { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
    }
}