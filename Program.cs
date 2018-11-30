using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace Botana
{

    public class Program
    {
        bool gameStarted = false;
        bool penduStarted = false;
        Pendu pendu;
        System.IO.StreamReader file;
        List<string> channels;

        private DiscordSocketClient _client;

        public static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            file = new System.IO.StreamReader("token.txt");
            string line = file.ReadLine();
            await _client.LoginAsync(TokenType.Bot, line);
            await _client.StartAsync();

            channels = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                channels.Add(line);
            }

            _client.MessageReceived += MessageReceived;

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Author.Id == _client.CurrentUser.Id)
            {
                return;
            }

            bool allowedChannel = false;
            foreach (string line in channels)
            {
                if (message.Channel.Id == ulong.Parse(line))
                {
                    allowedChannel = true;
                }
            }
            if (!allowedChannel)
            {
                return;
            }

            if (message.Content == "!ping" && !gameStarted)
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
            if (message.Content == "!mot" && !gameStarted)
            {
                // écrit un mot aléatoire
                Mot mot = new Mot();
                await message.Channel.SendMessageAsync(mot.value);

            }
            if ((message.Content.StartsWith("!pendu") && !gameStarted) || penduStarted)
            {
                if (!penduStarted)
                {
                    penduStarted = true;
                    gameStarted = true;
                    pendu = new Pendu();
                    Console.WriteLine(pendu.mot.value);
                    await message.Channel.SendMessageAsync(pendu.guess);
                    Console.WriteLine(pendu.guess);
                }
                else
                {
                    string motHidden = pendu.mot.value;
                    string mot = message.Content;

                    if (mot.Length > 1)
                    {
                        await message.Channel.SendMessageAsync("Une seule lettre svp");
                    }
                    else
                    {
                        char c = mot[0];
                        pendu.reveal(c);
                        await message.Channel.SendMessageAsync(pendu.guess);
                        if (pendu.guess.IndexOf('-') == -1)
                        {
                            await message.Channel.SendMessageAsync("Gagné !");
                            penduStarted = false;
                            gameStarted = false;
                        }
                    }
                }
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
