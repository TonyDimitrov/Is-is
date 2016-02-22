using System;
using System.Collections.Generic;
using HackersWars.Enum;
using HackersWars.Interfaces;
using HackersWars.Models;


namespace HackersWars.Factories
{
    class WarEffectFactory : IWarEffectFactory
    {
        public IWarEffect CreateWarEffect(WarEffectType warEffectType, bool isWarEffectToggled, bool isWarEffectActive)
        {
            return new WarEffect(warEffectType, isWarEffectToggled, isWarEffectActive);
        }
    }
}
