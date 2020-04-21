using Discord;
using Discord.Net;
using Discord.Rest;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Threading.Tasks;
using d3bot.interfaces;
using d3bot.src.routes;
using d3bot.src.image_processing;

namespace d3bot.Modules
{
	public class DiscordCmds : ModuleBase
	{
		public class SampleModule : ModuleBase<SocketCommandContext>
		{			
			[Command("profile", RunMode = RunMode.Async)][Summary("Retrieve a player profile")]
			public async Task	displayProfile([Summary("Player profile")] string account, string region = "eu") {
				ProfileInt Prof = await Profile.getProfile(account, Globals.Token.access_token, region);
				ProfileProc.profileProcessing(Prof, account);
				await Context.Channel.SendFileAsync("data/img/RenderedImage.png", null);
			}

			[Command("cowlvl")][Summary("There is no cow level")]
			public async Task	cowLevel() {
				await Context.Channel.SendFileAsync("data/img/cowlvl.png", "Leads to a place that does not exist. The Burning Hells are not responsible for events that transpire there. If you claim to have been to this place, you will be called a liar. Void where prohibited.");
			}

			[Command("help")][Summary("Display help")]
			public async Task	displayHelp() {
				await Context.Channel.SendMessageAsync("Stay awhile and listen !\nList of commands:\n*+profile [battletag] [region](optionnal)* - Display a player profile\n*+cowlvl* - There is no cow level");
			}
		}
	}
}
