using System;
using System.Text;

namespace Botana
{
    internal class Afficher
    {
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
                            answer += "Voici les informaions sur le jdr: " + game.GameId + Environment.NewLine;
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
                    answer += "Voici la liste des jdr actuel:" + Environment.NewLine;

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