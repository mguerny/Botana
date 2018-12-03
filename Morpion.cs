using System;

namespace Botana
{
    internal class Morpion
    {

        MorpionPlayer j1;
        MorpionPlayer j2;

        string current;

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

        internal string step(int content, string player)
        {
            string returnString = "";
            if (first)
            {
                if (player == j1.discordName || player == j2.discordName)
                {
                    current = player;
                    first = false;
                }
            }

            int[] positions = parsePositions(content);

            if (array[positions[0], positions[1]] != 0)
            {
                returnString += "Quelqu'un a déjà joué ici :angry:";
            }
            else if (player != current)
            {
                returnString += "Ce n'est pas à vous de jouer !";
            }
            else
            {
                array[positions[0], positions[1]] = (current == j1.discordName) ? 1 : 2;
                current = (current == j1.discordName) ? j2.discordName : j1.discordName;
                returnString += display();
            }

            isWon = getWon();
            isEnd = getEnd();

            return returnString;
        }

        private bool getEnd()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(array[i, j] == 0)
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

        private int[] parsePositions(int content)
        {
            int row = 2 - (content - 1) / 3;
            int column = (content - 1) % 3;
            return new int[] { row, column };
        }
    }
}