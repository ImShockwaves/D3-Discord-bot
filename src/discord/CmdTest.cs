using Discord;
using Discord.Net;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace d3bot.src.discord
{
    public class CmdTest : ModuleBase
    {
        public class SampleModule : ModuleBase<SocketCommandContext>
        {
            [Command("add")][Summary("Squares a number.")]
            public async Task AddAsync([Summary("The number to square.")] int num1, int num2)
            {
                await Context.Channel.SendMessageAsync($"{num1} + {num2} = {num1 + num2}");
            }
        }
    }
}