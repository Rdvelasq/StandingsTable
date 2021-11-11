using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Models.PlayerModels
{
    public class DetailPlayer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Goals { get; set; }
        public int? Assist { get; set; }
        public bool IsFieldPlayer { get; set; }
    }
}
