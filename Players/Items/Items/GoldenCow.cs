using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;
using Conquest.Worlds;

namespace Conquest.Players.Items
{
    class GoldenCow : ItemLogic
    {
        public GoldenCow()
        {            
            this.Name = "Golden Cow";
            this.Movement = 3;
            this.Type = ItemType.GoldenCow;
        }
        public UseResult Use(Player player)
        {
            if (!CheckMovement(player)) { return new UseResult(false, ResultType.NoMovement); }
            int amount = Helper.GetRandom(500, 100);
            player.CurrentKingdom.Food += amount;
            return new UseResult(true, ResultType.Success, amount: amount);
        }
    }
}
