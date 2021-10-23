using StandingsTable.Data;
using StandingsTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Services
{
    public class TeamServices
    {
        public bool CreateTeam(CreateTeam model)
        {
            var entity =
                new Team()
                {
                    Name = model.Name,
                    Wins = model.Wins,
                    Draws = model.Draws,
                    Loss = model.Loss,
                    Points = model.Points,
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Teams
                        .Single(e => e.Id == id);
                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
