using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using HackersWars.Interfaces;

namespace HackersWars.Models
{
    public class GameData : IGameData
    {
        public GameData()
        {
            this.Data = new Dictionary<string, IHacherGroup>();
        }

        public IDictionary Data { get; set; }

        public void AddGameData(string hackerGroupName, IHacherGroup hackerGroup)
        {
            Data.Add(hackerGroupName, hackerGroup);
        }
    }
}