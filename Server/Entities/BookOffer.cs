using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspNetCoreSpa.Server.Entities;

namespace AspNetCoreSpa_master.Server.Entities
{
    public enum Status
    {
        Created = 0,
        Assigned = 1,
        InProgress = 2,
        Verify = 3,
        Done = 4 
    }
    public class BookContract : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserDemand")]
        public int UserDemandId { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("UserOffer")]
        public int UserOfferId { get; set; }

        public Status Status { get; set; }
    }
}