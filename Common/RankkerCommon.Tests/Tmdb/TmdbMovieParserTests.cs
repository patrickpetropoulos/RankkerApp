using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using RankkerCommon.Tmdb;

namespace RankkerCommon.Tests.Tmdb
{
    public class TmdbMovieParserTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidateMovieParser_ParsesTmdbIdDataCorrectly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("RankkerCommon.Tests.TestData.TMDB.Movie.218-The_Terminator.json"))
            using (var reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                var parser = new TmdbMovieParser(text);
                Assert.AreEqual(218, parser.ParseTmdbId());
            }
        }
    }
}