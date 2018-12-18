using System;
using System.Text;

namespace Botana
{
    internal class Modifier
    {
        public static String modifier(string[] splited)
        {
            String answer = "";
            if (splited.Length > 2)
            {
                using (var db = new RPGContext())
                {
                    int gameID = 0;

                    if (int.TryParse(splited[2], out gameID))
                    {
                        if (splited.Length > 3)
                        {
                            switch (splited[3])
                            {
                                case "nom":
                                    answer += modif(splited, gameID, true);
                                    break;
                                case "mj":
                                    answer += modif(splited, gameID, false);
                                    break;
                                default:
                                    answer = "Besoin d'un type de modification connu (soit nom, soit mj) séparé d'un espace après le !jdr modifier .";
                                    break;
                            }
                        }
                        else
                        {
                            answer = "Besoin de l'ID d'un jdr connu et d'un type de moification connu séparé d'un espace après le !jdr modifier.";
                        }
                    }
                    else
                    {
                        return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr modifier.";
                    }
                }
            }
            else
            {
                answer = "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr modifier .";
            }
            return answer;
        }

        public static String modif(String[] splited, int GameID, bool isName)
        {
            String answer = "";
            if (splited.Length > 4)
            {
                using (var db = new RPGContext())
                {
                    var game = db.Games.Find(GameID);
                    if (isName)
                    {
                        game.GameName = splited[4];
                        answer += "Le nom du jdr : " + GameID + " à était mis à jour.";
                    }
                    else
                    {
                        game.GameMaster = splited[4];
                        answer += "Le nom du mj du jdr : " + GameID + " à était mis à jour."; ;
                    }
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);
                }
            }
            else
            {
                answer = "Besoin du nom.";
            }
            return answer;
        }
    }
}