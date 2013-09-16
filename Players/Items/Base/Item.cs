using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Players.Items;
using Conquest.Players.Items.Base;
using System.Reflection;

namespace Conquest
{
    public partial class Item
    {
        private dynamic Logic { get; set; }
        MethodInfo UseMethod { get; set; }
        public Item() { }
        public Item(ItemType type)
        {
            Logic = (ItemLogic)Activator.CreateInstance(null, string.Concat("Conquest.Players.Items.", type.ToString())).Unwrap();
            UseMethod = Logic.GetType().GetMethod("Use");
            this.Name = Logic.Name;
            this.Movement = Logic.Movement;
            this.Type = Logic.Type;
        }

        public UseResult Use(Player player)
        {
            UseResult result = Logic.Use(player);

            if (result.success == true)
            {
                player.CurrentKingdom.Vault.RemoveItem(this);
            }

            return result;
        }

        internal bool CheckMovement()
        {
            if (Vault.Kingdom.Player.Movement < Movement) { return false; }
            Vault.Kingdom.Player.Movement -= Movement;
            return true;
        }
    }
}