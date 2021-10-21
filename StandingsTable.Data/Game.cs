﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public Team HomeTeam { get; set; }

        [Required]
        public Team AwayTeam { get; set; }

    }
}
