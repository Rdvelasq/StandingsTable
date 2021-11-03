using StandingsTable.Data;
using StandingsTable.Models.SessionModels;
using StandingsTable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandingsTable.MVC.Controllers
{
    public class SessionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Session
        public ActionResult Index()
        {
            return View();
        }

        // GET: Session/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST 
        [HttpPost]
        public ActionResult Create(CreateSession model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SessionServices();
            if (service.CreateSession(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}