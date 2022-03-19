using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackersDiscordBot.Commands
{
    internal class AlexModule : BaseCommandModule 
    {
        [Command("alex")]
        public async Task AlexQuote(CommandContext ctx)
        {
            await ctx.RespondAsync(GetAlexQuote());
        }

        [Command("alexpic")]
        public async Task AlexPicture(CommandContext ctx)
        {
            var fileName = FileReader.GetAlexPhoto();

            using var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            var message = await new DiscordMessageBuilder()
                .WithContent("Here is your Alex Jones picture, not sure why you want this garbage")
                .WithFiles(new Dictionary<string, Stream>() { { fileName, stream } })
                .SendAsync(ctx.Channel);
        }

        private string GetAlexQuote()
        {
            return FileReader.ReadAlexFile();
        }
    }
}
