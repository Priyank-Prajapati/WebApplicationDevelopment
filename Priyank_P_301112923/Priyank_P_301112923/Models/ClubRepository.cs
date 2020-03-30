using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class ClubRepository
    {
        public static List<Club> Clubs = new List<Club>()
        {  };

        public static IQueryable<Club> Club
        {
            get { return Clubs.AsQueryable<Club>(); }
        }

        public static void AddClub(Club club)
        {
            Clubs.Add(club);
        }
    }
}
