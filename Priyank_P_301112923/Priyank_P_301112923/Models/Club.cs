using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Priyank_P_301112923.Models
{
    public class Club
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int MatchesPlayed { get; set; }
        public string Partners { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
