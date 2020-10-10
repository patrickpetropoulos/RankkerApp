using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RankkerCommon.Imdb
{
    public class ImdbMovieList
    {
        //Pass in List Id
        //Get List Title, and number of movies in List

        public int ListSize { get; set; }
        public string ListId { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }
        public List<string> MovieList;

        public ImdbMovieList(string id)
        {
            ListId = id;
            ListName = "";
            ListSize = 0;
            MovieList = new List<string>();
        }

        public async Task GetListOfMovies()
        {
            int page = 1;

            while (ListSize == 0 || ListSize > MovieList.Count)
            {
                if (MovieList.Count > page)
                {
                    page++;
                }

                var url = "http://www.imdb.com/list/" + ListId + "/?sort=list_order,asc&st_dt=&mode=detail&page=" + page;
                var web = new HtmlWeb();
                var doc = web.Load(url);

                if (ListSize == 0)
                {
                    try
                    {
                        var listTitle = doc.DocumentNode
                            .Descendants("h1")
                            .First(x => x.Attributes["class"] != null &&
                                        x.Attributes["class"].Value.Equals("header list-name"));

                        ListName = listTitle.InnerHtml;

                        var listName = doc.DocumentNode
                            .Descendants("div")
                            .First(x => x.Attributes["class"] != null &&
                                        x.Attributes["class"].Value.Equals("list-description"));

                        ListDescription = listName.InnerHtml;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error in parser is " + e);
                    }

                    var desc = doc.DocumentNode
                        .Descendants("div")
                        .First(x => x.Attributes["class"] != null && x.Attributes["class"].Value.Equals("desc lister-total-num-results"));



                    var trimValue = desc.InnerHtml.Trim();
                    trimValue = trimValue.Substring(0, trimValue.IndexOf(" "));

                    ListSize = Convert.ToInt32(trimValue);
                }

                var tempDiv = doc.DocumentNode
                    .Descendants("div")
                    .Where(x => x.Attributes["class"] != null &&
                                x.Attributes["class"].Value.Equals("lister-item-image ribbonize"));

                foreach (var div in tempDiv)
                {
                    MovieList.Add(div.Attributes["data-tconst"].Value);
                }

            }
        }
    }
}