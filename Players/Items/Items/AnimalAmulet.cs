using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Combat;
using Conquest.Players.Items.Base;

namespace Conquest.Players.Items
{
    public class AnimalAmulet : ItemLogic , IPlayerUsable
    {
        public AnimalAmulet()
        {
            this.Name = "Amulet of Animal Summoning";
            this.Movement = 3;
            this.Type = ItemType.AnimalAmulet;
        }
        public UseResult Use(Player player)
        {
            return new UseResult(true, ResultType.Success);
        }
    }
}