using System;
using System.Text;

namespace Botana
{
    internal class Jdr
    {
        /// <summary>
        /// This fonction manages the message and redirect on the appropriate fonction.
        /// </summary>
        /// <param name="message">The string sent by the user.</param>
        /// <returns>The string who will be show on discord.</returns>
        public static String group(string message)
        {

            string[] splited = message.Split(' ');
            String answer = "";

            if (splited.Length > 1)
            {
                String commandName = splited[1];

                switch (commandName)
                {
                    case "afficher":
                        answer += Afficher.afficher(splited);
                        break;

                    case "ajouter":
                        answer = Ajouter.ajouter(splited);
                        break;

                    case "supprimer":
                        answer = Supprimer.supprimer(splited);
                        break;

                    case "modifier":
                        answer = Modifier.modifier(splited);
                        break;

                    default:
                        answer = "Commande inconue. (Liste des commandes: afficher, ajouter, supprimer, modifier";
                        break;
                }
            }
            else
            {
                answer = "Besoin d'une commande séparée d'un espace après le !jdr .";
            }
            return answer;
        }
    }
}
