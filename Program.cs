using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Supremes;
using Supremes.Nodes;
using Supremes.Parsers;

namespace Botana
{

    public class Program
    {
        bool gameStarted = false;
        bool penduStarted = false;
        bool morpionStarted = false;
        Pendu pendu;
        System.IO.StreamReader file;
        List<string> channels;

        MorpionPlayer j1 = null;
        MorpionPlayer j2;
        Morpion morpion;

        RestUserMessage morpionDisplay;
        RestUserMessage penduDisplay;

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

            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }

            if (message.Content.StartsWith("!mot"))
            {
                Mot mot = new Mot();
                await message.Channel.SendMessageAsync(mot.value);
            }

            if (message.Content == "!wedzcode")
            {
                Humor humor = new Humor();
                await message.Channel.SendMessageAsync(humor.image);
            }

            if (message.Content == "!mariok")
            {
                string mariok = HtmlString.getHtmlString("http://www.insultron.fr", "40px;\">", "</font>");
                await message.Channel.SendMessageAsync(mariok);
            }

            if (message.Content.StartsWith("!dés"))
            {
                await message.Channel.SendMessageAsync(Des.random(message.Content));
            }

            if (message.Content.StartsWith("!rpg"))
            {
                string[] input = message.Content.Split(" ");
                if (input.Length != 2)
                {
                    await message.Channel.SendMessageAsync("Commande invalide");
                }
                else
                {
                    string playerName = input[1];
                    RPGPlayer rpg;
                    try
                    {
                        rpg = new RPGPlayer(playerName);
                        await message.Channel.SendMessageAsync(rpg.display());
                    }
                    catch
                    {
                        await message.Channel.SendMessageAsync("Joueur inconnu");
                    }
                }
            }

            if ((message.Content.StartsWith("!pendu") && !gameStarted) || penduStarted)
            {
                if (!penduStarted)
                {
                    penduStarted = true;
                    gameStarted = true;
                    pendu = new Pendu();
                    penduDisplay = await message.Channel.SendMessageAsync(pendu.guess);
                }
                else
                {
                    if (message.Content.Length > 1 || !Char.IsLetter(message.Content[0]))
                    {
                        await updatePendu(message, null);
                    }
                    else
                    {
                        string toDisplay = pendu.step(message.Content[0]);
                        await updatePendu(message, toDisplay);
                        await message.DeleteAsync();

                        if (pendu.isFinished || pendu.isWon)
                        {
                            penduStarted = false;
                            gameStarted = false;
                        }
                    }
                }
            }

            if ((message.Content == "!morpion" && !gameStarted) || morpionStarted)
            {
                if (!morpionStarted)
                {
                    if (j1 == null)
                    {
                        j1 = new MorpionPlayer(message.Author.Username);
                    }
                    else
                    {
                        j2 = new MorpionPlayer(message.Author.Username);
                        gameStarted = true;
                        morpionStarted = true;
                        morpion = new Morpion(j1, j2);
                        await message.Channel.SendMessageAsync("Jouer avec le pavé numérique (en haut à droite => 9)");
                        morpionDisplay = await message.Channel.SendMessageAsync(morpion.display());
                    }
                }
                else
                {
                    int n = 0;
                    bool isNumeric = int.TryParse(message.Content, out n);

                    if (!isNumeric || n < 1 || n > 9)
                    {
                        await updateMorpion(message, null);
                    }
                    else
                    {
                        await updateMorpion(message, morpion.step(n, message.Author.Username));
                        await message.DeleteAsync();
                        if (morpion.isWon)
                        {
                            string winner = message.Author.Mention;
                            winner += " a gagné !";
                            await message.Channel.SendMessageAsync(winner);
                            gameStarted = false;
                            morpionStarted = false;
                            j1 = null;
                            j2 = null;
                        }
                        if (morpion.isEnd)
                        {
                            await message.Channel.SendMessageAsync("Égalité");
                            gameStarted = false;
                            morpionStarted = false;
                            j1 = null;
                            j2 = null;
                        }
                    }
                }
            }
        }

        private async Task updateMorpion(SocketMessage message, string toDisplay)
        {
            await morpionDisplay.DeleteAsync();
            if (toDisplay == null)
            {
                morpionDisplay = await message.Channel.SendMessageAsync(morpion.display());
            }
            else
            {
                morpionDisplay = await message.Channel.SendMessageAsync(toDisplay);
            }
        }

        private async Task updatePendu(SocketMessage message, string toDisplay)
        {
            await penduDisplay.DeleteAsync();
            if (toDisplay == null)
            {
                penduDisplay = await message.Channel.SendMessageAsync(pendu.display());
            }
            else
            {
                penduDisplay = await message.Channel.SendMessageAsync(toDisplay);
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }

}
