using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class ChaosDevice : ItemLogic
    {
        public ChaosDevice()
        {
            
            this.Name = "Chaos Device";
            this.Movement = 0;
            this.Type = ItemType.ChaosDevice;
        }
    }
}
