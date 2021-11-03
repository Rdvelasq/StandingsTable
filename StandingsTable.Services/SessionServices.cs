using StandingsTable.Data;
using StandingsTable.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Services
{
    public class SessionServices
    {
        public bool CreateSession(CreateSession model)
        {
            var entity =
                new Session
                {
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
   
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Sessions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
