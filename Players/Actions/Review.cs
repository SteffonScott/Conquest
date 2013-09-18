using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service.Actions;

namespace Conquest.Players.Actions
{
    public class Review : PlayerAction
    {
        public Review()
        {
            this.Name = "Review";
            this.Movement = 1;
            this.reqParams = false;
        }
    }

    public class ReviewLogic : ActionLogic
    {
        public PlayerActionResult Execute()
        {
            if (!CheckMP())
            {
                return new PlayerActionResult(false, ResultType.NoMovement);
            }

            Kingdom kingdom = Action.player.CurrentKingdom;
            ArmyInfo armyinfo = new ArmyInfo(Action.player.CurrentKingdom.Army);
            PlayerActionResult result = new PlayerActionResult(true, ResultType.Success, army1: armyinfo);
            return result;
        }
    }
}