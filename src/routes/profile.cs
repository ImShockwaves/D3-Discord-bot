using d3bot.interfaces;
using d3bot.src.routes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace d3bot.src.routes
{
    public class Profile
    {
        public static ProfileInt getProfile(string account, string access_token, string region) {
            int index = account.IndexOf('#');
            string ins = account.Insert(index, "%23");
            string rep = ins.Remove(index + 3, 1);
            string url = $"https://{region}.api.blizzard.com/d3/profile/{rep}/?locale=fr_FR&access_token={access_token}";
            string method = "get";
            return JsonConvert.DeserializeObject<ProfileInt>(Index.request(url, method).Content);
        }    
    }
}