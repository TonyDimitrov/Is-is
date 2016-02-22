using HackersWars.Enum;

namespace HackersWars.Interfaces
{
    internal interface IWarEffectFactory
    {
        IWarEffect CreateWarEffect(WarEffectType warEffectType, bool isWarEffectToggled, bool isWarEffectActive);

  }
}