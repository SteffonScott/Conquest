using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conquest.Worlds.Housekeeping
{
    public static class HKSettings
    {
        public const int MaxWorkers = 10000;
        public const int MaxCurrency = 50000000;

    }
    public enum HKEvents
    {
        None,
        Merchant,
        Soldiers,
        RecoverFood,
        Workers,
        Explorers,
        FindCastle,
        Thieves,
        Plague,
        Uprising
    }
    internal class Housekeeping
    {
        Player[] players;

        public Housekeeping(Player[] players)
        {
            this.players = players;

            CheckStructures(players);
            IncreaseMovement(players);
            ProduceFood(players);
            ProduceIncome(players);
            ProduceWorkers(players);
            Events(players);
        }

        private void CheckStructures(Player[] players)
        {
            foreach (Player p in players)
            {
                foreach (Kingdom k in p.Kingdom)
                {
                    int SupportedStructures;
                    int LostStructures;
                    if ((int)k.Land >= (int)k.Structures * 100)
                    {
                        return;
                    }
                    SupportedStructures = (int)k.Land / 100;
                    LostStructures = (int)k.Structures - SupportedStructures;
                    k.Structures = SupportedStructures;
                }
            }
        }
        private void ProduceWorkers(Player[] players)
        {
            foreach (Player p in players)
            {
                foreach (Kingdom k in p.Kingdom)
                {
                    int amount;

                    double MaxBirths = (int)k.Workers * .40;
                    double MinBirths = (int)k.Workers * .30;
                    double MaxDeaths = (int)k.Workers * .40;
                    double MinDeaths = (int)k.Workers * .40;

                    amount = Helper.GetRandom(Convert.ToInt32(MaxBirths), Convert.ToInt32(MinBirths));
                    k.Workers += amount;
                    // Add birth log event

                    amount = Helper.GetRandom(Convert.ToInt32(MaxDeaths), Convert.ToInt32(MinDeaths));
                    k.Workers -= amount;
                    // Add birth log event

                }
            }
        }
        private void ProduceFood(Player[] players)
        {
            foreach (Player p in players)
            {
                foreach (Kingdom k in p.Kingdom)
                {
                    int amount;
                    int spoilage = 50;
                    float min = (float).70;
                    float max = (float)1.05;

                    // Food spoils
                    int spoiled = (int)k.Food * spoilage / 100;
                    k.Food -= spoiled;

                    switch (k.Taxrate)
                    {
                        case Tax.Kindly:
                            min += (float).20;
                            max += (float).20;
                            break;
                        case Tax.Normal:
                            min += (float).10;
                            max += (float).10;
                            break;
                        case Tax.Oppresive:
                            min -= (float).10;
                            max -= (float).10;
                            break;
                        case Tax.Tyrannical:
                            min -= (float).20;
                            max -= (float).20;
                            break;
                        default:
                            break;
                    }
                    if (min < 0) { min = 0; }
                    if (max < 0) { max = 0; }
                    if ((int)k.Land > (int)k.Workers) { amount = Helper.GetRandom((int)((int)k.Workers * max), (int)((int)k.Workers * min)); }
                    else { amount = Helper.GetRandom((int)((int)k.Land * max), (int)((int)k.Land * min)); }

                    if (amount < 1) { amount = 1; }
                    k.Food += amount;

                    // Add log event
                }
            }
        }
        private void ProduceIncome(Player[] players)
        {
            foreach (Player p in players)
            {
                foreach (Kingdom k in p.Kingdom)
                {
                    int income;
                    int SupportedStructures = 0;
                    if ((int)k.Workers / 50 > (int)k.Structures) { SupportedStructures = (int)k.Structures; }
                    if (SupportedStructures < 1 || (int)k.Taxrate == 0) { return; }
                    income = SupportedStructures * (500 * (int)(int)k.Taxrate);
                    k.Currency += income;
                }
            }
        }
        private void IncreaseMovement(Player[] players)
        {
            foreach (Player p in players)
            {
                var maxLevel =
                    (from kingdom in p.Kingdom
                     select kingdom.Level)
                     .Max();
                p.Movement += ((int)maxLevel + 1) * 10;
            }
        }
        private void Events(Player[] player)
        {
            foreach (Player p in players)
            {
                foreach (Kingdom k in p.Kingdom)
                {
                    HKEvents CurrentEvent = HKEvents.None;
                    if ((int)k.Workers > HKSettings.MaxWorkers) { CurrentEvent = HKEvents.Uprising; }
                    if ((int)k.Currency > HKSettings.MaxCurrency) { CurrentEvent = HKEvents.Thieves; }
                    if (Helper.GetRandom(100, 1) >= ((int)k.Level + 1) * 5) { return; }
                    if (Helper.GetRandom(100, 1) + ((int)k.Honor / 2) >= 50)
                    {
                        CurrentEvent = (HKEvents)Helper.GetRandom((int)HKEvents.FindCastle, (int)HKEvents.Merchant);
                    }
                    else
                    {
                        CurrentEvent = (HKEvents)Helper.GetRandom((int)HKEvents.Uprising, (int)HKEvents.Thieves);
                    }
                    int amount;
                    switch (CurrentEvent)
                    {
                        case HKEvents.Merchant:
                            amount = Helper.GetRandom(50000, 10000);
                            k.Currency += amount;
                            // Add event to log
                            return;
                        case HKEvents.Soldiers:
                            // Add 100-500 Soldiers to player army
                            // Add event to log
                            return;
                        case HKEvents.RecoverFood:
                            amount = Helper.GetRandom(1000, 100);
                            k.Food += amount;
                            // Add event to log
                            return;
                        case HKEvents.Workers:
                            amount = Helper.GetRandom(500, 100);
                            k.Workers += amount;
                            // Add event to log
                            return;
                        case HKEvents.Explorers:
                            amount = Helper.GetRandom(500, 100);
                            k.Land += amount;
                            // Add event to log
                            return;
                        case HKEvents.FindCastle:
                            amount = Helper.GetRandom(4, 1);
                            k.Structures += Helper.GetRandom(4, 1);
                            // Add event to log
                            return;
                        case HKEvents.Thieves:
                            amount = Helper.GetRandom(4000, 1);
                            k.Currency -= amount;
                            // Add event to log
                            return;
                        case HKEvents.Plague:
                            amount = (int)k.Workers * 5 / 100;
                            k.Workers -= amount;
                            // Add event to log
                            return;
                        case HKEvents.Uprising:
                            amount = (int)k.Workers * Helper.GetRandom(30, 10) / 100;
                            k.Workers -= amount;
                            // Add event to log
                            return;

                    }

                }
            }
        }
    }
}