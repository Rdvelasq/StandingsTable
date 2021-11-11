using StandingsTable.Data;
using StandingsTable.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                IsFieldPlayer = model.IsFieldPlayer
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
    }
}
