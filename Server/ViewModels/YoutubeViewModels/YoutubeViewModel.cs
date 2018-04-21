using System.Collections.Generic;

namespace AspNetCoreSpa_master.Server.ViewModels.YoutubeViewModels
{
    public abstract class YoutubeElement
    {
        private string name;
        private string id;
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }
    }
    public class Video:YoutubeElement
    {

    }
    public class Channel:YoutubeElement
    {

    }
    public class Playlist:YoutubeElement
    {

    }
    public class YoutubeViewModel
    {
        private List<Video> videos;
        private List<Channel> channels;
        private List<Playlist> playlists;

        public List<Video> Videos { get => videos; set => videos = value; }
        public List<Channel> Channels { get => channels; set => channels = value; }
        public List<Playlist> Playlists { get => playlists; set => playlists = value; }

        public YoutubeViewModel()
        {
            videos = new List<Video>();
            channels = new List<Channel>();
            playlists = new List<Playlist>();

        }
    }
}