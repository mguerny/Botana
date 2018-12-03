using System;
using System.Collections.Generic;

namespace Botana
{
    internal class RPGPlayer
    {
        List<Stat> stats = new List<Stat>();
        System.IO.StreamReader file;

        // but : load les stats depuis un fichier texte qui s'appelerait playerName.txt
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
                }
                else
                {
                    stats.Add(new Stat(statName, statValue));
                }
            }
        }

        public string displayStats()
        {
            string output = "";
            foreach(Stat s in stats)
            {
                output += s.name + " " + s.value;
                output += Environment.NewLine;
            }
            return output;
        }
    }
}