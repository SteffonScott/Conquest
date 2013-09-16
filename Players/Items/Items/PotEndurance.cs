using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class PotEndurance : ItemLogic
    {
        public PotEndurance()
        {
            
            this.Name = "Potion of Endurance";
            this.Movement = 2;
            this.Type = ItemType.PotEndurance;
        }
        public UseResult Use(Player player)
        {
            if (!CheckMovement(player))
            {
                return new UseResult(false, ResultType.NoMovement);
            }

            player.NumAttacks += 2;
            return new UseResult(true, ResultType.Success);
        }
    }
}
