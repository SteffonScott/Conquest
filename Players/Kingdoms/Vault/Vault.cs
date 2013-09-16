using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Players.Items;
using System.Data.Entity;
using System.ServiceModel;

namespace Conquest
{
    public partial class Vault : DbContext
    {

        public bool ContainsItem(ItemType itype)
        {
            if (Items.Count(i => i.Type == itype) > 0) { return true; }
            return false;
        }
        private bool HasAvailableSlot()
        {
            if (this.Items.Count >= 16) { return false; }
            return true;
        }

        public bool AddItem(Item item)
        {
            if (HasAvailableSlot() && !ContainsItem(item.Type))
            {
                    Items.Add(item);
                    return true;
            }
            return false;
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
            return;
        }
        ///

    }
}