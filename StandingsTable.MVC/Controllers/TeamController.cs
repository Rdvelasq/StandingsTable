using StandingsTable.Models;
using StandingsTable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandingsTable.MVC.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            return View();
        }

        //GET Team/Create
        public ActionResult Create()
        {        
            return View();
        }

        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateTeam model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new TeamServices();
            if (service.CreateTeam(model))
            {
                RedirectToAction("Index");
            }

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service =  new TeamServices();
            var model = service.GetTeamByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeam(int id)
        {
            var service = new TeamServices();

            service.DeleteTeam(id);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = new TeamServices();
            var detail = service.GetTeamByID(id);
            var model =
                new EditTeam
                {
                    Id = detail.Id,
                    Name = detail.Name,
                };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditTeam model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new TeamServices();
            if (service.UpdateTeam(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult ViewTeams()
        {
            var service = new TeamServices();
            var model = service.GetTeams();
            return View(model);
        }
    }
}