using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class Merchandise
    {

        [Key]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int ProductPrice { get; set; }
        public string ProductClub { get; set; }
        public string ProductDescription { get; set; }
    }
}
