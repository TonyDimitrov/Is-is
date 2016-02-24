using HackersWars.Enum;
using HackersWars.Interfaces;

namespace HackersWars.Models
{
    public class HacherGroup : IHacherGroup
    {
        private string name;
        private int health;
        private int initialHealth;
        private int damage;
        private int initialDamage;
        private bool isAlive;
        private IWarEffect warEffect;

        public HacherGroup(string name, int health, int damage,
            bool isAlive, IWarEffect warEffect, Attack attack)
        {
            this.Name = name;
            this.Health = health;
            this.InitialHealth = health;
            this.Damage = damage;
            this.InitialDamage = damage;
            this.IsAlive = isAlive;
            this.WarEffect = warEffect;
            this.Attack = attack;
        }



        public string Name { get; }
        public int Health { get; set; }
        public int InitialHealth { get; set; }
        public int Damage { get; set; }
        public int InitialDamage { get; set; }
        public bool IsAlive { get; set; }
        public IWarEffect WarEffect { get; set; }
        public Attack Attack { get; }


    }
}