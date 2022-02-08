using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiYoutube.Models
{
    public class YoutubePlayLists
    {
        public List<YouTubeVideoDetails> PlayList1 { get; set; }
        public List<YouTubeVideoDetails> PlayList2 { get; set; }

        // you can add more items here .....
    }
    public class YouTubeVideoDetails
    {
        public string VideoId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public DateTime? PublicationDate { get; set; }
    }
}