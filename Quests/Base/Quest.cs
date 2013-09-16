using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Conquest.Quests
{
    public partial class Quest
    {
        private Player player { get; set; }
        private QuestResult result { get; set; }
        private QuestType type { get; set; }

        public Quest(Player player, QuestType type) 
        {
            
            this.type = type;
            Execute();
        }

        internal QuestResult Execute()
        {
            switch (type)
            {
                case QuestType.QuestItem:
                    return QuestItem(player);
                case QuestType.QuestHorde:
                    return QuestHorde(player);
                case QuestType.QuestComponent:
                    return QuestComponent(player);
                case QuestType.QuestJoust:
                    return QuestJoust(player);
            }
            return new QuestResult();
        }
    }
}