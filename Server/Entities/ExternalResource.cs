using System.ComponentModel.DataAnnotations;
using AspNetCoreSpa.Server.Entities;

namespace AspNetCoreSpa_master.Server.Entities
{
    public class ExternalResource : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string UserEmail { get; set; }
        public bool IsVerified { get; set; }
    }
}