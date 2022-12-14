using System;
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

        public static void ReadPlayers()
        {
            string filepath = @"Players.txt";
            
            List<string> lines = File.ReadAllLines(filepath).ToList();
            
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                Player player = new Player(entries[0], Int32.Parse(entries[1]));
                MainWindow.players.Add(player);
            }
        }

        public static List<int> ReadBudgeds()
        {
            List<int> budgeds = new List<int>();
            string filepath = @"Budgeds.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach (string line in lines)
            {
                budgeds.Add(int.Parse(line));
            }
            return budgeds;
        }

        public static void ReadDeals()
        {
            string filepath = @"Deals.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();

            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                Player player = new Player(entries[0], Int32.Parse(entries[1]));
                if (!Boolean.Parse(entries[3]))
                {
                    Deal deal = new Deal(Int32.Parse(entries[2]),player);
                    MainWindow.deals.Add(deal);
                }
                else
                {
                    Deal deal = new Deal(Int32.Parse(entries[2]), player, Int32.Parse(entries[4]), Int32.Parse(entries[5]));
                    MainWindow.deals.Add(deal);
                }
            }
        }

        public static void SavePlayers()
        {
            string filepath = @"Players.txt";

            List<string> output = new List<string>();

            foreach (Player player in MainWindow.players)
            {
                output.Add(player.Present);
            }

            File.WriteAllLines(filepath, output);
        }

        public static void SaveDeals()
        {
            string filepath = @"Deals.txt";

            List<string> output = new List<string>();

            foreach(Deal deal in MainWindow.deals)
            {
                output.Add(deal.SaveString);
            }

            File.WriteAllLines(filepath, output);
        }

        public static void SaveBudgeds()
        {
            string filepath = @"Budgeds.txt";

            List<string> output = new List<string>();

            output.Add(MainWindow.inClub.ToString());
            output.Add(MainWindow.profit.ToString());

            File.WriteAllLines(filepath, output);
        }

    }
}
