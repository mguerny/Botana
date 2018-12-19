using System;
using System.Text;

namespace Botana
{
    internal class Modifier
    {
        /// <summary>
        /// Manages the message and redirects to the appropriate function 
        /// with some tests to check if the command is good.
        /// </summary>
        /// <param name="splited">The table of strings sent by the group function.</param>
        /// <returns>The string that will be shown on discord.</returns>
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
                                    answer = "Besoin d'un type de modification connu (soit nom, soit mj) séparé d'un espace après le !jdr modifier -id-.";
                                    break;
                            }
                        }
                        else
                        {
                            answer = "Besoin de l'ID d'un jdr connu puis d'un type de modification connu séparé d'un espace après le !jdr modifier.";
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
                answer = "Besoin de l'ID d'un jdr séparé d'un espace après le !jdr modifier .";
            }
            return answer;
        }

        /// <summary>
        /// Changes the desired value. With some tests and a choice made by isName.
        /// </summary>
        /// <param name="splited">The table of string send by the group function.</param>
        /// <param name="GameID">The integer of the rpg to change.</param>
        /// <param name="isName">Is used to choose if we want to change the name of the game or the gm.</param>
        /// <returns>The string that will be shown on discord.</returns>
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
                        answer += "Le nom du jdr : " + GameID + " a été mis à jour.";
                    }
                    else
                    {
                        game.GameMaster = splited[4];
                        answer += "Le nom du mj du jdr : " + GameID + " a été mis à jour."; ;
                    }
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records saved to database", count);
                }
            }
            else
            {
                answer = "Besoin du nom du jdr ou du mj.";
            }
            return answer;
        }
    }
}