using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Data
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loss { get; set; }
        public int Points { get; set; }

    }
}
