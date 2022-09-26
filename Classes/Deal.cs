using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA_Market_Tracker
{
    internal class Deal
    {
        private int boughtFor;
        private int soldFor;
        private Player player;
        private int profit;
        private bool isSold = false;

        public Deal(int boughtFor, Player player)
        {
            this.boughtFor = boughtFor;
            this.player = player;
        }

        public void sellPlayer(int soldFor, Player player)
        {
            this.soldFor = soldFor;
            this.profit = soldFor - this.boughtFor;
            isSold = true;
        }
    }
}
