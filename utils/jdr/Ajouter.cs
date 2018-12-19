using System;
using System.Text;

namespace Botana
{
    internal class Ajouter
    {
        /// <summary>
        /// Adds an rpg in the database with the parameter Gamename
        /// extracted from the the table of strings.
        /// </summary>
        /// <param name="splited">The table of string send by the group function.</param>
        /// <returns>The string that will be shown on discord.</returns>
        public static String ajouter(String[] splited)
        {
            string answer = "";
            if (splited.Length > 2)
            {
                using (var db = new RPGContext())
                {
                    db.Games.Add(new Game { GameName = splited[2] });
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);
                    answer = "Le jdr : " + splited[2] + " a été ajouté à la base données.";
                }
            }
            else
            {
                answer = "Besoin du nom du jdr à créer aprés !jdr ajouter.";
            }
            return answer;
        }
    }
}