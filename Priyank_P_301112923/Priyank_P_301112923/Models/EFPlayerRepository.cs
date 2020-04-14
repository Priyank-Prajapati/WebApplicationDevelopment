using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class EFPlayerRepository : IPlayerRepository
    {
        public ApplicationDbContext context;
        public EFPlayerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Player> Players => context.Players;

        public void AddPlayer(Player Player1)
        {
            if(Player1.ID == 0)
            {
                context.Players.Add(Player1);
            }
            else
            {
                Player dbEntry = context.Players
                    .FirstOrDefault(p => p.ID == Player1.ID);
                if(dbEntry != null)
                {
                    dbEntry.FirstName = Player1.FirstName;
                    dbEntry.LastName = Player1.LastName;
                    dbEntry.FieldName = Player1.FieldName;
                    dbEntry.BirthDate = Player1.BirthDate;
                    dbEntry.Gender = Player1.Gender;
                    dbEntry.Country = Player1.Country;
                    dbEntry.Club = Player1.Club;
                }
            }
            context.SaveChanges();
        }
        public Player DeletePlayer(int ID)
        {
            Player dbEntry = context.Players
                .FirstOrDefault(p => p.ID == ID);
            if (dbEntry != null)
            {
                context.Players.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
