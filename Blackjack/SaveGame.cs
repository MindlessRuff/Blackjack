using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.Storage;


namespace Blackjack
{
    class SaveGame
    {
        string json { get; set; }
        string path { get; set; } 
        public SaveGame()
        {
            path = ApplicationData.Current.LocalFolder.Path;
        }

        public SaveGame(object save)
        {
            path = @"Saves/SaveGame.txt";
        }

        public void SaveObject(object save)
        {
            System.Threading.ManualResetEvent mre = new System.Threading.ManualResetEvent(false);
            Task.Factory.StartNew(async () =>
            {
                await ApplicationData.Current.LocalFolder.CreateFolderAsync("BlackjackSaves");
                mre.Set();
            });
            mre.WaitOne();

            Path.Combine(path, "SaveGame.txt");
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
    }
}
