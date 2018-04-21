using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreSpa_master.Server.ViewModels.YoutubeViewModels;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace AspNetCoreSpa.Server.Services
{
    public class YoutubeService
    {
        private string key = "AIzaSyCLcdmEMjGKXNSvgdiFOfiyiYLT07ZDCf8";

        public async Task<YoutubeViewModel> Search(string searchTerm, int maxResults = 50)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = key,
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = searchTerm; // Replace with your search term.
            searchListRequest.MaxResults = maxResults;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            var youtubeViewModel = new YoutubeViewModel();

            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        var video = new Video();
                        video.Name = searchResult.Snippet.Title;
                        video.Id = searchResult.Id.VideoId;
                        youtubeViewModel.Videos.Add(video);
                        break;

                    case "youtube#channel":
                        var channel = new Channel();
                        channel.Name = searchResult.Snippet.Title;
                        channel.Id = searchResult.Id.VideoId;
                        youtubeViewModel.Channels.Add(channel);
                        break;

                    case "youtube#playlist":
                        var playlist = new Playlist();
                        playlist.Name = searchResult.Snippet.Title;
                        playlist.Id = searchResult.Id.VideoId;
                        youtubeViewModel.Playlists.Add(playlist);
                        break;
                }
            }

            return youtubeViewModel;
        }
    }
}
