using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class PouchComponent : ItemLogic
    {
        public PouchComponent()
        {
            
            this.Name = "Pouch of Everful Components";
            this.Movement = 5;
            this.Type = ItemType.PouchComponent;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
