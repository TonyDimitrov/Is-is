using System;
using HackersWars.Enum;
using HackersWars.Interfaces;
using HackersWars.Models;

namespace HackersWars.Factories
{
    class HackerGroupFactory : IHacherGroupFactory
    {
        public IHacherGroup CreateGacherGroup(string name, int damage, int health,
            bool isAlive, IWarEffect warEffect, Attack attack)
        {
            return new HacherGroup(name, damage, health, isAlive, warEffect, attack);
        }
    }
}
