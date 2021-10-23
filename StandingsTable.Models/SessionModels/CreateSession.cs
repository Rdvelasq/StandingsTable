using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Models.SessionModels
{
    public class CreateSession
    {
        public List<int> GameIds { get; set; } = new List<int>();
        public List<Game> Games { get; set; } = new List<Game>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
