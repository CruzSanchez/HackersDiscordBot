using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackersDiscordBot
{
    internal class ShowMeModule : BaseCommandModule
    {
        [Command("showme")]
        public async Task ShowMe(CommandContext ctx, [RemainingText] string searchQuery)
        {
            try
            {
                var root = await BaseServiceCall.CallYouTube(searchQuery);

                if (root == null)
                    return;

                await ctx.RespondAsync($"https://www.youtube.com/watch?v={root.Items[0].Id.VideoId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
