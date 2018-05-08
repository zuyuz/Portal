using System.ComponentModel.DataAnnotations;
using AspNetCoreSpa_master.Server.ViewModels.YoutubeViewModels;

namespace AspNetCoreSpa.Server.Entities
{
    public class YoutubeFavorite
    {
        [Key]
        public int Id { get; set; }
        public string UserEmail { get; set; }

        public string VideoId { get; set; }
        
    }
}