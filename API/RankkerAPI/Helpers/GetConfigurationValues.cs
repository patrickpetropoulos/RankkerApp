using Microsoft.Extensions.Configuration;

namespace RankkerAPI.Helpers
{
    public static class GetConfigurationValues
    {
        public static string GetConnectionString(IConfiguration config)
        {
            return config.GetConnectionString("DefaultConnection");
        }

        public static string GetTmdbApiKey(IConfiguration config)
        {
            return config.GetValue<string>("TMDB_API_Key");
        }
    }
}