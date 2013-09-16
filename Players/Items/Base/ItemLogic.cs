using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conquest.Players.Items.Base
{
    public abstract class ItemLogic
    {
        public string Name { get; set; }
        public int Movement { get; set; }
        public ItemType Type { get; set; }

        public bool CheckMovement(Player player)
        {
            if (player.Movement < Movement) { return false; }
            player.Movement -= Movement;
            return true;
        }
    }
}