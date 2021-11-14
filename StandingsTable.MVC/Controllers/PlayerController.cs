using StandingsTable.Models.PlayerModels;
using StandingsTable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandingsTable.MVC.Controllers
{
    public class PlayerController : Controller
    {
        // GET: Player
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            var service = new PlayerServices();
            var viewModel = new CreatePlayer();
            viewModel.Teams = service.TeamSelectItem();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePlayer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = new PlayerServices();
            model.Teams = service.TeamSelectItem();
            if (service.CreatePlayer(model))
            {
                RedirectToAction("Index");
            }
            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            var service = new PlayerServices();
            var detail = service.GetPlayerById(id);
            var model =
                new EditPlayer()
                {
                    Id = detail.Id,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    IsFieldPlayer = detail.IsFieldPlayer
                };
            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult Edit(EditPlayer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new PlayerServices();
            if (service.EditPlayer(model))
            {
                RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = new PlayerServices();
            var model = service.GetPlayerById(id);
            return View(model);
                
        }

        public ActionResult DeletePlayer(int id)
        {
            var service = new PlayerServices();

            if (service.DeletePlayer(id))
            {
                RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ViewPlayers()
        {
            var service = new PlayerServices();
            var model = service.GetPlayers();
            return View(model);
        }

    }
}