using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RankkerCommon.Models;

namespace RankkerCommon.Tmdb
{
    public class TmdbMovieService
    {
        public static async Task<Movie> GetMovieByTmdbId(int tmdbId, string apikey)
        {
            var myUrl = "https://api.themoviedb.org/3/movie/" + tmdbId +
                        "?api_key=" + apikey;
            var client = new HttpClient();
            var data = await client.GetStringAsync(myUrl);

            return new TmdbMovieParser(data).GetMovie();
        }

        public static async Task<TmdbMovieCollectionParser> GetMovieCollectionByTmdbId(int collectionId, string apikey)
        {
            var myUrl = "https://api.themoviedb.org/3/collection/" + collectionId +
                        "?api_key=" + apikey;
            var client = new HttpClient();
            var data = await client.GetStringAsync(myUrl);

            return new TmdbMovieCollectionParser(data);
        }

        public static async Task<List<MovieGenre>> GetListOfMovieGenres(string apikey)
        {
            try
            {
                var myUrl = "https://api.themoviedb.org/3/genre/movie/list?api_key="
                            + apikey;
                var client = new HttpClient();
                var response = await client.GetStringAsync(myUrl);

                var data = JObject.Parse(response);
                var genreArray = (JArray)data["genres"];

                var genres = new List<MovieGenre>();
                foreach (var item in genreArray)
                {
                    //TODO Check to ensure is TMDB when list is loaded from memory
                    genres.Add(new MovieGenre()
                    {
                        Id = Int32.Parse(item["id"] + ""),
                        Name = item["name"] + ""
                    });
                }

                return genres;
            }
            catch (Exception e)
            {
                Console.WriteLine("My error is " + e);
                return null;
            }
        }

        public static async Task<List<int>> GetListOfMovieIdsForDiscoverPage(string apikey, int pageNumber)
        {
            var myUrl = "https://api.themoviedb.org/3/discover/movie" +
                        "?api_key=" + apikey +
                        "&page=" + pageNumber;
            var client = new HttpClient();
            var data = await client.GetStringAsync(myUrl);

            var o = JObject.Parse(data);

            var resultArray = (JArray)o["results"];

            var returnList = new List<int>();

            foreach (var result in resultArray)
            {
                returnList.Add(string.IsNullOrEmpty(result["id"] + "") ? 0 : Int32.Parse(result["id"] + ""));
            }

            return returnList;
        }
    }
}