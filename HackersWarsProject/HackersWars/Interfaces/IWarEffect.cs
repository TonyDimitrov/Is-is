namespace HackersWars.Interfaces
{
    public interface IWarEffect
    {
        string WarEffectType { get; set; }
        bool IsWarEffectTogged { get; set; }
        bool IsEffectActive { get; set; }
    }
}