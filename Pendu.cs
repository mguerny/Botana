using System;
using System.Text;

namespace Botana
{
    internal class Pendu
    {
        public int lifes { get; private set; }
        public Boolean isFinished { get; private set; }
        public Boolean isWon { get; private set; }
        public string guess { get; private set; }

        private Mot mot;

        public Pendu()
        {
            mot = new Mot();
            Console.WriteLine(mot.value);
            mot.value = mot.value.ToLower();
            mot.value = Remove.removeAccents(mot.value);
            lifes = 10;

            guess = "";
            foreach (char c in mot.value)
            {
                guess += "-";
            }
        }
        /// <summary>
        /// This method uses the letter sent by the user and the number of lifes to update the state of the game and return it.
        /// </summary>
        /// <param name="character">A char sent by the user.</param>
        /// <returns>A string that represent the state of the game, "Perdu, ...', "Gagné ! ...!--" or empty if it's not win nor lose.</returns>
        public string step(char character)
        {
            string returnString = "";
            // si pas de lettre trouvée, décrémente lifes
            lifes += reveal(character) ? 0 : -1;

            returnString += guess;

            isWon = (guess.IndexOf('-') == -1);
            isFinished = (lifes == 0);

            if (isFinished)
            {
                returnString += "\n";
                returnString += "Perdu, tu n'as plus de vies ...";
            }
            if (isWon)
            {
                returnString += "\n";
                returnString += "Gagné ! (" + lifes + " Vie(s) restante.)";
            }

            return returnString;
        }
        /// <summary>
        /// This method use the char sent by the user to update the guess and return a letter that represent if a letter was find.
        /// </summary>
        /// <param name="c">A char sent by the method step.</param>
        /// <returns>A boolean who represent if a letter was find.</returns>
        internal bool reveal(char c)
        {
            Boolean found = false;
            StringBuilder strBuilder = new StringBuilder(guess);
            for (int i = 0; i < guess.Length; i++)
            {
                if (mot.value[i] == c)
                {
                    found = true;
                    strBuilder[i] = c;
                }
            }
            guess = strBuilder.ToString();
            return found;
        }
    }
}