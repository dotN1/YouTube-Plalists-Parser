using Google.Apis.Services;
using Google.Apis.Util;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web.Helpers;
using System.Windows;
using YouTubePlaylists.Backend.Model;
using System.Web;

namespace YouTubePlaylists.Backend.ViewModel
{
    public class MainModel 
    {
        private const string _APIKEY = "AIzaSyAJmBZnnVE-o0H7-SA_6O8MhHKZYlemWgI";

        public ObservableCollection<Track> GetSongInfo(string playlistId)
        {
            ObservableCollection<Track> informationAboutSong = null;
            try
            {
                var yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = _APIKEY });
                var channelRequest = yt.Playlists.List("snippet");
                channelRequest.Id = playlistId;
                var channelResponse = channelRequest.Execute();

                Google.Apis.YouTube.v3.Data.Playlist playlist = channelResponse.Items[0];

                var playlistItemsListRequest = yt.PlaylistItems.List("snippet, contentDetails");
                playlistItemsListRequest.PlaylistId = playlistId;
                playlistItemsListRequest.MaxResults = 50;

                // Retrieve the list of videos uploaded to the authenticated user's channel.
                var playlistItemsListResponse = playlistItemsListRequest.Execute();

                informationAboutSong = new ObservableCollection<Track>();
                foreach (var playlistItem in playlistItemsListResponse.Items)
                {
                    //For get song duration
                    WebClient myDownloader = new WebClient();
                    myDownloader.Encoding = System.Text.Encoding.UTF8;

                    //We indicate our video (song)
                    string jsonResponse = myDownloader.DownloadString(
                    "https://www.googleapis.com/youtube/v3/videos?id=" + playlistItem.Snippet.ResourceId.VideoId + "&key="
                    + _APIKEY + "&part=contentDetails");
                    dynamic dynamicObject = Json.Decode(jsonResponse);
                    string tmp = dynamicObject.items[0].contentDetails.duration;
                    var songDuration = Convert.ToInt32(System.Xml.XmlConvert.ToTimeSpan(tmp).TotalSeconds);

                    //For get the channel title of the channel that the video belongs to.
                    var videoItemListRequest = yt.Videos.List("snippet");
                    videoItemListRequest.Id = playlistItem.ContentDetails.VideoId;
                    videoItemListRequest.MaxResults = 50;

                    var videoItemListResponse = videoItemListRequest.Execute();

                    Track track = new Track()
                    {
                        ThumbnailUri = GetMaxResolution(playlistItem.Snippet.Thumbnails),
                        
                        SongName = playlistItem.Snippet.Title.Contains(" - ") ? playlistItem.Snippet.Title.Substring(playlistItem.Snippet.Title.IndexOf(" - ") + 3)
                                                                              : playlistItem.Snippet.Title,
                        ArtistName = playlistItem.Snippet.Title.Contains(" - ") && videoItemListResponse.Items[0].Snippet.ChannelTitle
                                                                                != playlistItem.Snippet.Title.Substring(0, playlistItem.Snippet.Title.IndexOf(" - "))
                                                                                    ? playlistItem.Snippet.Title.Substring(0, playlistItem.Snippet.Title.IndexOf(" - "))
                                                                                    : videoItemListResponse.Items[0].Snippet.ChannelTitle,
                        Duration = $"{(songDuration / 60)}:{(songDuration % 60)}"
                    };

                    informationAboutSong.Add(track);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return informationAboutSong;
        }

        public Model.Playlist GetPlaylistInfo(string playlistId)
        {
            Model.Playlist informationAboutPlaylist = null;

            try
            {
                var yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = _APIKEY });
                var channelRequest = yt.Playlists.List("snippet");
                channelRequest.Id = playlistId;
                var channelResponse = channelRequest.Execute();

                Google.Apis.YouTube.v3.Data.Playlist playlist = channelResponse.Items[0];


                var playlistItemsListRequest = yt.PlaylistItems.List("snippet");
                playlistItemsListRequest.PlaylistId = playlistId;
                playlistItemsListRequest.MaxResults = 50;

                // Retrieve the list of videos uploaded to the authenticated user's channel.
                var playlistItemsListResponse = playlistItemsListRequest.Execute();

                informationAboutPlaylist = new Model.Playlist() 
                {
                    Thumbnail = GetMaxResolution(playlist.Snippet.Thumbnails),
                    Description = playlist.Snippet.Description,
                    Name = playlist.Snippet.Title
                };
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

            return informationAboutPlaylist;
        }

        public string LinkParser(string link)
        {
            try
            {
                Uri uri = new Uri(link);
                string playlistId = HttpUtility.ParseQueryString(uri.Query).Get("list");
                
                return playlistId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Incorrect link");
                throw ex;
            }
            
        }

        private string GetMaxResolution(ThumbnailDetails th)
        {
            if (th.Maxres != null)
            {
                return th.Maxres.Url;
            }
            else if (th.High != null)
            {
                return th.High.Url;
            }
            else if (th.Medium != null)
            {
                return th.Medium.Url;
            }
            else if (th.Standard != null)
            {
                return th.Standard.Url;
            }
            else if (th.Default__ != null)
            {
                return th.Default__.Url;
            }

            return null;
        }
    }
}
