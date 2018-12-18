using System;
using System.Text;

namespace Botana
{
    internal class Supprimer
    {
        public static String supprimer(String[] splited)
        {
            string answer = "";
            if (splited.Length > 2)
            {
                using (var db = new RPGContext())
                {
                    int gameID = 0;

                    if (int.TryParse(splited[2], out gameID))
                    {
                        var game = db.Games.Find(gameID);
                        if (game != null)
                        {
                            db.Games.Remove(game);
                            var count = db.SaveChanges();
                            Console.WriteLine("{0} records delete to database", count);
                            answer = "Le jdr : " + splited[2] + " à était supprimé de la base donées.";
                        }
                        else
                        {
                            answer = "Le jdr " + splited[2] + " n'est pas dans la base de données.";
                        }
                    }
                    else
                    {
                        return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr afficher.";
                    }
                }
            }
            else
            {
                answer = "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr supprimer.";
            }
            return answer;
        }
    }
}