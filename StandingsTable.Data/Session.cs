using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Data
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey(nameof(Game))]
        public List<int> GameIds { get; set; } = new List<int>();
        public List<Game> Games { get; set; } = new List<Game>();

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

    }
}
