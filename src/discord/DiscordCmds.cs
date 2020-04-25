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
			public async Task	displayProfile([Summary("Player profile")] string account, string opt1 = "eu", string opt2 = "eu") {
				ProfileInt Prof;
				bool playtime = opt1.ToLower() == "playtime" || opt2.ToLower() == "playtime";
				if (opt1.ToLower() == "playtime") {
					Prof = await Profile.getProfile(Char.ToUpper(account[0]) + account.Substring(1), Globals.Token.access_token, opt2.ToLower());
				} else {
					Prof = await Profile.getProfile(Char.ToUpper(account[0]) + account.Substring(1), Globals.Token.access_token, opt1.ToLower());
				}
				ProfileProc.profileProcessing(Prof, account, playtime);
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
