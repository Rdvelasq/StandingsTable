using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Models.GameModels
{
    public class ListItemGame
    {
        public DateTime Date { get; set; }
        [Display(Name ="Home Team")]
        public Team HomeTeam { get; set; }

        [Display(Name = "Home Team Score")]
        public int HomeTeamScore { get; set; }

        [Display(Name = "Awayt Team")]
        public Team AwayTeam { get; set; }

        [Display(Name = "Away Team Score")]
        public int AwayTeamScore { get; set; }
    }
}
