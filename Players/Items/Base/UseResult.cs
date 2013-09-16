using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Conquest.Players.Items
{
    [DataContract]
    public class UseResult : CommandResult
    {
        [DataMember]
        public Combat.BattleResult battleresult { get; set; }
        public UseResult(bool succ, ResultType type, int? amount = null, Combat.BattleResult battleresult = null)
        {
            this.success = succ;
            this.result = type;
            this.battleresult = battleresult;
            this.amount = amount;
        }
    }
}