using ITS.Chat.Models.Events;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITS.Chat.Web.Controllers
{
    public class WorkerController : Controller
    {
        [HttpPost]
        public JsonResult Talk(TalkEvent evt)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hub.Clients.All.talk(evt.Sender, evt.Timestamp, evt.TalkId);
            return Json(new
            {
                result = "ok"
            }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult TalkTo(TalkToEvent evt)
        {
            var hub = (ChatHub)GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hub.TalkTo(evt.Sender, evt.Recipient, evt.Timestamp, evt.TalkId);
            return Json(new
            {
                result = "ok"
            }, JsonRequestBehavior.DenyGet);
        }
    }
}