using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Botana
{
    /// <summary>
    /// When we create an instance of this class, it create a string with all the commandes up to date.
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
                String instruction = "";

                if (command.TryGetValue(commandName, out instruction))
                {
                    help = "L'explication pour la commande !" + commandName + " est:";
                    help += Environment.NewLine;
                    help += "La commande ";
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
                    help += "!"+ s ;
                    help += Environment.NewLine;
                }
            }
        }


        public void InitCommand()
        {
                command["ping"] = "teste si le Bot est en ligne.";
                command["mot"] = "retourne un mot aléatoire.";
                command["wedzcode"] = "affiche un meme sur l'informatique.";
                command["mariok"] = "retourne une insulte aléatoire.";
                command["dés"] = "doit être formulé de cette façons: \"!dés [1] [2]\" avec 1 le nombre de façes et 2 le nombre de lancés. (l'argument 2 est optionnel)";
                command["rpg"] = " affiche la fiche perso d'un personnage.";
                command["pendu"] = "lance un pendu.";
                command["morpion"] = "lance un morpion une fois que 2 joueurs l'on tapé.";
        }
    }
}
