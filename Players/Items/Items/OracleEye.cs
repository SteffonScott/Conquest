using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    class OracleEye : ItemLogic
    {
        public OracleEye()
        {
            
            this.Name = "Eye of the Oracle";
            this.Movement = 2;
            this.Type = ItemType.OracleEye;
        }
        public UseResult Use()
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}
