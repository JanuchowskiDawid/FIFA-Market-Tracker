using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIFA_Market_Tracker
{
    public class Player
    {
        private string fullName;
        private int overallRating;

        public Player(string fullName, int overallRating)
        {
            this.fullName = fullName;
            this.overallRating = overallRating;
        }

        public string Present
        {
            get
            {
                return $"{fullName}, {overallRating}";
            }
        }
        
    }
}
