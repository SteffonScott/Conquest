using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class LureVulture : ItemLogic
    {
        public LureVulture()
        {
            
            this.Name = "Lure of the Vulture";
            this.Movement = 3;
            this.Type = ItemType.LureVulture;
        }
        public UseResult Use(Player player)
        {
            Kingdom kingdom = player.CurrentKingdom;

            if (!CheckMovement(player))
            {
                return new UseResult(false, ResultType.NoMovement);
            }

            player.Movement -= Movement;
            return new UseResult(true, ResultType.Success);
        }
    }
}
