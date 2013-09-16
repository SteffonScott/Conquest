using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Conquest.Players.Items;
using Conquest.Combat;

namespace Conquest.Quests
{
    public class QuestResult : CommandResult
    {
        int? amountwon { get; set; }
        BattleResult battleresult { get; set; }
        ItemType itemfound { get; set; }
    }
}
