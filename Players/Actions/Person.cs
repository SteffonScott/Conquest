using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service.Actions;

namespace Conquest.Players.Actions
{
    public class Person : PlayerAction
    {
        public Person()
        {
            this.Name = "Person";
            this.Movement = 0;
            this.reqParams = false;
        }
    }
    public class PersonLogic : ActionLogic
    {
        public PlayerActionResult Execute()
        {
            if (!CheckMP())
            {
                return new PlayerActionResult(false, ResultType.NoMovement);
            }
            KingdomInfo kingdom = new KingdomInfo(Action.player);
            return new PlayerActionResult(true, ResultType.Success, kingdom1: kingdom);
        }
    }
}