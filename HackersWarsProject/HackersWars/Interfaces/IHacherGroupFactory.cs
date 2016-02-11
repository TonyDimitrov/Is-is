using System.Net.Configuration;

namespace HackersWars.Interfaces
{
    public interface IHacherGroupFactory
    {
        void CreateGacherGroup(string name, int damage, int health, bool isAlive, IWarEffect warEffect, IAttack attack);
    }
}