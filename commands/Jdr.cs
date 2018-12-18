using System;
using System.Text;

namespace Botana
{
    internal class Jdr
    {
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
/* Convert plus jolie: #endregionint num;
if (int.TryParse(monstring, out num))
{
// code si conversion OK
}
else
{
// code si conversion KO
} */
