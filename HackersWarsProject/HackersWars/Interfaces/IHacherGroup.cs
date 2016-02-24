//using System;

using HackersWars.Enum;

namespace HackersWars.Interfaces
{
    public interface IHacherGroup
    {
        // Hacher group has a name, health, damage, war effect and attack type //
         string Name { get; }
         int Health { get; set; }
        int InitialHealth { get; set; }
        int Damage { get; set; }
        int InitialDamage { get; set; }
        bool IsAlive { get; set; }
        IWarEffect WarEffect { get; set; }
        Attack Attack { get; }

    }
}