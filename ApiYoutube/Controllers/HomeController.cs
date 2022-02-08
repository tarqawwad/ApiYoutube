using ApiYoutube.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiYoutube.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetVideoDetails());
        }

        public YoutubePlayLists GetVideoDetails()
        {
            // If you want get another playlists ,
            // 1/ Add new Fields in Model
            // 2/ Define id below
            // 3/ Get data from function
            // 4/ Send with model to view

            var PlayList1 = GetVideos("PLPn4eVPZKtrKpxWIAKj4ZcGBimLCbtDje");
            var PlayList2 = GetVideos("PLPn4eVPZKtrIRWJG83TIIOSWJxssBsB0O");

            return new YoutubePlayLists
                {
                    PlayList1 = PlayList1,
                    PlayList2= PlayList2
                };
        }
        private List<YouTubeVideoDetails> GetVideos(string PlayListID)
        {
            var Model = new List<YouTubeVideoDetails>();

            YouTubeService youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "<ApiKey>", // You Can Create api from https://console.developers.google.com/
            });

            var listRequest = youtube.PlaylistItems.List("snippet");
            listRequest.PlaylistId = PlayListID;
            listRequest.MaxResults = 3; // You Can Change Max Result or Remove

            PlaylistItemListResponse response = listRequest.Execute();

            foreach (PlaylistItem result in response.Items)
            {
                Model.Add(new YouTubeVideoDetails
                {
                    Title = result.Snippet.Title, // Title Video
                    PublicationDate = result.Snippet.PublishedAt, // Date of Published video
                    Thumbnail = result.Snippet.Thumbnails.High.Url, // Thumbnail Path 
                    Description = result.Snippet.Description, // Description Video
                    VideoId=result.Snippet.ResourceId.VideoId // Video ID
                });
            }

            return Model;
        }
    }
}