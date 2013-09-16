using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conquest.Worlds.Players;

namespace Conquest.Worlds.Players.Armies.Units
{
    #region Helpers

    public enum UnitType : int
    {
        Enlist,
        Support,
        Special,
        Ranged,
        Siege,
        Elite
    }

    public enum DamageMode
    {
        Walk = 0,
        Ride,
        Fly,
        Range
    }
    #endregion
    // Base unit class
    public abstract class Unit
    {
        public string name { get; set; }
        public int attack { get; set; }
        public int defend { get; set; }
        public int food { get; set; }
        public int copper { get; set; }
        public int range { get; set; }
        public int numattacks { get; set; }
        public int swarm { get; set; }
        public int train { get; set; }
        public int ambush { get; set; }
        public DamageMode mode { get; set; }
        public int regen { get; set; }
        public int shield { get; set; }
        public UnitType type { get; set; }
        public bool firstStrike { get; set; }
        public bool canAttack { get; set; }
        public PlayerClass unitclass { get; set; }

        public string dname;
        public int dattack;
        public int ddefend;
        public int dfood;
        public int dcopper;
        public int drange;
        public int dnumattacks;
        public int dswarm;
        public int dtrain;
        public int dambush;
        public DamageMode dmode;
        public int dregen;
        public int dshield;
        public bool dfirstStrike;
        public bool dcanAttack;
        public int dtype;

        public void changeClass(PlayerClass newclass)
        {

        }

        public void resetDefault()
        {
            name = dname;
            attack = dattack;
            defend = ddefend;
            food = dfood;
            range = drange;
            numattacks = dnumattacks;
            swarm = dswarm;
            train = dtrain;
            ambush = dambush;
            copper = dcopper;
            regen = dregen;
            mode = dmode;
            shield = dshield;
            canAttack = true;
        }

    }

    // Units
    public class Ranged : Unit
    {
        public Ranged(PlayerClass playerClass)
        {
            if (playerClass == PlayerClass.Fighter)
            {
                name = "Archer";
                ambush = 0;
                attack = 6;
                copper = 0;
                defend = 1;
                range = 1;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = true;
                type = UnitType.Ranged;
            }
            if (playerClass == PlayerClass.Barbarian)
            {
                name = "Mounted Archer";
                ambush = 0;
                attack = 4;
                copper = 0;
                defend = 2;
                range = 1;
                food = 1;
                mode = DamageMode.Range;
                numattacks = 2;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = true;
                type = UnitType.Ranged;
            }
            if (playerClass == PlayerClass.Mage)
            {
                name = "Pyromancer";
                ambush = 0;
                attack = 6;
                copper = 0;
                defend = 4;
                range = 1;
                food = 1;
                mode = DamageMode.Range;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = true;
                type = UnitType.Ranged;
            }
            if (playerClass == PlayerClass.Vampire)
            {
                name = "Ghoul";
                ambush = 0;
                attack = 4;
                copper = 0;
                defend = 2;
                range = 0;
                food = 0;
                mode = DamageMode.Range;
                numattacks = 2;
                regen = 1;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = true;
                type = UnitType.Ranged;
            }
            if (playerClass == PlayerClass.Ranger)
            {
                name = "Master Archer";
                ambush = 0;
                attack = 8;
                copper = 0;
                defend = 8;
                range = 1;
                food = 1;
                mode = DamageMode.Range;
                numattacks = 2;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = true;
                type = UnitType.Ranged;
            }
        }
    }

    public class Support : Unit
    {
        public Support(PlayerClass playerClass)
        {
            if (playerClass == PlayerClass.Fighter)
            {
                name = "Soldier";
                ambush = 0;
                attack = 4;
                copper = 0;
                defend = 4;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Support;
                unitclass = PlayerClass.Fighter;
            }
            if (playerClass == PlayerClass.Barbarian)
            {
                name = "Grunt";
                ambush = 1;
                attack = 6;
                copper = 0;
                defend = 1;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Support;
                unitclass = PlayerClass.Barbarian;
            }
            if (playerClass == PlayerClass.Mage)
            {
                name = "Battle Mage";
                ambush = 0;
                attack = 4;
                copper = 0;
                defend = 2;
                range = 1;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Support;
                unitclass = PlayerClass.Mage;
            }
            if (playerClass == PlayerClass.Vampire)
            {
                name = "Skeleton";
                ambush = 0;
                attack = 4;
                copper = 0;
                defend = 2;
                range = 0;
                food = 0;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Support;
                unitclass = PlayerClass.Vampire;
            }
            if (playerClass == PlayerClass.Cleric)
            {
                name = "Crusader";
                ambush = 0;
                attack = 3;
                copper = 0;
                defend = 5;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Support;
                unitclass = PlayerClass.Cleric;
            }
            if (playerClass == PlayerClass.Ranger)
            {
                name = "Centaur";
                ambush = 1;
                attack = 4;
                copper = 0;
                defend = 3;
                range = 0;
                food = 1;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Support;
                unitclass = PlayerClass.Ranger;
            }
        }
    }

    public class Special : Unit
    {
        public Special(PlayerClass playerClass)
        {
            if (playerClass == PlayerClass.Fighter)
            {
                name = "Knight";
                ambush = 0;
                attack = 8;
                copper = 0;
                defend = 8;
                range = 0;
                food = 1;
                mode = DamageMode.Ride;
                numattacks = 2;
                regen = 0;
                shield = 1;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Special;
                unitclass = PlayerClass.Fighter;
            }
            if (playerClass == PlayerClass.Barbarian)
            {
                name = "Warrior";
                ambush = 0;
                attack = 8;
                copper = 0;
                defend = 4;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 1;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Special;
                unitclass = PlayerClass.Barbarian;
            }
            if (playerClass == PlayerClass.Mage)
            {
                name = "Necromancer";
                ambush = 0;
                attack = 7;
                copper = 0;
                defend = 7;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Special;
                unitclass = PlayerClass.Mage;
            }
            if (playerClass == PlayerClass.Vampire)
            {
                name = "Wraith";
                ambush = 0;
                attack = 8;
                copper = 0;
                defend = 8;
                range = 0;
                food = 0;
                mode = DamageMode.Fly;
                numattacks = 1;
                regen = 1;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Special;
                unitclass = PlayerClass.Vampire;
            }
            if (playerClass == PlayerClass.Cleric)
            {
                name = "Monk";
                ambush = 0;
                attack = 7;
                copper = 0;
                defend = 3;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Special;
                unitclass = PlayerClass.Cleric;
            }
            if (playerClass == PlayerClass.Ranger)
            {
                name = "Treant";
                ambush = 0;
                attack = 2;
                copper = 0;
                defend = 12;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Special;
                unitclass = PlayerClass.Ranger;
            }
        }
    }

    public class Elite : Unit
    {
        public Elite(PlayerClass playerClass)
        {
            if (playerClass == PlayerClass.Fighter)
            {
                name = "Bloodguard";
                ambush = 0;
                attack = 12;
                copper = 0;
                defend = 12;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 1;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Elite;
                unitclass = PlayerClass.Fighter;
            }
            if (playerClass == PlayerClass.Barbarian)
            {
                name = "Chieftain";
                ambush = 0;
                attack = 10;
                copper = 0;
                defend = 6;
                range = 0;
                food = 1;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 1;
                train = 0;
                firstStrike = false;
                type = UnitType.Elite;
                unitclass = PlayerClass.Barbarian;
            }
            if (playerClass == PlayerClass.Mage)
            {
                name = "Golem";
                ambush = 0;
                attack = 10;
                copper = 0;
                defend = 14;
                range = 0;
                food = 0;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 1;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Elite;
                unitclass = PlayerClass.Mage;
            }
            if (playerClass == PlayerClass.Vampire)
            {
                name = "Skeletal Knight";
                ambush = 0;
                attack = 12;
                copper = 0;
                defend = 6;
                range = 0;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 1;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Elite;
                unitclass = PlayerClass.Vampire;
            }
            if (playerClass == PlayerClass.Cleric)
            {
                name = "Zealot";
                ambush = 0;
                attack = 10;
                copper = 0;
                defend = 10;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 2;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Elite;
                unitclass = PlayerClass.Cleric;
            }
            if (playerClass == PlayerClass.Ranger)
            {
                name = "Guardian";
                ambush = 0;
                attack = 6;
                copper = 0;
                defend = 12;
                range = 0;
                food = 1;
                mode = DamageMode.Fly;
                numattacks = 2;
                regen = 1;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Elite;
                unitclass = PlayerClass.Ranger;
            }
        }
    }

    public class Siege : Unit
    {
        public Siege(PlayerClass playerClass)
        {
            if (playerClass == PlayerClass.Fighter)
            {
                name = "Catapult";
                ambush = 0;
                attack = 30;
                copper = 0;
                defend = 0;
                range = 1;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Siege;
                unitclass = PlayerClass.Fighter;
            }
            if (playerClass == PlayerClass.Barbarian)
            {
                name = "Ballista";
                ambush = 0;
                attack = 20;
                copper = 0;
                defend = 0;
                range = 1;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Siege;
                unitclass = PlayerClass.Barbarian;
            }
            if (playerClass == PlayerClass.Mage)
            {
                name = "Stormthrower";
                ambush = 0;
                attack = 45;
                copper = 0;
                defend = 0;
                range = 1;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Siege;
                unitclass = PlayerClass.Mage;
            }
            if (playerClass == PlayerClass.Vampire)
            {
                name = "Scorpion";
                ambush = 0;
                attack = 25;
                copper = 0;
                defend = 0;
                range = 1;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Siege;
                unitclass = PlayerClass.Vampire;
            }
            if (playerClass == PlayerClass.Cleric)
            {
                name = "Trebuchet";
                ambush = 0;
                attack = 50;
                copper = 0;
                defend = 0;
                range = 1;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Siege;
                unitclass = PlayerClass.Cleric;
            }
            if (playerClass == PlayerClass.Ranger)
            {
                name = "Battering Ram";
                ambush = 0;
                attack = 10;
                copper = 0;
                defend = 0;
                range = 0;
                food = 0;
                mode = DamageMode.Ride;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Siege;
                unitclass = PlayerClass.Ranger;
            }


        }
    }

    public class Enlist : Unit
    {
        public Enlist(PlayerClass playerClass)
        {
            if (playerClass == PlayerClass.Fighter)
            {
                name = "Renegade";
                ambush = 0;
                attack = 1;
                copper = 0;
                defend = 1;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 1;
                firstStrike = false;
                type = UnitType.Enlist;
                unitclass = PlayerClass.Fighter;
            }
            if (playerClass == PlayerClass.Barbarian)
            {
                name = "Peon";
                ambush = 0;
                attack = 2;
                copper = 0;
                defend = 1;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 1;
                firstStrike = false;
                type = UnitType.Enlist;
                unitclass = PlayerClass.Barbarian;
            }
            if (playerClass == PlayerClass.Mage)
            {
                name = "Apprentice";
                ambush = 0;
                attack = 2;
                copper = 0;
                defend = 1;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 1;
                firstStrike = false;
                type = UnitType.Enlist;
                unitclass = PlayerClass.Mage;
            }
            if (playerClass == PlayerClass.Vampire)
            {
                name = "Zombie";
                ambush = 0;
                attack = 1;
                copper = 0;
                defend = 1;
                range = 0;
                food = 0;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 1;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Enlist;
                unitclass = PlayerClass.Vampire;
            }
            if (playerClass == PlayerClass.Cleric)
            {
                name = "Fanatic";
                ambush = 1;
                attack = 1;
                copper = 0;
                defend = 2;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 1;
                firstStrike = false;
                type = UnitType.Enlist;
                unitclass = PlayerClass.Cleric;
            }
            if (playerClass == PlayerClass.Ranger)
            {
                name = "Scout";
                ambush = 1;
                attack = 1;
                copper = 0;
                defend = 1;
                range = 0;
                food = 1;
                mode = DamageMode.Walk;
                numattacks = 1;
                regen = 0;
                shield = 0;
                swarm = 0;
                train = 0;
                firstStrike = false;
                type = UnitType.Enlist;
                unitclass = PlayerClass.Ranger;
            }
        }
    }
}
