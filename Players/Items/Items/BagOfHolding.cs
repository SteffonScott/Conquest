using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class BagOfHolding : ItemLogic
    {
        public BagOfHolding()
        {
            
            this.Name = "Bag of Holding";
            this.Type = ItemType.BagOfHolding;
            this.Movement = 0;
        }
    }
}
