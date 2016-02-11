using HackersWars.Interfaces;

namespace HackersWars.Models
{
    public class Su24Attack : IAttack
    {
        private string attackType;

        public Su24Attack(string attackType)
        {
            this.AttackType = attackType;
        }

        public string AttackType { get; set; }
    }
}