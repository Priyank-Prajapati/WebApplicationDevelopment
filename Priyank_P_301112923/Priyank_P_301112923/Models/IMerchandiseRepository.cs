using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public interface IMerchandiseRepository
    {
        IQueryable<Merchandise> Merchandises { get; }
        void AddMerchandise(Merchandise m);
        Merchandise DeleteMerchandise(int ID);
    }
}
