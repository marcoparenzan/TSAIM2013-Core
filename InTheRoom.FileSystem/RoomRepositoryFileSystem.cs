using InTheRoom.Model;
using InTheRoom.Model.Rooms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.FileSystem
{
    public class RoomRepositoryFileSystem: IRoomRepository
    {
        private string _directory;

        public RoomRepositoryFileSystem(string directory)
        {
            _directory = directory;
        }

        IRoom IRoomRepository.Get(Player player)
        {
            var filename = 
                Path.Combine(
                _directory
                , "room_" 
                + player.CurrentRoom 
                + "_" 
                + player.Name 
                + ".json"
            );
            if (File.Exists(filename))
            {
                var room_json = File.ReadAllText(filename);
                var room_type =
                    Type.GetType("InTheRoom.Model.Rooms."
                    + player.CurrentRoom + ", InTheRoom.Model");
                return
                    (IRoom)
                    JsonConvert.DeserializeObject(room_json, room_type);
            }
            else
            {
                switch (player.CurrentRoom)
                {
                    case "LivingRoom":
                        return new LivingRoom(true) { 
                        };
                    case "BedRoom":
                        return new BedRoom(true)
                        {
                        };
                    default:
                        throw new NotImplementedException("Room not implemented");
                }
            }
        }

        void IRoomRepository.Save(IRoom room, Player player)
        {
            var filename = 
                Path.Combine(
                _directory
                , "room_" 
                + player.CurrentRoom 
                + "_" 
                + player.Name 
                + ".json");
            var room_json = JsonConvert.SerializeObject(room);
            File.WriteAllText(filename, room_json);
        }
    }
}
