using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Conquest
{
    public enum Tax
    {
        Generous = 1,
        Kindly = 2,
        Normal = 3,
        Oppresive = 4,
        Tyrannical = 5
    }
    public partial class Kingdom : DbContext
    {
        public Kingdom() { }
        public Kingdom(int cont)
        {
            this.Honor = 0;
            this.Land = 100;
            this.Workers = 100;
            this.Currency = 10000;
            this.Structures = 1;
            this.Level = 1;
            this.Food = 100;
            this.Protection = 1;
            this.KingdomName = "My Kingdom";
            this.Taxrate = Tax.Kindly;
            this.Continent = cont;
            this.Army = new Army(cont);
            this.Vault = new Vault();
        }
        public int MaxCastle
        {
            get
            {
                return (int)Player.CurrentKingdom.Land / 50;
            }
            private set { }
        }
    }
}