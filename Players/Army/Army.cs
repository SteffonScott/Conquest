using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conquest;
using Conquest.Worlds.Players;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Data.Entity;


namespace Conquest
{
    [DataContract]
    public class ArmyInfo
    {
        [DataMember]
        public Nullable<int> cEnlisted { get; set; }
        [DataMember]
        public Nullable<int> cSupport { get; set; }
        [DataMember]
        public Nullable<int> cRanged { get; set; }
        [DataMember]
        public Nullable<int> cSpecial { get; set; }
        [DataMember]
        public Nullable<int> cSiege { get; set; }
        [DataMember]
        public Nullable<int> cElite { get; set; }
        [DataMember]
        public Nullable<int> dEnlisted { get; set; }
        [DataMember]
        public Nullable<int> dSupport { get; set; }
        [DataMember]
        public Nullable<int> dRanged { get; set; }
        [DataMember]
        public Nullable<int> dSpecial { get; set; }
        [DataMember]
        public Nullable<int> dSiege { get; set; }
        [DataMember]
        public Nullable<int> dElite { get; set; }
        [DataMember]
        public Nullable<double> Surrender { get; set; }
        [DataMember]
        public Nullable<int> ArmyClass { get; set; }

        public ArmyInfo(Army army)
        {
            this.ArmyClass = army.ArmyClass;
            this.cElite = army.cElite;
            this.cEnlisted = (int)army.cEnlisted;
            this.cRanged = (int)army.cRanged;
            this.cSiege = (int)army.cSiege;
            this.cSpecial = (int)army.cSpecial;
            this.cSupport = (int)army.cSupport;
            this.dElite = (int)army.dElite;
            this.dEnlisted = (int)army.dEnlisted;
            this.dRanged = (int)army.dRanged;
            this.dSiege = (int)army.dSiege;
            this.dSpecial = (int)army.dSpecial;
            this.dSupport = (int)army.dSupport;
            this.Surrender = army.Surrender;
        }
    }
    [DataContract]
    public class ReviewResult : CommandResult
    {
        [DataMember]
        public ArmyInfo army { get; set; }
    }
    public partial class Army : DbContext
    {
        public Army() { }
        public Army(int cont)
        {
            this.dElite = 0;
            this.dSupport = 100;
            this.dEnlisted = 0;
            this.dRanged = 0;
            this.dSpecial = 0;
            this.dSiege = 1;
            this.cElite = 0;
            this.cSupport = 0;
            this.cEnlisted = 0;
            this.cRanged = 0;
            this.cSpecial = 0;
            this.cSiege = 0;
            this.Surrender = .50;
        }
        public int MaxTroops
        {
            get
            {
                if (this.Kingdom.Player.PlayerClass == PlayerClass.Fighter || this.Kingdom.Player.PlayerClass == PlayerClass.Ranger) { return (int)this.Kingdom.Structures * 100; }
                if (this.Kingdom.Player.PlayerClass == PlayerClass.Barbarian) { return (int)this.Kingdom.Structures * 150; }
                if (this.Kingdom.Player.PlayerClass == PlayerClass.Mage || this.Kingdom.Player.PlayerClass == PlayerClass.Cleric) { return (int)this.Kingdom.Structures * 75; }
                if (this.Kingdom.Player.PlayerClass == PlayerClass.Vampire) { return (int)this.Kingdom.Structures * 125; }
                return 0;
            }
            private set { }
        }
        public int TotalArmy
        {
            get
            {
                return (int)(this.dElite + this.dSupport + this.dEnlisted + this.dRanged + this.dSpecial + this.cElite + this.cSupport + this.cEnlisted + this.cRanged + this.cSpecial);
            }
            private set { }
        }
        public bool SetSurrender(float surrender)
        {
            if (surrender > 1 || surrender < 0) { return false; }
            else
            {
                this.Surrender = surrender;
                return true;
            }
        }
        public ReviewResult Review()
        {
            ReviewResult reviewresult = new ReviewResult();
            if (this.Kingdom.Player.Movement < 1) {
                reviewresult.result = ResultType.NoMovement;
                reviewresult.success = false;
                return reviewresult;
            }
            this.Kingdom.Player.Movement -= 1;
            this.Kingdom.SaveChanges();
            reviewresult.success = true;
            reviewresult.army = new ArmyInfo(this);
            reviewresult.result = ResultType.Success;
            return reviewresult;
        }
        public CommandResult EnlistWorkers(int amount)
        {
            CommandResult result = new CommandResult();
            if (amount < 1) 
            {
                result.result = ResultType.InvalidAmount;
                return result;
            }
            if (this.Kingdom.Workers < amount) 
            {
                result.result = ResultType.InvalidAmount;
                return result;
            }
            if (this.TotalArmy + amount > this.Kingdom.MaxCastle)
            {
                result.result = ResultType.InvalidAmount;
                return result;
            }

            this.Kingdom.Workers -= amount;
            this.dEnlisted += amount;
            result.success = true;
            return result;
            
        }
    }
}
