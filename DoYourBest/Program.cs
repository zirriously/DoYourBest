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
    class Program
    {
        private DiscordSocketClient _client;
        private string _token;

        static void Main() => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Info,
                MessageCacheSize = 100
            });
            _client.Log += Log;
            _client.MessageReceived += MessageReceived;


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
