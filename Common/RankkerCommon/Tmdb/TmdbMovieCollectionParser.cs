using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using RankkerCommon.Models;

namespace RankkerCommon.Tmdb
{
    public class TmdbMovieCollectionParser
    {
        private readonly JObject _data;

        public TmdbMovieCollectionParser(string o)
        {
            _data = JObject.Parse(o);
        }

        public List<int> GetCollectionMovieIds()
        {
            var movieArray = (JArray)_data["parts"];

            var returnList = new List<int>();

            foreach (var result in movieArray)
            {
                returnList.Add(string.IsNullOrEmpty(result["id"] + "") ? 0 : Int32.Parse(result["id"] + ""));
            }

            return returnList;

        }

        public MovieCollection CreateOrUpdateMovieCollection(MovieCollection movieCollection)
        {
            if (movieCollection == null)
            {
                movieCollection = new MovieCollection()
                {
                    Name = _data["name"] + "",
                    Overview = _data["overview"] + "",
                    TmdbId = string.IsNullOrEmpty(_data["id"] + "") ? 0 : Int32.Parse(_data["id"] + ""),
                    TmdbPosterPath = _data["poster_path"] + "",
                    TmdbBackdropPath = _data["backdrop_path"] + ""
                };
            }
            else
            {
                movieCollection.Name = _data["name"] + "";
                movieCollection.Overview = _data["overview"] + "";
                movieCollection.TmdbId = string.IsNullOrEmpty(_data["id"] + "") ? 0 : Int32.Parse(_data["id"] + "");
                movieCollection.TmdbPosterPath = _data["poster_path"] + "";
                movieCollection.TmdbBackdropPath = _data["backdrop_path"] + "";
            }

            return movieCollection;
        }
    }
}