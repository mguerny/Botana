using System;

namespace Botana
{
    internal class Morpion
    {

        MorpionPlayer j1;
        MorpionPlayer j2;

        MorpionPlayer current;

        bool first = true;
        public bool isWon { get; private set; }
        public bool isEnd { get; private set; }

        int[,] array = new int[3, 3];

        string[] emojis = new string[] { ":black_large_square:", ":large_blue_circle:", ":red_circle:" };

        public Morpion(MorpionPlayer j1, MorpionPlayer j2)
        {
            isWon = false;
            this.j1 = j1;
            this.j2 = j2;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = 0;
                }
            }
        }

        /// <summary>
        /// Makes the player's move, updates the game.
        /// </summary>
        /// <param name="content">A string sent by the user.</param>
        /// <param name="playerName">The username</param>
        /// <returns>
        /// The string containing the visual display of the game,
        /// or one of the error messages
        /// </returns>
        internal string step(int content, string playerName)
        {
            string returnString = "";

            if (first)
            {
                if (playerName == j1.discordName)
                {
                    current = j1;
                    first = false;
                }
                if (playerName == j2.discordName)
                {
                    current = j2;
                    first = false;
                }
            }

            int[] positions = parsePositions(content);

            if (array[positions[0], positions[1]] != 0)
            {
                returnString += "Quelqu'un a déjà joué ici :angry:" + Environment.NewLine;
                returnString += display();
            }
            else if (playerName != current.discordName)
            {
                returnString += "Ce n'est pas à vous de jouer !" + Environment.NewLine;
                returnString += display();
            }
            else
            {
                array[positions[0], positions[1]] = current.value;
                current = (current == j1) ? j2 : j1;
                returnString += display();
            }

            isWon = getWon();
            isEnd = getDraw() && !isWon;

            return returnString;
        }

        private bool getDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (array[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool getWon()
        {
            bool row = false;
            bool column = false;
            bool diagonal = false;

            int winner = 0;

            // row
            for (int i = 0; i < 3; i++)
            {
                if (array[i, 0] != 0)
                {
                    if (array[i, 0] == array[i, 1] && array[i, 0] == array[i, 2])
                    {
                        row = true;
                        winner = array[i, 0];
                    }
                }
            }

            if (row)
            {
                return true;
            }

            // column
            for (int i = 0; i < 3; i++)
            {
                if (array[0, i] != 0)
                {
                    if (array[0, i] == array[1, i] && array[0, i] == array[2, i])
                    {
                        column = true;
                        winner = array[0, i];
                    }
                }
            }

            if (column)
            {
                return true;
            }

            diagonal = (array[0, 0] == array[1, 1] && array[0, 0] == array[2, 2]);

            diagonal |= (array[0, 2] == array[1, 1] && array[0, 2] == array[2, 0]);

            diagonal &= (array[1, 1] != 0);

            if (diagonal)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a string of emoji names from the values array
        /// to create a nice display in discord
        /// </summary>
        internal string display()
        {
            string toDisplay = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    toDisplay += emojis[array[i, j]];
                    toDisplay += " ";
                }
                toDisplay += Environment.NewLine;
            }
            return toDisplay;
        }


        /// <summary>
        /// Transforms the numpad value to x and y coordinates
        /// </summary>
        private int[] parsePositions(int content)
        {
            int row = 2 - (content - 1) / 3;
            int column = (content - 1) % 3;
            return new int[] { row, column };
        }
    }
}