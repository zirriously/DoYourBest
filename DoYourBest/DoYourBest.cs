using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using System.IO;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DoYourBest
{
    class DoYourBest
    {
        private DiscordSocketClient _client;
        private string _token;
        private string _apiKey;
        private const string ImgurRegex = @"https?://i\.imgur\.com/\w+\.(gifv|mp4)";

        private static void Main() => new DoYourBest().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Info,
                MessageCacheSize = 100
            });
            _client.Log += Log;
            _client.MessageReceived += MessageReceived;

            var vars = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(@".\vars.json"));
            _token = vars.token;
            _apiKey = vars.apikey;


            await _client.LoginAsync(TokenType.Bot, _token);
            await _client.StartAsync();

            _client.Ready += () =>
            {
                Log(new LogMessage(LogSeverity.Info, "Client",
                    $"Logged in succesfully as {_client.CurrentUser.Username}"));
                return Task.CompletedTask;
            };

            await Task.Delay(Timeout.Infinite);
        }

        private async Task MessageReceived(SocketMessage msg)
        {

        }

        public static Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }
    }
}
