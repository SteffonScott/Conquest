using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Conquest.Worlds.Players;
using Conquest.Service.Actions;
using Conquest.Service;

namespace Conquest
{
    [ServiceContract]
    public interface IConquestService
    {
        #region PLAYER MANIPULATION
        [OperationContract]
        bool AddPlayer(int pid, string name);
        [OperationContract(Name="PlayerExistsWithName")]
        bool PlayerExists(string name);
        [OperationContract(Name="PlayerExistsWithUID")]
        bool PlayerExists(int uid);
        [OperationContract]
        void RemovePlayer(int pid);
        [OperationContract(Name="GetStatsByName")]
        KingdomInfo GetPlayerStats(string name);
        [OperationContract(Name = "GetStatsByUID")]
        KingdomInfo GetPlayerStats(int uid);
        [OperationContract]
        void RemoveAllPlayers();
        #endregion

        #region BASIC KINGDOM ACTIONS
        [OperationContract]
        ReviewResult ArmyReview(int uid);
        [OperationContract]
        CommandResult UseItem(int uid, int inum);
        [OperationContract]
        List<string> ListItems(int uid);
        #endregion

        #region BASIC PLAYER COMMANDS
        [OperationContract]
        PlayerActionResult DoAction(PlayerActionType type, int uid, string pparam = null, int amount = 0, string svalue = null);
        [OperationContract]
        void SetKingdomName(int uid, string kingdomname);
        #endregion

    }
}
