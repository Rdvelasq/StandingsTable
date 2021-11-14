using StandingsTable.Data;
using StandingsTable.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StandingsTable.Services
{
    public class PlayerServices
    {
        public bool CreatePlayer(CreatePlayer model)
        {
            var entity = new Player()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                IsFieldPlayer = model.IsFieldPlayer,
                TeamId = model.TeamId
                
            };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public DetailPlayer GetPlayerById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Single(e => e.Id == id);
                return
                    new DetailPlayer()
                    {
                        Id = entity.Id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Goals = entity.Goals,
                        Assist = entity.Assist,
                        IsFieldPlayer = entity.IsFieldPlayer
                    };
            }
        }

        public bool EditPlayer(EditPlayer player)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Single(e => e.Id == player.Id);
                entity.Id = player.Id;
                entity.FirstName = player.FirstName;
                entity.LastName = player.LastName;
                entity.IsFieldPlayer = player.IsFieldPlayer;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlayer(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Select(e => e.Id == id);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SelectListItem> TeamSelectItem()
        {
            
            using(var ctx = new ApplicationDbContext())
            {
                var viewModel = new CreatePlayer();
                viewModel.Teams =
                    ctx
                    .Teams
                    .Select(team => new SelectListItem
                    {
                        Text = team.Name,
                        Value = team.Id.ToString()
                    });
                return viewModel.Teams.ToList();
                  
            }
        }

        public IEnumerable<ListItemPlayer> GetPlayers()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Players
                    .Select(e => new ListItemPlayer
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        IsFieldPlayer = e.IsFieldPlayer,
                        Team = e.Team
                       
                    });
                return query.ToList();
            }
        }
    }
}
