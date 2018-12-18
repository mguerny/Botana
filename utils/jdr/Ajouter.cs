using System;
using System.Text;

namespace Botana
{
    internal class Ajouter
    {
        /// <summary>
        /// This fonction add an rpg in the database with the parameter Gamename extract from the the table of string.
        /// </summary>
        /// <param name="splited">the table of string send by the fonction group.</param>
        /// <returns>The string who will be show on discord.</returns>
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
                    answer = "Le jdr : " + splited[2] + " à était ajouté à la base donées.";
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