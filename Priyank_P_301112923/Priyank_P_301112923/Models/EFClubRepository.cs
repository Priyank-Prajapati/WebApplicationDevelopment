using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class EFClubRepository : IClubRepository
    {
        private ApplicationDbContext context;
        public EFClubRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Club> Clubs => context.Clubs;
        public void AddClub(Club club)
        {
            if (club.ID == 0)
            {
                context.Clubs.Add(club);
            }
            else
            {
                Club dbEntry = context.Clubs
                    .FirstOrDefault(c => c.ID == club.ID);
                if(dbEntry != null)
                {
                    dbEntry.Name = club.Name;
                    dbEntry.Website = club.Website;
                    dbEntry.City = club.City;
                    dbEntry.Country = club.Country;
                    dbEntry.MatchesPlayed = club.MatchesPlayed;
                    dbEntry.Partners = club.Partners;
                    dbEntry.Category = club.Category;
                    dbEntry.Description = club.Description;
                }
            }
            context.SaveChanges();
        }
        public Club DeleteClub(int ID)
        {
            Club dbEntry = context.Clubs
                .FirstOrDefault(c => c.ID == ID);
            if(dbEntry != null)
            {
                context.Clubs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
