using System;
using System.Text;

namespace Botana
{
    internal class Pendu
    {
        private int lifes;

        public Mot mot { get; }
        public string guess { get; set; }

        public Pendu()
        {
            mot = new Mot();
            mot.value = mot.value.ToLower();
            guess = "";
            lifes = 10;

            foreach (char c in mot.value)
            {
                guess += "-";
            }
        }

        internal void reveal(char c)
        {
            StringBuilder strBuilder = new StringBuilder(guess);
            for(int i = 0; i<guess.Length; i++){
                if (mot.value[i] == c){
                    strBuilder[i] = c;
                }
            }
            guess = strBuilder.ToString();
        }
    }
}