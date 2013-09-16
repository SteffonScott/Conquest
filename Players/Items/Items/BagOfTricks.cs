using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class BagOfTricks : ItemLogic
    {
        public BagOfTricks()
        {
            
            this.Name = "Bag of Tricks";
            this.Movement = 3;
            this.Type = ItemType.BagOfTricks;
        }
        public UseResult Use(Player player)
        {
            if (!CheckMovement(player)) { return new UseResult(false, ResultType.NoMovement); }
            return new UseResult(true, ResultType.Success);
        }
    }
}
