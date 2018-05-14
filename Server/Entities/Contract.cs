using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreSpa.Server.Entities
{
    public class Contract: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserOffer")]
        public int UserOfferId { get; set; }
        public string UserEmail { get; set; }
        public bool IsAllowed { get; set; }
    }
}
