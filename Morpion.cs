using System;

namespace Botana
{
    internal class Morpion
    {

        Joueur j1;
        Joueur j2;

        string current;

        bool first = true;

        int[,] array = new int[3, 3];

        string[] emojis = new string[] { ":black_large_square:", ":large_blue_circle:", ":red_circle:" };

        public Morpion(Joueur j1, Joueur j2)
        {
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
                current = player;
                first = false;
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
                current = (current == j1.discordName) ? j2.discordName : j1.discordName;
                array[positions[0], positions[1]] = (current == j1.discordName) ? 1 : 2;
                returnString += display();
            }
            return returnString;
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