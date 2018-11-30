using System;
using System.Text;

namespace Botana
{
    internal class Pendu
    {
        private int lifes;
        public Boolean isFinish{get{
            return (lifes <= 0);}
            }
        public Mot mot { get; }
        public string guess { get; set; }

        public Pendu()
        {
            mot = new Mot();
            mot.value = mot.value.ToLower();
            mot.value = Remove.removeAccents(mot.value);
            guess = "";
            lifes = 10;

            foreach (char c in mot.value)
            {
                guess += "-";
            }
        }

        internal void reveal(char c)
        {
            Console.WriteLine("lifes = " +lifes);
            Boolean find = false;
            StringBuilder strBuilder = new StringBuilder(guess);
            for (int i = 0; i < guess.Length; i++)
            {
                if (mot.value[i] == c)
                {
                    strBuilder[i] = c;
                    find = true;
                }
            }
            guess = strBuilder.ToString();
            if(!find){
                lifes--;
                Console.WriteLine("lifes = " +lifes);
            }
        }
    }
}