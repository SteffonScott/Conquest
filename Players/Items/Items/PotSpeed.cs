using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class PotSpeed : ItemLogic
    {
        public PotSpeed()
        {
            
            this.Name = "Potion of Speed";
            this.Movement = 0;
            this.Type = ItemType.PotSpeed;
        }
        public UseResult Use(Player player)
        {
            if (!CheckMovement(player)) 
            {
                return new UseResult(false, ResultType.NoMovement);
            }
            player.Movement += 10;
            return new UseResult(true, ResultType.Success);
        }
    }
}
