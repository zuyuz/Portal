using System.ComponentModel.DataAnnotations;
using AspNetCoreSpa.Server.Entities;

namespace AspNetCoreSpa_master.Server.Entities
{
    public enum PriceType
    {
        Free,
        Paid
    }

    public class Price : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public PriceType PriceType { get; set; }
        public double Value { get; set; }
    }
}