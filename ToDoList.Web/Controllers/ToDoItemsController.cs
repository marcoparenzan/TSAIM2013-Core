using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Web.Models;

namespace ToDoList.Web.Controllers
{
    public class ToDoItemsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NuovaCosaDaFareOggi()
        {
            return View();
        }

        [HttpPost]
        [ActionName("NuovaCosaDaFareOggi")]
        public ActionResult Handle(NuovaCosaDaFareOggiCommand command)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("NuovaCosaDaFareDomani")]
        public ActionResult Handle(NuovaCosaDaFareDomaniCommand command)
        {
            return RedirectToAction("Index");
        }
    }
}