using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class PlayerRepository
    {
        public static List<Player> Players = new List<Player>() { };

        public static IQueryable<Player> Club
        {
            get { return Players.AsQueryable<Player>(); }
        }
        public static void AddPlayer(Player response) { Players.Add(response); }
    }
}
