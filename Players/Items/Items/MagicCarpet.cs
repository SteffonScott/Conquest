using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class MagicCarpet : ItemLogic
    {
        public MagicCarpet()
        {
            
            this.Name = "Magic Carpet";
            this.Type = ItemType.MagicCarpet;
            this.Movement = 0;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
