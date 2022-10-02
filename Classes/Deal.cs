using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA_Market_Tracker
{
    public class Deal
    {
        private int boughtFor;
        private int soldFor;
        private Player player;
        private int profit;
        private bool isSold;

        public Deal(int boughtFor, Player player)
        {
            this.boughtFor = boughtFor;
            this.player = player;
            isSold = false;
        }

        public void sellPlayer(int soldFor, Player player)
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
