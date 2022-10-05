using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FIFA_Market_Tracker
{
    public class Deal
    {
        private int boughtFor;
        private int soldFor;
        public Player player;
        private int profit = 0;
        public bool isSold = false;
        public Button sellButton;
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        public Deal(int boughtFor, Player player)
        {
            this.boughtFor = boughtFor;
            this.player = player;
        }

        public void sellPlayer(int soldFor)
        {
            this.soldFor = soldFor;
            profit = (Int32)(soldFor*0.95) - boughtFor;
            isSold = true;
            MainWindow.inClub -= boughtFor;
            MainWindow.profit += profit;
            mw.UpdateBudgeds();
        }
        public string Present
        {
            get
            {
                return $"{player.Present}: {boughtFor}";
            }
        }
        public string PresentArchive
        {
            get
            {
                return $"{player.Present}: B:{boughtFor} S:{soldFor} P:{profit}";
            }
        }

        public string SaveString
        {
            get
            {
                return $"{player.Present},{boughtFor},{isSold},{soldFor},{profit}";
            }
        }
    }
}
