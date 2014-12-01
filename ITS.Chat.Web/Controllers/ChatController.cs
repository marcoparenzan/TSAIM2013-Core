using ITS.Chat.Models.WorkerCommands;
using ITS.Chat.Web.Models;
using ITS.Chat.Web.Models.UserCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITS.Chat.Web.Controllers
{
    public class ChatController : Controller
    {
        public ActionResult Room()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Talk(TalkUserCommand command)
        {
            var workerCommand = new TalkWorkerCommand
            {
                Message = command.Message
                ,
                CommandType = "talk"
                ,
                Sender = "me"
                ,
                Timestamp = DateTime.UtcNow
            };

            return Json(new { 
                result = "ok"
            }, JsonRequestBehavior.DenyGet);
        }
    }
}