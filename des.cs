using System;
using System.Text;

namespace Botana
{
    internal class Des
    {
        /// <summary>
        /// This method takes the whole message that starts by: !dés [...] and extracts a number out of it. 
        /// Then it sends a string that will be displayed by the bot.
        /// </summary>
        /// <param name="message">A string sent by the user.</param>
        /// <returns>A random number between 1 and the number sent by the user X time (with X the second argument(X init at 1)) or the instructions to use this method.</returns>
        public static String random(string message)
        {
            string answer = "";
            string[] splited = message.Split(' ');

            if (splited.Length < 2)
            {
                answer += "La commande doit être suivie d'un espace.";
                return answer;
            }

            int Faces = 0;
            int throws = 1;
            bool isNumeric1 = int.TryParse(splited[1], out n);

            if (splited.Length > 2)
            {
                int intermediaryThrow = 0;
                bool isNumeric2 = int.TryParse(splited[2], out intermediaryThrow);
                if (!isNumeric2 || intermediaryThrow < 1)
                {
                    answer += "Le nombre de lancés doit être un nombre supérieur à 1.";
                }
                throws = intermediaryThrow;
            }

            if (!isNumeric1 || Faces < 1)
            {
                answer += "La commande doit être suivie d'un nombre supérieur à 1";
            }
            else
            {
                for (int i = 0; i < throws; i++)
                {
                    Random rnd = new Random();
                    int chiffre = rnd.Next(1, Faces + 1);
                    answer += chiffre.ToString();
                    answer += " ";
                }
            }
            return answer;
        }
    }
}
