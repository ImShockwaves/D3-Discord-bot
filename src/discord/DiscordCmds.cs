using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace d3bot.Modules
{
    public class DiscordCmds : ModuleBase
    {
        public class SampleModule : ModuleBase<SocketCommandContext>
        {
            [Command("square")][Summary("Squares a number.")]
            public async Task SquareAsync([Summary("The number to square.")] int num)
            {
                await Context.Channel.SendMessageAsync($"{num}^2 = {Math.Pow(num, 2)}");
            }
        }
    }
}