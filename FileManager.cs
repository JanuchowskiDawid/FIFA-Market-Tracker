﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FIFA_Market_Tracker
{
    public static class FileManager
    {

        public static void ReadFile()
        {
            string filepath = @"D:\Data.txt";
            
            List<string> lines = File.ReadAllLines(filepath).ToList();
            
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                Player player = new Player(entries[0], Int32.Parse(entries[1]));
                MainWindow.players.Add(player);
            }

            MainWindow.players.Add(new Player("Mbappe", 92));

            List<string> output = new List<string>();

            foreach (Player player in MainWindow.players)
            {
                output.Add(player.Present);
            }

            File.WriteAllLines(filepath, output);
        }
    }
}
