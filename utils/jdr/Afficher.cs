using System;
using System.Text;

namespace Botana
{
    internal class Afficher
    {
        /// <summary>
        /// Displays all rpgs in the database, or the detail of one rpg if we precise the ID.
        /// </summary>
        /// <param name="splited">The table of string send by the group function.</param>
        /// <returns>The string that will be shown on discord.</returns>
        public static String afficher(string[] splited)
        {
            String answer = "";
            using (var db = new RPGContext())
            {
                if (splited.Length > 2)
                {
                    int gameID = 0;

                    if (int.TryParse(splited[2], out gameID))
                    {
                        var game = db.Games.Find(gameID);
                        if (game != null)
                        {
                            answer += "Voici les informations sur le jdr: " + game.GameId + Environment.NewLine;
                            answer += "Nom du Jdr : " + game.GameName + Environment.NewLine;
                            answer += "Nom du MJ : " + ((game.GameMaster != null) ? game.GameMaster : "Pas de MJ") + Environment.NewLine;
                        }
                        else
                        {
                            answer = "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr afficher.";
                        }
                    }
                    else
                    {
                        answer += "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr afficher.";
                    }
                }
                else
                {
                    answer += "Voici la liste des jdr actuels:" + Environment.NewLine;

                    foreach (var game in db.Games)
                    {
                        answer += game.GameId + " : " + game.GameName + Environment.NewLine;
                    }
                }
            }
            return answer;
        }
    }
}