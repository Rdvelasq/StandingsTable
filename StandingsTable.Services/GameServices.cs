using StandingsTable.Data;
using StandingsTable.Models;
using StandingsTable.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandingsTable.Services
{
    public class GameServices
    {
        public bool CreateGame(CreateGame model)
        {
            var newGame = new Game()
            {
                Date = model.Date,
                HomeTeamId = model.HomeTeamId,
                HomeTeamScore = model.HomeTeamScore,
                AwayTeamId = model.AwayTeamId,
                AwayTeamScore = model.AwayTeamScore
            };

            using(var ctx = new ApplicationDbContext())
            {
                var homeTeam =
                        ctx
                        .Teams
                        .Single(e => e.Id == newGame.HomeTeamId);
                var awayTeam =
                        ctx
                        .Teams
                        .Single(e => e.Id == newGame.AwayTeamId);

                if (newGame.HomeTeamScore > newGame.AwayTeamScore)
                {
                    homeTeam.Wins++;
                    homeTeam.Points += 3;
                    awayTeam.Loss++;

                }
                else if (newGame.HomeTeamScore < newGame.AwayTeamScore)
                {
                    awayTeam.Wins++;
                    awayTeam.Points += 3;
                   homeTeam.Loss++;

                }
                else
                {
                    homeTeam.Draws++;
                    awayTeam.Draws++;
                }
                ctx.Games.Add(newGame);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game =
                    ctx
                    .Games
                    .Single(e => e.Id == id);
                if (game != null)
                {
                    return ctx.SaveChanges() == 1;
                }

                return false;
            }
        }

        public bool UpdateGame(EditGame game)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Id == game.Id);
                entity.HomeTeamScore = game.HomeTeamScore;
                entity.AwayTeamScore = game.HomeTeamScore;

                return ctx.SaveChanges() == 1;

            }
        }

        public GameDetail GetGameById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.Id == id);
                return
                    new GameDetail
                    {
                        Id = entity.Id,
                        Date = entity.Date,
                        HomeTeam = entity.HomeTeam,
                        HomeTeamScore = entity.HomeTeamScore,
                        AwayTeam = entity.AwayTeam,
                        AwayTeamScore = entity.AwayTeamScore
                    };
                    
            }
        }
        
        public IEnumerable<TeamDetails> GetTeams()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Teams
                        .Select(
                            e =>
                                new TeamDetails
                                {
                                    Id = e.Id,
                                    Name = e.Name,
                                    Wins = e.Wins,
                                    Draws = e.Draws,
                                    Loss = e.Loss,
                                    Points = e.Points
                                }
                         );
                return query.ToArray();
                
            }
            
        }

        public IEnumerable<ListItemGame> GetGames()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Select(e =>
                                new ListItemGame
                                {
                                    Date = e.Date,
                                    HomeTeam = e.HomeTeam,
                                    HomeTeamScore = e.HomeTeamScore,
                                    AwayTeam = e.AwayTeam,
                                    AwayTeamScore = e.AwayTeamScore
                                });
                return query.ToList();
            }
                
        }
    }
}
