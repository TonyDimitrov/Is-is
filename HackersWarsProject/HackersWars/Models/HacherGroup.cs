using HackersWars.Interfaces;

namespace HackersWars.Models
{
    public class HacherGroup : IHacherGroup
    {
        private string name;
        private int health;
        private int initialHealth;
        private int damage;
        private bool isAlive;
        private IWarEffect warEffect;
        private IAttack attack;


        public HacherGroup(string name, int health, int initialHealth, int damage,
            bool isAlive, IWarEffect warEffect, IAttack attack)
        {
            this.Name = name;
            this.Health = health;
            this.InitialHealth = initialHealth;
            this.Damage = damage;
            this.IsAlive = isAlive;
            this.WarEffect = warEffect;
            this.Attack = attack;
        }



        public string Name { get; set; }
        public int Health { get; set; }
        public int InitialHealth { get; set; }
        public int Damage { get; set; }
        public bool IsAlive { get; set; }
        public IWarEffect WarEffect { get; set; }
        public IAttack Attack { get; set; }
    }
}