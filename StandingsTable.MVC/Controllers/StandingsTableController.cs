using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandingsTable.MVC.Controllers
{
    public class StandingsTableController : Controller
    {
        // GET: StandingsTable
        public ActionResult Home()
        {
            return View();
        }
    }
}