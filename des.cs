using System;
using System.Text;

namespace Botana
{
    internal class des
    {
        /// <summary>
        /// This method takes the wall message who start by: !dés [...] and extract a number out of it. 
        /// Then it sends a string that will be displayed by the bot.
        /// </summary>
        /// <param name="message">A string send by the user.</param>
        /// <returns>A random number between 1 and the number send by the user or the instructions to use this method.</returns>
        public static String random(string message)
        {
            string answer = "";
            string[] splited = message.Split(' ');

            int n = 0;
            bool isNumeric = int.TryParse(splited[1], out n);

            if (!isNumeric || n < 1)
            {
                answer += "La commande doit être suivie d'un espace puis d'un nombre supérieur à 1";
            }
            else
            {
                Random rnd = new Random();
                int chiffre = rnd.Next(1, n+1);
                answer += chiffre.ToString();
            }
            return answer;
        }
    }

}
