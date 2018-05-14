using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa_master.Server.Entities;

namespace AspNetCoreSpa.Server.Entities
{
    public class UserDemand : IEntityBase
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
