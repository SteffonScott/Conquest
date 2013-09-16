using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class MaskUndead : ItemLogic
    {
        public MaskUndead()
        {
            
            this.Name = "Mask of the Undead";
            this.Movement = 6;
            this.Type = ItemType.MaskUndead;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
