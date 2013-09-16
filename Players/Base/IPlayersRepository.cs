using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquest
{
    interface IPlayersRepository
    {
        Player GetPlayerById(int pid);
        bool FindPlayer(string name);
        bool FindPlayer(int uid);
        IEnumerable<Player> GetPlayerList();
        bool AddPlayer(Player player);
        // void UpdatePlayer(Player player);
        void DeletePlayer(Player player);
        void DeleteAllPlayers();
        Player GetPlayerByName(string name);
        Player SavePlayer(Player player);
    }
}
