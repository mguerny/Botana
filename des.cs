using System;
using System.Text;

namespace Botana
{
    internal class des
    {
        public static String random(string message)
        {
            string answer = "";
            string[] splited = message.Split(' ');

            int n = 0;
            bool isNumeric = int.TryParse(splited[1], out n);

            Console.WriteLine(isNumeric);
            Console.WriteLine(n);

            if (!isNumeric || n < 1)
            {
                answer += "La commande doit être suivie de :\" C\" avec C un nombre supérieur à 1";
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
