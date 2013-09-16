using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Service.Actions;

namespace Conquest.Service.Actions
{
    public abstract class ActionLogic
    {
        public PlayerAction Action { get; set; }

        internal bool CheckMP()
        {
            if (Action.player.Movement < Action.Movement) { return false; }
            Action.player.Movement -= Action.Movement;
            return true;
        }
    }
}