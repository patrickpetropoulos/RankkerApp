using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RankkerCommon.Models;
using static System.Int64;

namespace RankkerCommon.Tmdb
{
    public class TmdbMovieParser
    {
        private readonly JObject _data;

        public TmdbMovieParser(string o)
        {
            //TODO error handling??
            _data = JObject.Parse(o);
        }

        public int CollectionInt()
        {
            try
            {
                return string.IsNullOrEmpty(_data["belongs_to_collection"]["id"] + "")
                    ? 0
                    : Int32.Parse(_data["belongs_to_collection"]["id"] + "");

            }
            catch (Exception e)
            {
                return 0;
            }


        }

        public int ParseTmdbId()
        {
            return string.IsNullOrEmpty(_data["id"] + "") ? 0 : Int32.Parse(_data["id"] + "");
        }

        public JArray GenreArray()
        {
            return (JArray)_data["genres"];
        }

        public List<MovieGenre> GetMovieGenres()
        {
            var genres = new List<MovieGenre>();

            foreach (var genre in GenreArray())
            {
                genres.Add(new MovieGenre()
                {
                    Id = Int32.Parse(genre["id"] + ""),
                    Name = genre["name"] + ""
                });
            }

            return genres;
        }

        public Movie GetMovie()
        {
            var movie = new Movie()
            {
                Name = _data["title"] + "",
                Tagline = _data["tagline"] + "",
                Overview = _data["overview"] + "",
                ReleaseDate = string.IsNullOrEmpty(_data["release_date"] + "")
                    ? (DateTime?)null
                    : DateTime.Parse(_data["release_date"] + ""),
                RunTime = string.IsNullOrEmpty(_data["runtime"] + "") ? 0 : Int32.Parse(_data["runtime"] + ""),
                Budget = string.IsNullOrEmpty(_data["budget"] + "") ? 0 : Parse(_data["budget"] + ""),
                Revenue = string.IsNullOrEmpty(_data["revenue"] + "") ? 0 : Parse(_data["revenue"] + ""),
                TmdbId = string.IsNullOrEmpty(_data["id"] + "") ? 0 : int.Parse(_data["id"] + ""),
                ImdbId = _data["imdb_id"] + "",
                TmdbPosterPath = _data["poster_path"] + "",
                TmdbBackdropPath = _data["backdrop_path"] + "",
                Status = _data["status"] + "",
                DateUpdated = DateTime.UtcNow,
                MovieGenres = GetMovieGenres()
            };

            return movie;
        }

        //TODO must be a better way to do this
        public Movie CreateOrUpdateMovie(Movie movie)
        {
            if (movie == null)
            {
                movie = new Movie()
                {
                    Name = _data["title"] + "",
                    Tagline = _data["tagline"] + "",
                    Overview = _data["overview"] + "",
                    ReleaseDate = string.IsNullOrEmpty(_data["release_date"] + "")
                        ? (DateTime?)null
                        : DateTime.Parse(_data["release_date"] + ""),
                    RunTime = string.IsNullOrEmpty(_data["runtime"] + "") ? 0 : Int32.Parse(_data["runtime"] + ""),
                    Budget = string.IsNullOrEmpty(_data["budget"] + "") ? 0 : Parse(_data["budget"] + ""),
                    Revenue = string.IsNullOrEmpty(_data["revenue"] + "") ? 0 : Parse(_data["revenue"] + ""),
                    TmdbId = string.IsNullOrEmpty(_data["id"] + "") ? 0 : Int32.Parse(_data["id"] + ""),
                    ImdbId = _data["imdb_id"] + "",
                    TmdbPosterPath = _data["poster_path"] + "",
                    TmdbBackdropPath = _data["backdrop_path"] + "",
                    Status = _data["status"] + "",
                    DateUpdated = DateTime.UtcNow
                };
            }
            else
            {
                movie.Name = _data["title"] + "";
                movie.Tagline = _data["tagline"] + "";
                movie.Overview = _data["overview"] + "";
                movie.ReleaseDate = string.IsNullOrEmpty(_data["release_date"] + "")
                    ? (DateTime?)null
                    : DateTime.Parse(_data["release_date"] + "");
                movie.RunTime = string.IsNullOrEmpty(_data["runtime"] + "") ? 0 : Int32.Parse(_data["runtime"] + "");
                movie.Budget = string.IsNullOrEmpty(_data["budget"] + "") ? 0 : Parse(_data["budget"] + "");
                movie.Revenue = string.IsNullOrEmpty(_data["revenue"] + "") ? 0 : Parse(_data["revenue"] + "");
                movie.TmdbId = string.IsNullOrEmpty(_data["id"] + "") ? 0 : Int32.Parse(_data["id"] + "");
                movie.ImdbId = _data["imdb_id"] + "";
                movie.TmdbPosterPath = _data["poster_path"] + "";
                movie.TmdbBackdropPath = _data["backdrop_path"] + "";
                movie.Status = _data["status"] + "";
                movie.DateUpdated = DateTime.UtcNow;
            }

            return movie;
        }
    }
}