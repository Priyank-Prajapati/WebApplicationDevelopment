using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class EFMerchandiseRepository : IMerchandiseRepository
    {
        public ApplicationDbContext context;
        public EFMerchandiseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Merchandise> Merchandises => context.Merchandises;

        public void AddMerchandise(Merchandise merchandise)
        {
            if (merchandise.ID == 0)
            {
                context.Merchandises.Add(merchandise);
            }
            else
            {
                Merchandise dbEntry = context.Merchandises
                    .FirstOrDefault(m => m.ID == merchandise.ID);
                if (dbEntry != null)
                {
                    dbEntry.ProductName = merchandise.ProductName;
                    dbEntry.ProductType = merchandise.ProductType;
                    dbEntry.ProductPrice = merchandise.ProductPrice;
                    dbEntry.ProductClub = merchandise.ProductClub;
                    dbEntry.ProductDescription = merchandise.ProductDescription;
                }
            }
            context.SaveChanges();
        }

        public Merchandise DeleteMerchandise(int ID)
        {
            Merchandise dbEntry = context.Merchandises
               .FirstOrDefault(m => m.ID == ID);
            if (dbEntry != null)
            {
                context.Merchandises.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
