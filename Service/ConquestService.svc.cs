using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Conquest.Worlds;
using Conquest.Worlds.Players;
using Conquest.Quests;
using Conquest.Combat;
using Conquest.Players.Items;
using Conquest.Service;
using Conquest.Service.Actions;

namespace Conquest
{
    [DataContract]
    public enum ResultType
    {
        [EnumMember]
        Success = 0,
        [EnumMember]
        NoMovement = 1,
        [EnumMember]
        WrongClass = 2,
        [EnumMember]
        InsufLevel = 3,
        [EnumMember]
        InvalidAmount = 4,
        [EnumMember]
        IsProtected = 5,
        [EnumMember]
        NotFound = 6,
        [EnumMember]
        InvalidClass = 7,
        [EnumMember]
        InsufficientFunds = 8,
        [EnumMember]
        Won = 9,
        [EnumMember]
        Lost = 10

    }
    [DataContract]
    [KnownType(typeof(ReviewResult))]
    [KnownType(typeof(BattleResult))]
    [KnownType(typeof(UseResult))]
    public class CommandResult
    {
        public CommandResult() { }
        public CommandResult(bool succ)
        {
            success = succ;
        }
        public CommandResult(bool succ, ResultType result)
        {
            this.success = succ;
            this.result = result;
        }
        [DataMember]
        public bool? success { get; set; }
        [DataMember]
        public ResultType result { get; set; }
        [DataMember]
        public int? amount { get; set; }
    }

    public class ConquestService : IConquestService
    {
        public Settings.Settings Settings { get; set; }
        World world = new World();
        GameDataEntities entities = new GameDataEntities();
        #region PLAYER MANIPULATION
        public bool AddPlayer(int uid, string name)
        {
                return new PlayersRepositoryManager(entities).AddPlayer(new Player(uid: uid, name: name));
        }
        public void RemoveAllPlayers()
        {
            new PlayersRepositoryManager(entities).DeleteAllPlayers();
        }
        public void RemovePlayer(int pid)
        {
            // Add persistence here
            //
            Player existingPlayer = new PlayersRepositoryManager(entities).GetPlayerById(pid);
            new PlayersRepositoryManager(entities).DeletePlayer(existingPlayer);
        }
        public bool PlayerExists(int uid)
        {
            return new PlayersRepositoryManager(entities).FindPlayer(uid);
        }
        public bool PlayerExists(string name)
        {
            return new PlayersRepositoryManager(entities).FindPlayer(name);
        }
        private Player GetPlayer(string name)
        {
            return new PlayersRepositoryManager(entities).GetPlayerByName(name);
        }
        private Player GetPlayer(int uid)
        {
            return new PlayersRepositoryManager(entities).GetPlayerById(uid);
        }
        public KingdomInfo GetPlayerStats(string name)
        {
            // Retrieve player where PlayerID=pid
            //
            Player player = GetPlayer(name);
            // Populate stats with statistics from player object
            //
            return new KingdomInfo(GetPlayer(name));
        }
        public KingdomInfo GetPlayerStats(int uid)
        {
            // Retrieve player where PlayerID=pid
            //
            Player player = GetPlayer(uid);
            // Populate stats with statistics from player object
            //
            return new KingdomInfo(GetPlayer(uid));
        }
        #endregion

        #region BASIC KINGDOM 
        public List<String> ListItems(int uid)
        {
            Player player = GetPlayer(uid);
            List<string> itemlist = new List<string>();
            foreach (Item item in player.CurrentKingdom.Vault.Items)
            {
                itemlist.Add(item.Name);
            }
            return itemlist;
        }
        public CommandResult UseItem(int uid, int inum)
        {
            Player player = GetPlayer(uid);
            return new CommandResult();
        }
        public ReviewResult ArmyReview(int uid)
        {
            Player player = GetPlayer(uid);
            ReviewResult result = player.CurrentKingdom.Army.Review();
            entities.SaveChanges();
            return result;

        }
        public QuestResult Quest(int uid, QuestType type)
        {
            Player player = GetPlayer(uid);
            QuestResult result = new Quest(player, type).Execute();
            entities.SaveChanges();
            return result;
        }
        #endregion

        #region PLAYER MANAGEMENT ACTIONS
        public PlayerActionResult DoAction(PlayerActionType type, int uid, string pparam = null, int amount = 0, string svalue = null) 
        {
            Player player;
            PlayerActionResult result;
            PlayerAction action = (PlayerAction)Activator.CreateInstance(null, string.Concat("Conquest.Players.Actions.", type.ToString())).Unwrap();
            action.Logic = (ActionLogic)Activator.CreateInstance(null, string.Concat("Conquest.Players.Actions.", type.ToString(), "Logic")).Unwrap();
            action.Logic.Action = action;
            action.amount = amount;
            // Verify executor exists
            if (!PlayerExists(uid))
            {
                return new PlayerActionResult(false, ResultType.NotFound);
            }
            else { player = GetPlayer(uid); }

            if (pparam != null & !PlayerExists(pparam))
            {
                if (!PlayerExists(pparam))
                {
                    return new PlayerActionResult(false, ResultType.NotFound);
                }
                action.playerparam = GetPlayer(pparam);
            }

                result = player.DoAction(action);
                entities.Entry(player).State = System.Data.EntityState.Modified;
                entities.SaveChanges();


            return result;
        }


        public void SetKingdomName(int uid, string kingdomname)
        {
            if (kingdomname.Length > 16) { return; }
            GetPlayer(uid).CurrentKingdom.KingdomName = kingdomname;
        }
        #endregion


    }
}
