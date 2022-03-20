using System;

namespace DvdCollection.Data.Models
{
    public class MediaFile
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ImdbId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RuntimeMinutes { get; set; }
        public int? ReleaseYear { get; set; }
    }
}
