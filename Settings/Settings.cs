using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Conquest;
using Conquest.Worlds.Players.Armies.Units;

namespace Conquest.Settings
{
    public class Settings
    {
        public Unit[,] UnitValues { get; set; }

        public void Load(bool init) 
        {
            LoadUnits(init);
        }
        private void LoadUnits(bool init)
        {
            this.UnitValues = new Unit[Enum.GetNames(typeof(PlayerClass)).Length, Enum.GetNames(typeof(UnitType)).Length];
            
        }
    }

}