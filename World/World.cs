using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conquest.Worlds
{
    public class World
    {
        public DateTime StartTime { get; set; }
        public TimeSpan UpTime
        {
            get
            {
                return StartTime - DateTime.Now;
            }
            private set { }
        }

        public World()
        {
            StartTime = DateTime.Now;

        }


        internal bool CreateKingdom(Player player)
        {
            if (player.Kingdom.Count >= 3) { return false; }
            player.Kingdom.Add(new Kingdom(player.CurrentCont));
            return true;
        }
    }
}