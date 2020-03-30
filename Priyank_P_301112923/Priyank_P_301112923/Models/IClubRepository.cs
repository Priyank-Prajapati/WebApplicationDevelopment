using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
   public  interface IClubRepository
    {
        IQueryable<Club> Clubs { get; }
        void AddClub(Club club);
        Club DeleteClub(int ID);
    }
}
