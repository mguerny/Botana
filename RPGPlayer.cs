using System;
using System.Collections.Generic;

namespace Botana
{
    internal class RPGPlayer
    {
        public bool valid = true;

        List<Stat> stats = new List<Stat>();
        System.IO.StreamReader file;

        // but : load les stats depuis un fichier texte qui s'appelerait "playerName".txt

        /// <summary>
        /// This method will create a instance an RPG player by reading a txt.
        /// </summary>
        /// <param name="playerName">A string with the name of the player.</param>
        public RPGPlayer(string playerName)
        {
            
            file = new System.IO.StreamReader(playerName + ".txt");

            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] stat = line.Split(";");
                string statName = stat[0];
                int statValue;
                bool isNumeric = int.TryParse(stat[1], out statValue);

                if (!isNumeric)
                {
                    Console.WriteLine("Player stats file error");
                    valid = false;
                }
                else
                {
                    stats.Add(new Stat(statName, statValue));
                }
            }
            file.Close();
        }

        public string displayStats()
        {
            string output = "";
            foreach (Stat s in stats)
            {
                output += s.name + ": " + s.value;
                output += Environment.NewLine;
            }
            return output;
        }

        internal string display()
        {
            if (!valid)
            {
                return "Stats invalides";
            }
            return displayStats();
        }
    }
}