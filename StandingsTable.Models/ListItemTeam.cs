using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.ModelS
{
    public class ListItemTeam
    {
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loss { get; set; }
        public int Points { get; set; }
    }
}
