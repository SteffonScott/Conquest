using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service.Actions;

namespace Conquest.Players.Actions
{
    public class ToggleGender : PlayerAction
    {
        public ToggleGender()
        {
            this.Name = "ToggleGender";
            this.Movement = 0;
            this.reqParams = false;
        }
    }
    public class ToggleGenderLogic : ActionLogic
    {
        public PlayerActionResult Execute()
        {
            if (Action.player.Gender == Gender.Male) { Action.player.Gender = Gender.Female; }
            else { Action.player.Gender = Gender.Male; }
            return new PlayerActionResult(true, ResultType.Success);
        }
    }
}