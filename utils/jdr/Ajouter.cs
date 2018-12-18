using System;
using System.Text;

namespace Botana
{
    internal class Ajouter
    {
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
                    answer = "Le jdr : " + splited[2] + " à était ajouté à la base donée.";
                }
            }
            else
            {
                answer = "Besoin du nom du jdr à créer aprés !jdr ajouter ";

            }
            return answer;
        }
    }
}