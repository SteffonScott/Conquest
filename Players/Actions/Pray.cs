using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service;
using Conquest.Worlds;
using Conquest.Service.Actions;

namespace Conquest.Players.Actions
{

    public class Pray : PlayerAction
    {
        public Pray() 
        {
            this.Name = "Pray";
            this.Movement = 2;
            this.reqParams = false;
        }
    }
    public class PrayLogic : ActionLogic
    {
        public PlayerActionResult Execute()
        {
            if (!CheckMP())
            {
                return new PlayerActionResult(false, ResultType.NoMovement);
            }

            Kingdom kingdom = Action.player.CurrentKingdom;

            if (Helper.GetRandom(100, 1) <= 25 + (kingdom.Honor + 1))
                kingdom.Honor += Helper.GetRandom(3, 1);
            return new PlayerActionResult(true, ResultType.Success);
        }
    }
}