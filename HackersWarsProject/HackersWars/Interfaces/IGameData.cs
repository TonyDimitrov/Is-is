using System;
using System.Collections;
using System.Collections.Generic;

namespace HackersWars.Interfaces
{
    public interface IGameData 
    {
        IDictionary<string, IHacherGroup> Data { get; set; }

        void AddGameData(string hackerGroupName, IHacherGroup hackerGroup);
    }
}