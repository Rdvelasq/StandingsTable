using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Data
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("HomeTeam")]
        public int? HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }
        public int HomeTeamScore { get; set; }

        [ForeignKey("AwayTeam")]
        public int? AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }
        public int AwayTeamScore { get; set; }

    }
}
