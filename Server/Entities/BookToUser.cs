using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Server.Entities
{
    public class BookToUser: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string UserEmail { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
    }
}
