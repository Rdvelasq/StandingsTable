using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Models.PlayerModels
{
    public class EditPlayer
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = " s Field Player")]
        public bool IsFieldPlayer { get; set; }

    }
}
