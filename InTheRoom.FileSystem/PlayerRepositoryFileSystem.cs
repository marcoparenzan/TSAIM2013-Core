using InTheRoom.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.FileSystem
{
    public class PlayerRepositoryFileSystem: IPlayerRepository
    {
        private string _directory;

        public PlayerRepositoryFileSystem(string directory)
        {
            _directory = directory;
        }

        Player IPlayerRepository.Get(string name)
        {
            var filename = Path.Combine(_directory, "player_" + name + ".json");
            if (File.Exists(filename))
            {
                var player_json = File.ReadAllText(filename);
                return JsonConvert.DeserializeObject<Player>(player_json);
            }
            else
            {
                return new Player
                {
                    Name = name
                    ,
                    CurrentRoom = "LivingRoom"
                };
            }
        }

        void IPlayerRepository.Save(Player player)
        {
            var filename = Path.Combine(_directory, "player_" + player.Name + ".json");
            var player_json = JsonConvert.SerializeObject(player);
            File.WriteAllText(filename, player_json);
        }
    }
}
