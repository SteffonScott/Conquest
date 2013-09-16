using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class OrbSafety : ItemLogic
    {
        public OrbSafety()
        {
            
            this.Name = "Orb of Safety";
            this.Movement = 4;
            this.Type = ItemType.OrbSafety;
        }
        public UseResult Use(Player player)
        {
            if (!CheckMovement(player)) { return new UseResult(false, ResultType.NoMovement); }
            if (player.CurrentKingdom.Protection == 1) { return new UseResult(false, ResultType.IsProtected); }
            player.CurrentKingdom.Protection = 1;
            return new UseResult(true, ResultType.Success);
        }
    }
}
