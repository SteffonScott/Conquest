using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class BuildersTools : ItemLogic
    {
        public BuildersTools()
        {
            
            this.Name = "Builder's Tools";
            this.Movement = 0;
            this.Type = ItemType.BuildersTools;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
