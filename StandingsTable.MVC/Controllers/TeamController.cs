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
    }
}