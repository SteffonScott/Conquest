using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service;
using System.Runtime.Serialization;

namespace Conquest.Service.Actions
{
    [DataContract]
    public class PlayerActionResult : GameActionResult
    {
        [DataMember]
        public KingdomInfo kingdom1 { get; set; }
        [DataMember]
        public ArmyInfo army1 { get; set; }
        [DataMember]
        public ArmyInfo army2 { get; set; }
        [DataMember]
        public int amount { get; set; }


        public PlayerActionResult(bool succ = true, ResultType result = ResultType.NotFound, ArmyInfo army1 = null, ArmyInfo army2 = null, int amount = 0, KingdomInfo kingdom1 = null)
        {
            this.succ = succ;
            this.resulttype = result;
            this.army1 = army1;
            this.army2 = army2;
            this.kingdom1 = kingdom1;
            this.amount = amount;
        }
    }
}