using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class DustOfBlinking : ItemLogic
    {
        public DustOfBlinking()
        {
            
            this.Name = "Dust of Blinking";
            this.Movement = 3;
            this.Type = ItemType.DustOfBlinking;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
