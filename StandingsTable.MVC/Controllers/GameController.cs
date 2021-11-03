using StandingsTable.Data;
using StandingsTable.Models;
using StandingsTable.Models.GameModels;
using StandingsTable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandingsTable.MVC.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = new CreateGame();

            viewModel.Teams = _db.Teams.Select(team => new SelectListItem
            {
                Text = team.Name,
                Value = team.Id.ToString()
            });
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGame model)
        {
            var service = new GameServices();

            var viewModel = new CreateGame();

            viewModel.Teams = _db.Teams.Select(team => new SelectListItem
            {
                Text = team.Name,
                Value = team.Id.ToString()
            });
            service.CreateGame(model);

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var service = new GameServices();
            var detail = service.GetGameById(id);

            var model =
                new EditGame
                {
                    Id = detail.Id,
                    Date = detail.Date,
                    HomeTeam = detail.HomeTeam,
                    HomeTeamScore = detail.HomeTeamScore,
                    AwayTeam = detail.AwayTeam,
                    AwayTeamScore = detail.AwayTeamScore
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditGame model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new GameServices();
            if (service.UpdateGame(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
                
        }

        public ActionResult ViewStandingsTable()
        {
            var service = new GameServices();
            var model = service.GetTeams();
            return View(model);
        }

    }
}