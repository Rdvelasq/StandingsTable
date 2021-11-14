using StandingsTable.Data;
using StandingsTable.Models;
using StandingsTable.ModelS;
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

        public TeamDetails GetTeamByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.Id == id);
                return
                    new TeamDetails
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Wins = entity.Wins,
                        Draws = entity.Draws,
                        Loss = entity.Loss,
                        Points = entity.Points
                    };
            }
        }

        public bool UpdateTeam(EditTeam team)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = 
                ctx
                .Teams
                .Single(e => e.Id == team.Id);
                entity.Id = team.Id;
                entity.Name = team.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ListItemTeam> GetTeams()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Teams
                    .Select(e => new ListItemTeam
                    {
                        Name = e.Name,

                    }
                    );

                return query.ToList();
                    
            }
        }
    }
}