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
                        answer += afficher(splited);
                        break;

                    case "ajouter":
                        answer = ajouter(splited);
                        break;

                    case "supprimer":
                        answer = supprimer(splited);
                        break;

                    case "modifier":
                        answer = modifier(splited);
                        break;

                    default:
                        answer = "Commande inconue.";
                        break;
                }
            }
            else
            {
                answer = "Besoin d'une commande séparée d'un espace après le !jdr .";
            }
            return answer;
        }

        public static String afficher(string[] splited)
        {
            String answer = "";
            using (var db = new RPGContext())
            {
                if (splited.Length > 2)
                {
                    int gameID = 0;

                    try
                    {
                        gameID = int.Parse(splited[2]);
                    }
                    catch (Exception)
                    {
                        return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr afficher.";
                    }

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
                    answer += "Voici la liste des jdr actuel:" + Environment.NewLine;

                    foreach (var game in db.Games)
                    {
                        answer += game.GameId + " : " + game.GameName + Environment.NewLine;
                    }
                }
            }
            return answer;
        }

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

        public static String supprimer(String[] splited)
        {
            string answer = "";
            if (splited.Length > 2)
            {
                using (var db = new RPGContext())
                {
                    int gameID = 0;

                    try
                    {
                        gameID = int.Parse(splited[2]);
                    }
                    catch (Exception)
                    {
                        return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr afficher.";
                    }

                    var game = db.Games.Find(gameID);
                    Console.WriteLine("remove game");
                    db.Games.Remove(game);
                    Console.WriteLine("save change");
                    var count = db.SaveChanges();
                    Console.WriteLine("{0} records delete to database", count);
                    answer = "Le jdr : " + splited[2] + " à était supprimé de la base donée.";
                }
            }
            else
            {
                answer = "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr supprimer.";

            }
            return answer;
        }

        public static String modifier(string[] splited)
        {
            String answer = "";
            if (splited.Length > 2)
            {
                using (var db = new RPGContext())
                {
                    int gameID = 0;

                    try
                    {
                        gameID = int.Parse(splited[2]);
                    }
                    catch (Exception)
                    {
                        return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr afficher.";
                    }

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
                                answer = "Besoin d'un type de modification connu (soit name, soit mj) séparé d'un espace après le !jdr modifier .";
                                break;
                        }
                    }
                    else
                    {
                        answer = "Besoin d'un type de modification (soit name, soit mj) séparé d'un espace après le !jdr modifier .";
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

/* Convert plus jolie: #endregionint num;
if (int.TryParse(monstring, out num))
{
// code si conversion OK
}
else
{
// code si conversion KO
} */
