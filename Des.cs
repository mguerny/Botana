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

            int throws = 1;

            if (splited.Length > 2)
            {
                int intermediaryThrow = 0;
                bool isNumeric2 = int.TryParse(splited[2], out intermediaryThrow);
                if (!isNumeric2 || intermediaryThrow < 1)
                {
                    answer += "Le nombre de lancés doit être un nombre supérieur à 1.";
                }
                if (intermediaryThrow > 100)
                {
                    answer += "Woaw! Woaw! Calm down cow boy! You gonna throw it 100 times okay.";
                    answer += Environment.NewLine;
                    intermediaryThrow = 100;
                }
                throws = intermediaryThrow;
            }

            int Faces = 0;
            bool isNumeric1 = int.TryParse(splited[1], out Faces);

            if (!isNumeric1 || Faces < 1)
            {
                answer += "La commande doit être suivie d'un nombre supérieur à 1 et inférieur à 2147483647.";
            }
            else
            if (Faces > 100000)
            {
                answer += "Best I can do is 100 000.";
                answer += Environment.NewLine;
                Faces = 100000;
            }
            for (int i = 0; i < throws; i++)
            {
                Random rnd = new Random();
                int chiffre = rnd.Next(1, Faces + 1);
                answer += chiffre.ToString();
                answer += " ";
            }
            
            return answer;
        }
    }
}
