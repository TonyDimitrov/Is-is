﻿//using System;

namespace HackersWars.Interfaces
{
    public interface IHacherGroup
    {
        // Hacher group has a name, health, damage, war effect and attack type //
         string Name { get; set; }
         int Health { get; set; }
        int InitialHealth { get; set; }
        int Damage { get; set; }
         bool IsAlive { get; set; }
        IWarEffect WarEffect { get; set; }
        IAttack Attack { get; set; }

    }
}