using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Botana
{
    /// <summary>
    /// Creates a string with all the commands,
    /// or a precise one's description if it is specified.
    /// </summary>
    internal class Help
    {
        public string help { get; set; }

        Dictionary<string, string> command = new Dictionary<string, string>();

        public int nbCmd { get; set; }

        public Help(String message)
        {
            InitCommand();
            fetchHelp(message);
        }

        private void fetchHelp(String message)
        {

            string[] splited = message.Split(' ');

            if (splited.Length > 1)
            {
                String commandName = splited[1];
                if (splited.Length > 2)
                {
                    commandName += " " + splited[2];
                }
                String instruction = "";

                if (command.TryGetValue(commandName, out instruction))
                {
                    help = "<argument> : optionnel";
                    help += Environment.NewLine;
                    help += "!" + commandName;
                    help += instruction;
                }
                else
                {
                    help = "Commande non reconnue.";
                }
            }
            else
            {
                help = "La liste des commandes est :";
                help += Environment.NewLine;

                Dictionary<string, string>.KeyCollection keycommand = command.Keys;

                foreach (string s in keycommand)
                {
                    help += "!" + s;
                    help += Environment.NewLine;
                }
            }
        }


        public void InitCommand()
        {
            command["ping"] = "teste si le Bot est en ligne.";
            command["mot"] = " <phrase> retourne un mot aléatoire (ne prend pas la phrase <phrase> en compte).";
            command["wedzcode"] = "affiche un meme sur l'informatique.";
            command["pendu"] = "lance un pendu.";
            command["morpion"] = "lance un morpion une fois que 2 joueurs l'on tapée.";
        }
    }
}
