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
                    help = "-argument- : obligatoire";
                    help += Environment.NewLine;
                    help += "<argument> : optionnel";
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
            command["mariok"] = "retourne une insulte aléatoire.";
            command["dés"] = " -nombre- <lancés> Lance 1 ou <lancés> dés de -nombre- faces";
            command["rpg"] = " -nom- affiche la fiche perso d'un personnage.";
            command["pendu"] = "lance un pendu.";
            command["morpion"] = "lance un morpion une fois que 2 joueurs l'on tapée.";
            command["jdr"] = "permet de gérer une base de données. 4 commande disponible après !jdr: afficher, ajouter, modifier, supprimer.";
            command["jdr afficher"] = " -id- affiche la liste des jdr actuels ou les détails d'un jdr si on rajoute l'ID <id> du jdr.";
            command["jdr ajouter"] = " -nom- ajoute un jdr nommé -nom-.";
            command["jdr modifier"] = "  -'nom'/'mj'- -nom- modifie le nom -nom- du jdr ou de son MJ.";
            command["jdr supprimer"] = " -id- supprime un jdr si l'ID -id- est valide.";
        }
    }
}
