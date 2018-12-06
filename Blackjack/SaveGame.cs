using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class SaveGame
    {
        string json { get; set; }
        public SaveGame()
        {

        }

        public SaveGame(object save)
        {
            json = JsonConvert.SerializeObject(save, Formatting.Indented);
        }
    }
}
