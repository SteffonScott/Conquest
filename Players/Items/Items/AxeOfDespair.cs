using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class AxeOfDespair : ItemLogic
    {
        public AxeOfDespair()
        {
            
            this.Name = "Axe of Despair";
            this.Movement = 0;
            this.Type = ItemType.AxeOfDespair;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
