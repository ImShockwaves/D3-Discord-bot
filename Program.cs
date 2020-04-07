using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using d3bot.interfaces;
using d3bot.src.credentials;
using d3bot.src.routes;
using d3bot.src.discord;
using RestSharp;
using RestSharp.Authenticators;

namespace d3bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Token Token = Credentials.createAccessToken(Env.getVar("B_CLIENT"), Env.getVar("B_SECRET")).GetAwaiter().GetResult();
            // BlizzCredentials.displayProfile("Shockwaves#2256", Token.access_token, "eu").Wait();
            BotHandler.DiscordMain();
        }
    }
}
