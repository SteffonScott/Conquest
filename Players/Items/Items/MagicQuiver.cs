using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class MagicQuiver : ItemLogic
    {
        public MagicQuiver()
        {
            
            this.Name = "Magic Quiver";
            this.Movement = 0;
            this.Type = ItemType.MagicQuiver;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
