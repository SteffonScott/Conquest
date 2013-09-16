using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquest
{
    public class PlayersRepositoryManager : IPlayersRepository
    {
        #region Member Variables
        private GameDataEntities entity = null;
        #endregion

        #region Constructor
        public PlayersRepositoryManager(GameDataEntities entity)
        {
            this.entity = entity;

        }
        #endregion

        #region IPlayerRepository Members
        public Player GetPlayerById(int pid)
        {
            var player = from b in entity.Players
                         where b.UserId == pid
                         select b;
            return player.First();
        }
        public Player GetPlayerByName(string name)
        {
            var player = from p in entity.Players
                         where p.Name == name
                         select p;
            return player.First();
        }
        public bool FindPlayer(string name)
        {
            var player = from p in entity.Players
                         where p.Name == name
                         select p;
            return player.Any();
        }
        public bool FindPlayer(int uid)
        {
            var player = from p in entity.Players
                         where p.UserId == uid
                         select p;
            return player.Any();
        }
        public IEnumerable<Player> GetPlayerList()
        {
            return entity.Players.ToList();
        }
        public bool AddPlayer(Player player)
        {
            int exists = entity.Players.Count(p => p.UserId == player.UserId);
            exists += entity.Players.Count(p => p.Name == player.Name);
            if (exists > 0)
            {
                return false;
            }
            else
            {
                entity.Players.Add(player);
                entity.SaveChanges();
                return true;
            }
        }
        /*   public void UpdatePlayer(Player player)
           {
               Player existingPlayer = GetPlayer(player.PlayerID);
               entity.ApplyPropertyChanges(existingPlayer.
           } */
        public void DeletePlayer(Player player)
        {
            Player existingPlayer = GetPlayerById(player.PlayerId);
            entity.Players.Remove(existingPlayer);
            entity.SaveChanges();
        }
        public void DeleteAllPlayers()
        {
            IEnumerable<Player> Players = GetPlayerList();
            foreach(IEnumerable<Player> currentplayer in Players)
            {
                entity.Players.Remove((Player)currentplayer);
            }
        }
        public Player SavePlayer(Player player)
        {
            var updated = entity.Players.Attach(player);
            entity.Entry(player).State = System.Data.EntityState.Modified;
            return updated;
        }
        public int CountPlayers()
        {
            return GetPlayerList().Count();
        }
        #endregion
    }

}
