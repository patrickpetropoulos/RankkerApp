using System;
using System.Collections.Generic;

namespace RankkerCommon.Models
{
    public class MovieCollection
    {
        public int MovieCollectionId { get; set; }
        public string Name { get; set; }
        public string Overview { get; set; }
        public long TmdbId { get; set; }
        public string TmdbPosterPath { get; set; }
        public string TmdbBackdropPath { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();

        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
    }
}