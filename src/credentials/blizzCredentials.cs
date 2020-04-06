using System.Net.NetworkInformation;
using System;
using d3bot.interfaces;
using d3bot.src.routes;

namespace d3bot.src.credentials
{
    public class BlizzCredentials
    {
        public static void     displayProfile(string account, string access_token, string region) {
            ProfileInt Prof = Profile.getProfile(account, access_token, region);
            Console.WriteLine(Prof);
        } 
    }
}
