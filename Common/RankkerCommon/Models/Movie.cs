using System;
using System.Collections.Generic;

namespace RankkerCommon.Models
{
    public class Movie
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public long? Budget { get; set; }
        public long? Revenue { get; set; }
        public long TmdbId { get; set; }
        public string ImdbId { get; set; }
        public string TmdbPosterPath { get; set; }
        public string TmdbBackdropPath { get; set; }
        public string Status { get; set; }
        public DateTime? DateUpdated { get; set; }

        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

    }
}