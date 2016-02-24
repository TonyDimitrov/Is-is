using System.Net.Configuration;
using HackersWars.Enum;

namespace HackersWars.Interfaces
{
    public interface IHacherGroupFactory
    {
        IHacherGroup CreateGacherGroup(string name, int health, int damage, bool isAlive,
            IWarEffect warEffect, Attack attack);
    }
}