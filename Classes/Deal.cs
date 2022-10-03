using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FIFA_Market_Tracker
{
    public class Deal
    {
        private int boughtFor;
        private int soldFor;
        public Player player;
        private int profit;
        public bool isSold;
        public Button sellButton;

        public Deal(int boughtFor, Player player)
        {
            this.boughtFor = boughtFor;
            this.player = player;
            isSold = false;
        }

        public void sellPlayer(int soldFor)
        {
            this.soldFor = soldFor;
            this.profit = soldFor - this.boughtFor;
            isSold = true;
        }
        public string Present
        {
            get
            {
                return $"{player.Present}: {boughtFor}";
            }
        }
    }
}
