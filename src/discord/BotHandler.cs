using System;
using Discord;
using Discord.Net;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using d3bot.src.discord;
using d3bot.interfaces;

namespace d3bot.src.discord
{
    public class BotHandler
    {
        private readonly IConfiguration _config;
        private DiscordSocketClient _client;

        public static void DiscordMain()
        {
            new BotHandler().MainAsync().GetAwaiter().GetResult();
        }

        public BotHandler()
        {
            var _builder = new ConfigurationBuilder();
            _config = _builder.Build();
        }

        public async Task MainAsync()
        {
            using (var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();
                _client = client;
                client.Log += LogAsync;
                client.Ready += ReadyAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;
                await client.LoginAsync(TokenType.Bot, Env.getVar("BOT_TOKEN"));
                await client.StartAsync();
                await services.GetRequiredService<CommandHandler>().InitializeAsync();
                await client.SetGameAsync("Stay Awhile and Listen !");
                await Task.Delay(-1);
            }
        }

        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"Connected as -> [{_client.CurrentUser.Username}]");
            return Task.CompletedTask;
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(_config)
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandler>()
                .BuildServiceProvider();
        }
    }
}