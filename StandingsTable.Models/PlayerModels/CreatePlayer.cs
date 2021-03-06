using StandingsTable.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StandingsTable.Models.PlayerModels
{
    public class CreatePlayer
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Field Player")]
        public bool IsFieldPlayer { get; set; }

        public int TeamId { get; set; }

        [Display(Name = "Team Name")]
        public Team Team { get; set; }
        public IEnumerable<SelectListItem> Teams { get; set; }

    }
}
