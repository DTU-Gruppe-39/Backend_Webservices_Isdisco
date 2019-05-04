using System;
namespace Isdisco_Web_API.Models
{
    public class Track
    {
        public string Id { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string Image_small_url { get; set; }
        public string Image_medium_url { get; set; }
        public string Image_large_url { get; set; }
        public string WebplayerLink { get; set; }

        public Track(string id, string songName, string artistName, string image_small_url, string image_medium_url, string image_large_url, string webplayerLink)
        {
            Id = id;
            SongName = songName;
            ArtistName = artistName;
            Image_small_url = image_small_url;
            Image_medium_url = image_medium_url;
            Image_large_url = image_large_url;
            WebplayerLink = webplayerLink;
        }
    }
}
