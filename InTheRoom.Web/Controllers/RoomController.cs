using InTheRoom.FileSystem;
using InTheRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InTheRoom.Web.Controllers
{
    public class RoomController : Controller
    {
        private IPlayerRepository _playerRepository;
        private IRoomRepository _roomRepository;

        public RoomController() // IPlayerRepository playerRepository)
        {
        }

        public RoomController(Player player)
        {
            _player = player;
        }

        private Player _player;

        protected Player Player { 
            get{
                return _player;
            }
        }

        private IRoom _currentRoom;

        protected IRoom CurrentRoom
        {
            get
            {
                return _currentRoom;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _roomRepository =
                new RoomRepositoryFileSystem(
                    @"C:\temp\InTheRoom");
            _playerRepository =
                new PlayerRepositoryFileSystem(
                    @"C:\temp\InTheRoom");
            //_playerRepository = playerRepository;
            // var username = Membership.GetUser().UserName;
            var username = "Marco";
            _player = _playerRepository.Get(username);
            _currentRoom = _roomRepository.Get(Player);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            _roomRepository.Save(CurrentRoom, Player);
            _playerRepository.Save(Player);
        }

        public JsonResult Info()
        {

            return Json(new RoomDTO { 
                Name = CurrentRoom.Name
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Look()
        {
            return Json(CurrentRoom.Look());
        }


        [HttpPost]
        public JsonResult Take(string thingName)
        {
            Player.Things.Add(CurrentRoom.Take(thingName));
            return Json(new { 
                result = "ok"
            });
        }

        [HttpPost]
        public JsonResult Use(string thingName)
        {
            var thingToUse = Player.Things.Single(xx => xx.Name == thingName);
            CurrentRoom.Use(thingToUse);
            Player.Things.Remove(thingToUse);
            if (thingToUse.Type == ThingType.Key)
            {
                Player.CurrentRoom = "BedRoom";
            }
            return Json(new
            {
                result = "ok"
            });
        }
    }
}