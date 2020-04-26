using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using d3bot.constructors;
using d3bot.src.routes;
using d3bot.src.discord;

namespace d3bot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Globals.Token = await Credentials.createAccessToken(Env.getVar("B_CLIENT"), Env.getVar("B_SECRET"));
            BotHandler.DiscordMain();
        }
    }
}
