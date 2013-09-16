using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conquest.Players.Items.Base
{
    public static class ItemFactory
    {
        public static Item CreateItem(int inum)
        {
            switch (inum)
            {
                case 1: 
                    return new Item(ItemType.AnimalAmulet);
                case 2:
                    return new Item(ItemType.AxeOfDespair);
                case 3:
                    return new Item(ItemType.BagOfHolding);
                case 4:
                    return new Item(ItemType.BagOfTricks);
                case 5:
                    return new Item(ItemType.BuildersTools);
                case 6:
                    return new Item(ItemType.ChaosDevice);
                case 7:
                    return new Item(ItemType.DustOfBlinking);
                case 8:
                    return new Item(ItemType.OracleEye);
                case 9:
                    return new Item(ItemType.GauntletFumbling);
                case 10:
                    return new Item(ItemType.GoldenCow);
                case 11:
                    return new Item(ItemType.LureVulture);
                case 12:
                    return new Item(ItemType.MagicCarpet);
                case 13:
                    return new Item(ItemType.MagicQuiver);
                case 14:
                    return new Item(ItemType.MaskUndead);
                case 15: 
                    return new Item(ItemType.OrbSafety);
                case 16:
                    return new Item(ItemType.PotEndurance);
                case 17:
                    return new Item(ItemType.PotSpeed);
                case 18:
                    return new Item(ItemType.PouchComponent);
            }
            return new Item(ItemType.None);
        }
    }
}