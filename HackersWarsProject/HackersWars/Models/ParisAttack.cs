using HackersWars.Interfaces;

namespace HackersWars.Models
{
    public class ParisAttack : IAttack
    {
        private string attackType;

        public ParisAttack(string attackType)
        {
            this.AttackType = attackType;
        }
        public string AttackType { get; set; }
    }
}