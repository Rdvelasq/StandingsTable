using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StandingsTable.Models.GameModels
{
    public class CreateGame
    {
        public DateTime Date { get; set; }

        [Display(Name = "Home Team")]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        [Display(Name = "Home Team Score")]
        public int HomeTeamScore { get; set; }

        [Display(Name = "Away Team")]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        [Display(Name = "Away Team Score")]
        public int AwayTeamScore { get; set; }
        public IEnumerable<SelectListItem> Teams { get; set; }
    }
}
