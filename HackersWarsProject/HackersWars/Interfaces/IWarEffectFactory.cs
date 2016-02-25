using HackersWars.Enum;

namespace HackersWars.Interfaces
{
    public interface IWarEffectFactory
    {
        IWarEffect CreateWarEffect(WarEffectType warEffectType, bool isWarEffectToggled, bool isWarEffectActive);

  }
}