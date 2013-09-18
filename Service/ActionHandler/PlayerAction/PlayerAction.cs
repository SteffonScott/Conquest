using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Conquest.Players.Actions;
using Conquest.Service.Actions;

namespace Conquest.Service.Actions
{
    public abstract class PlayerAction
    {
        public string Name { get; set; }
        public int Movement { get; set; }
        public PlayerActionType type { get; set; }
        public Player player { get; set; }
        public Player playerparam { get; set; }
        public int amount { get; set; }
        private string svalue { get; set; }
        public dynamic Logic { get; set; }
        public bool reqParams { get; set; }

        public PlayerAction() { }
        public PlayerAction(PlayerActionType type, int amount = 0, string svalue = null)
        {
            this.type = type;
            this.amount = amount;
            this.svalue = svalue;
            Logic.Action = this;
        }
        public PlayerActionResult Execute()
        {
            return Logic.Execute();
        }
    }
}