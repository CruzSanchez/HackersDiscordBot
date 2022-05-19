using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackersDiscordBot.Commands
{
    internal class InsultModule : BaseCommandModule
    {
        [Command("Greet")]
        [Aliases("g", "grt")]
        public async Task Greet(CommandContext ctx, [RemainingText] DiscordMember? member)
        {
            string quote = member is null ? $"Yo, what the fuck is up?" : $"Yo, what the fuck is up {member.Mention}?";
            await ctx.RespondAsync(quote);
        }
    }
}
