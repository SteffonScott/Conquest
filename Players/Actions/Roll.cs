using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service.Actions;
using Conquest.Worlds;

namespace Conquest.Players.Actions
{
    public class Roll : PlayerAction
    {
        public Roll()
        {
            this.Name = "Roll";
            this.Movement = 1;
            this.reqParams = true;
        }
    }
    public class RollLogic : ActionLogic
    {
        public PlayerActionResult Execute()
        {
            if (!CheckMP())
            {
                return new PlayerActionResult(false, ResultType.NoMovement);
            }
            if (Action.player.PlayerClass == PlayerClass.Cleric)
            {
                return new PlayerActionResult(false, ResultType.InvalidClass);
            }


            if (Action.amount < 1)
            {
                return new PlayerActionResult(false, ResultType.InvalidAmount);
            }
            if (Action.player.CurrentKingdom.Currency < Action.amount)
            {
                return new PlayerActionResult(false, ResultType.InsufficientFunds);
            }

            int chance = 1;
            int House;
            int PRoll;

            Action.player.CurrentKingdom.Currency -= Action.amount;

            House = Helper.GetRandom(6, 1) + Helper.GetRandom(6, 1);
            PRoll = Helper.GetRandom(6, 1) + Helper.GetRandom(6, 1);

            if (Helper.GetRandom(100, 1) <= chance)
            {
                PRoll = House;
            }

            if (PRoll == House)
            {
                switch (PRoll)
                {
                    case 7:
                        Action.amount *= 6;
                        break;
                    case 6:
                    case 8:
                        Action.amount *= 7;
                        break;
                    case 5:
                    case 9:
                        Action.amount *= 9;
                        break;
                    case 4:
                    case 10:
                        Action.amount *= 12;
                        break;
                    case 3:
                    case 11:
                        Action.amount *= 18;
                        break;
                    case 2:
                    case 12:
                        Action.amount *= 36;
                        break;
                }
                Action.player.CurrentKingdom.Currency += Action.amount;
            return new PlayerActionResult(true, ResultType.Won, amount: Action.amount);
            }
            else { return new PlayerActionResult(true, ResultType.Lost, amount: Action.amount); }
        }

    }
}