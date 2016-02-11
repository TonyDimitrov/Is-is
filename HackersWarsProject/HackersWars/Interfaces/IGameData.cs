using System;
using System.Collections;
using System.Collections.Generic;

namespace HackersWars.Interfaces
{
    internal interface IGameData
    {
        IDictionary Data { get; set; }

        void AddGameData(string hackerGroupName, IHacherGroup hackerGroup);
    }
}