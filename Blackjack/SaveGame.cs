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
            json = JsonConvert.SerializeObject(save, Formatting.Indented);
        }

        public void SaveObject()
        {
            if (!File.Exists(path))
            {
                using (FileStream fs = File.Create(path))
                {
                
                }
            }
        }
    }
}
