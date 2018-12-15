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
            if (splited.Length > 2)
            {
                int gameID = 0;
                try
                {
                    gameID = int.Parse(splited[2]);
                }
                catch (Exception)
                {
                    return "Besoin de l'ID d'un jdr connu séparé d'un espace après le !jdr ajouter .";
                }

                using (var db = new RPGContext())
                {
                    foreach (var game in db.Games)
                    {
                        if (gameID == game.GameId)
                        {
                            answer += "Voici les informaions sur le jdr: " + game.GameId + Environment.NewLine;
                            answer += "Nom du Jdr : " + game.GameName + Environment.NewLine;
                            answer += "Nom du MJ : " + ((game.GameMaster != null) ? game.GameMaster : "Pas de MJ" ) + Environment.NewLine;
                            answer += "Liste des joeurs : " + Environment.NewLine;
                            if (game.GamePlayer != null)
                            {
                                foreach (var player in game.GamePlayer)
                                {
                                    answer += "numéro du joueur : " + player.PlayerId + "; nom du joueur : " + player.PlayerName + Environment.NewLine;
                                }
                            }
                            else {
                                answer += "Pas de joueur";
                            }
                        }
                    }
                }
            }
            else
            {
                answer += "Voici la liste des jdr actuel:" + Environment.NewLine;
                using (var db = new RPGContext())
                {
                    foreach (var game in db.Games)
                    {
                        answer += game.GameId + " : " + game.GameName + Environment.NewLine;
                    }
                }
            }

            return answer;
        }

        public static String ajouter(string[] splited)
        {
            String answer = "";
            if (splited.Length > 2)
            {
                String gameName = splited[2];
                //Afficher le jdr demendé, avec le MJ et les joueurs.
                answer += "A";
            }
            else
            {
                answer = "Besoin du nom d'un jdr séparé d'un espace après le !jdr ajouter .";
            }

            return answer;
        }

        public static String supprimer(string[] splited)
        {
            String answer = "";
            if (splited.Length > 2)
            {
                String gameName = splited[2];
                //Afficher le jdr demendé, avec le MJ et les joueurs.
                answer += "A";
            }
            else
            {
                answer = "Besoin du nom d'un jdr séparé d'un espace après le !jdr ajouter .";
            }

            return answer; ;
        }
    }
}
/*if (commandName.Equals("afficher"))
{
    if (splited.Length > 2)
    {
        String gameName = splited[2];
        //Afficher le jdr demendé, avec le MJ et les joueurs.
    }
    else
    {
        //Afficher tous les noms de jdr.
    }
}

else if (commandName.Equals("ajouter"))
{
    if (splited.Length > 2)
    {
        String gameName = splited[2];
        //Créer le jdr demendé, avec le MJ et les joueurs.
        if (splited.Length > 3){
            String playerType = splited[3];
            if(splited.Length > 4){
                String playerName = splited[4];
                // Test si jdr existe
                    //Test si bon type de joueur

            }
            else{
                return "Besoin du nom du joueur séparé d'un espace après le !jdr ajouter 'nom du jdr' 'type de joueur' .";
            }
        }
        else{
            return "Besoin du nom du type du joueur séparé d'un espace après le !jdr ajouter 'nom du jdr' .";
        }
    }
    else
    {
        return "Besoin du nom d'un jdr séparé d'un espace après le !jdr ajouter .";
    }
}

else if (commandName.Equals("supprimer"))
{
    if (splited.Length > 2)
    {
        String gameName = splited[2];
        //Supprime le jdr demendé.
    }
    else
    {
        return "Besoin du nom d'un jdr séparé d'un espace après le !jdr supprimer .";
    }
}

else
{
    return "Commande inconue.";
}
}

*/
