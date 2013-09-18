using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conquest.Worlds;
using Conquest.Worlds.Players.Armies;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data.Entity;
using Conquest.Players.Items;
using Conquest.Players.Items.Base;
using Conquest.Service.Actions;

namespace Conquest
{
    #region Helpers
    public enum PlayerClass
    {
        Fighter=1,
        Mage,
        Barbarian,
        Vampire,
        Ranger,
        Cleric
    }
    public enum fighterRanks
    {
        Immortal,
        Knight,
        Paladin,
        Champion,
        Baron,
        Viscount,
        Earl,
        Marquis,
        Duke,
        King
    }
    public enum barbarianRanks
    {
        Immortal,
        Grunt,
        Savage,
        Berserker,
        Warrior,
        Mercenary,
        IronMark,
        Battlemaster,
        Warlord,
        Deathlord
    }
    public enum mageRanks
    {
        Novice,
        Trickster,
        Conjurer,
        Magician,
        Enchanter,
        Spellbinder,
        Warlock,
        Sorcerer,
        Wizard,
        ArchMage
    }
    public enum vampireRanks
    {
        Childe,
        Fledgeling,
        Neophyte,
        Stalker,
        Master,
        Tempter,
        Nemesis,
        Elder,
        Prince,
        DarkLord
    }
    public enum rangerRanks
    {
        Scout,
        Hunter,
        Protector,
        Tracker,
        Ranger,
        Lord,
        Huntmaster,
        ForestGod
    }
    public enum clericRanks
    {
        Initiate,
        Disciple,
        Acolyte,
        Adept,
        Priest,
        Vicar,
        Bishop,
        Patriarch,
        ArchBishop
    }
    public enum Gender : int
    {
        Male=1,
        Female=2
    }
    #endregion

    [DataContract]
    public class KingdomInfo
    {
        [DataMember]
        public int PlayerId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Movement { get; set; }
        [DataMember]
        public int Workers { get; set; }
        [DataMember]
        public int Level { get; set; }
        [DataMember]
        public int Food { get; set; }
        [DataMember]
        public int Currency { get; set; }
        [DataMember]
        public int Structures { get; set; }
        [DataMember]
        public int Protection { get; set; }
        [DataMember]
        public int Land { get; set; }
        [DataMember]
        public int ItemAmount { get; set; }
        [DataMember]
        public int Honor { get; set; }

        public KingdomInfo(Player player)
        {
            this.PlayerId = player.PlayerId;
            this.Name = player.Name;
            this.Movement = (int)player.Movement;
            this.Workers = (int)player.CurrentKingdom.Workers;
            this.Level = (int)player.CurrentKingdom.Level;
            this.Food = (int)player.CurrentKingdom.Food;
            this.Currency = (int)player.CurrentKingdom.Currency;
            this.Structures = (int)player.CurrentKingdom.Structures;
            this.Protection = (int)player.CurrentKingdom.Protection;
            this.Land = (int)player.CurrentKingdom.Land;
            this.ItemAmount = (int)player.CurrentKingdom.Vault.Items.Count();
            this.Honor = (int)player.CurrentKingdom.Honor;
        }
    }
    public partial class Player : DbContext
    {
        public Player(int uid, string name)
        {
            this.Name = name;
            this.UserId = uid;
            this.Remorts = 0;
            this.Gender = Gender.Male;
            this.NumAttacks = 3;
            this.Movement = 30;
            this.PlayerClass = PlayerClass.Fighter;
            this.CurrentCont = Helper.GetRandom(3, 1);
            this.Kingdom = new HashSet<Kingdom>();
            this.Kingdom.Add(new Kingdom(this.CurrentCont));
            this.CurrentKingdom.Vault.AddItem(new Item(ItemType.LureVulture));
            this.CurrentKingdom.Vault.AddItem(new Item(ItemType.PotSpeed));
        }

        public Kingdom CurrentKingdom
        {
            get
            {
                return this.Kingdom.First(k => k.Continent == this.CurrentCont);
            }
            private set { }
        }

        public CommandResult Use(ItemType itype)
        {
            if (!CurrentKingdom.Vault.ContainsItem(itype))
            {
                return new UseResult(false, ResultType.NotFound);
            }

            Item item = CurrentKingdom.Vault.Items.First(i => i.Type == itype);

            if (!item.CheckMovement())
            {
                return new CommandResult(false, ResultType.NoMovement);
            }

            UseResult result = item.Use(this);
            return result;
        }
        public PlayerActionResult DoAction(PlayerAction action)
        {
            action.player = this;
            PlayerActionResult result = action.Execute();
            return result;
        }


    }
}
