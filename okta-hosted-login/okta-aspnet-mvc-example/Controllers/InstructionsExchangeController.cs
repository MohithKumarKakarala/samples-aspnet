using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using okta_aspnet_mvc_example.Models;

namespace okta_aspnet_mvc_example.Controllers
{
    public class InstructionsExchangeController : Controller
    {
        private InstructionEntities _db = new InstructionEntities();

        // GET: InstructionsExchange
        public ActionResult Index()
        {
            var data = (from s in _db.Instructions select s).ToList();
            ViewBag.users = data;
            ViewBag.title = "Tachyon Instructions";

            return View();
        }
    }
}