using System;
using System.Text;

namespace Botana
{
    internal class Supprimer
    {
        /// <summary>
        /// Deletes the rpg that have the ID found in the table of strings.
        /// </summary>
        /// <param name="splited">The table of strings sendtby the group function.</param>
        /// <returns>The string that will be shown on discord.</returns>
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
                            Console.WriteLine("{0} records deleted from database", count);
                            answer = "Le jdr : " + splited[2] + " a été supprimé de la base donées.";
                        }
                        else
                        {
                            answer = "Le jdr " + splited[2] + " n'est pas dans la base de données.";
                        }
                    }
                    else
                    {
                        return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr supprimer.";
                    }
                }
            }
            else
            {
                answer = "Besoin de l'ID d'un jdr séparé d'un espace après le !jdr supprimer.";
            }
            return answer;
        }
    }
}