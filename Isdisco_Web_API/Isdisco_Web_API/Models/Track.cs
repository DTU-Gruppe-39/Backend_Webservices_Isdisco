using System;
namespace Isdisco_Web_API.Models
{
    public class Track
    {
        public string Id { get; set; }
        public string SongName { get; set; }
        public string ArtistName { get; set; }
        public string Image_small { get; set; }
        public string Image_medium { get; set; }
        public string Image_large { get; set; }
        public string WebplayerLink { get; set; }

        public Track(string id, string songName, string artistName, string image_small, string image_medium, string image_large, string webplayerLink)
        {
            Id = id;
            SongName = songName;
            ArtistName = artistName;
            Image_small = image_small;
            Image_medium = image_medium;
            Image_large = image_large;
            WebplayerLink = webplayerLink;
        }
    }
}
