using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using HackersDiscordBot.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace HackersDiscordBot
{
    class Program
    {
        static Task Main(string[] args) => new Program().MainAsync();

        private async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = GetDiscordToken(),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged,
                MinimumLogLevel = LogLevel.Debug,
                LogTimestampFormat = "MMM dd yyyy - hh:mm:ss tt"
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                CaseSensitive = false,
                StringPrefixes = new[] { "$" }
            });

            commands.RegisterCommands<AlexModule>();
            commands.RegisterCommands<GreetingModule>();
            commands.RegisterCommands<ShowMeModule>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        private static string GetDiscordToken()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return builder["token"];
        }       
    }
}
