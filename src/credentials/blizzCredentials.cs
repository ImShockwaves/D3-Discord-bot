using System.Net.NetworkInformation;
using System;
using d3bot.interfaces;
using d3bot.src.routes;
using System.Threading.Tasks;

namespace d3bot.src.credentials
{
    public class BlizzCredentials
    {
        public static async Task  displayProfile(string account, string access_token, string region) {
            ProfileInt Prof = await Profile.getProfile(account, access_token, region);
            Console.WriteLine(Prof);
        } 
    }
}
