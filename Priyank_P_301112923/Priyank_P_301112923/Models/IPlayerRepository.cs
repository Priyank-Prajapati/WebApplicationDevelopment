using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public interface IPlayerRepository
    {
        IQueryable<Player> Players { get; }
        void AddPlayer(Player p);
        Player DeletePlayer(int ID);
    }
}
