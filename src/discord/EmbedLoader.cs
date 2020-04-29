using System;
using d3bot.constructors;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Discord;

namespace d3bot.src.discord
{
    public class EmbedLoader
    {
        public static void deserializeEmbeds() {

            string embedJson = File.ReadAllText("data/embeds/index.json");
            string errorJson = File.ReadAllText("data/embeds/errors.json");
            Globals.EmbedList = JsonConvert.DeserializeObject<Embd>(embedJson);
            Embd ErrorList = JsonConvert.DeserializeObject<Embd>(errorJson);
            Globals.EmbedList.errors = ErrorList.errors;
        }

        public static Embed getEmbed(string name, bool isError) {
            EmbedBuilder EmbedBuilder = new EmbedBuilder();
            Embeds Embed;
            if (isError)
                Embed = Array.Find(Globals.EmbedList.errors, error => name == error.name);
            else
                Embed = Array.Find(Globals.EmbedList.embeds, embed => name == embed.name);
            EmbedBuilder.WithTitle(Embed.title);
            EmbedBuilder.WithDescription(Embed.description);
            EmbedBuilder.WithAuthor(Globals.EmbedList.header.name, Globals.EmbedList.header.icon_url);
            EmbedBuilder.WithFooter(Globals.EmbedList.footer.text);
            EmbedBuilder.WithColor(new Color(Globals.EmbedList.header.color));
            foreach (Fields field in Embed.fields)
                EmbedBuilder.AddField(field.name, field.value);
            return EmbedBuilder.Build();
        }
    }
}