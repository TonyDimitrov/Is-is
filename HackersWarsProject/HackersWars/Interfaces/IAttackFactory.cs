namespace HackersWars.Interfaces
{
    public interface IAttackFactory
    {
       void CreateAttack(string type, bool isWarEffectTrigered);
    }
}