using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Blackjack
{
    class SaveGame
    {
        string json { get; set; }
        string path { get; set; } 
        public SaveGame()
        {
            path = @"Saves/SaveGame.txt";
        }

        public SaveGame(object save)
        {
            if (!File.Exists(path))
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(save));
            }
            else
            {
                File.Create(path);
                File.WriteAllText(path, JsonConvert.SerializeObject(save));
            }
        }

        public void SaveObject()
        {
        }
    }
}
