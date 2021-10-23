using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Models.GameModels
{
    public class CreateGame
    {
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public Team AwayTeam { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
