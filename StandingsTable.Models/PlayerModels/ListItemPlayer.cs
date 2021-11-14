using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Models.PlayerModels
{
    public class ListItemPlayer
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int Goals { get; set; }
        public int Assist { get; set; }

        [Display(Name = "is Field Player")]
        public bool IsFieldPlayer { get; set; }

        [Display(Name = "Team Name")]
        public Team Team { get; set; }

    }
}
