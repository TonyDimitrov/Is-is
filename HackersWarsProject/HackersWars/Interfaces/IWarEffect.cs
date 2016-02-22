using HackersWars.Enum;

namespace HackersWars.Interfaces
{
    public interface IWarEffect
    {
        WarEffectType WarEffectType { get; set; }
        bool IsWarEffectTogled { get; set; }
        bool IsEffectActive { get; set; }
    }
}