using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using HackersWars.Enum;
using HackersWars.Interfaces;
using HackersWars.Models;

namespace HackersWars.GameEngine
{
   public class Engine : IEngine
    {
        private IHacherGroupFactory hacherGroupFactory;
        private IWarEffectFactory warEffectFactory;
        private IReader reader;
        private IWriter writer;
        private IGameData gameData;
        
        public Engine(IHacherGroupFactory hacherGroupFactory, IWarEffectFactory warEffect,
            IReader reader, IWriter writer,
            IGameData gameData)
        {
            this.hacherGroupFactory = hacherGroupFactory;
            this.warEffectFactory = warEffect;
            this.reader = reader;
            this.writer = writer;
            this.gameData = gameData;
        }
        public void Run()
        {
            List<string> input = reader.Reader();

            while (input[1] != "apocalypse")
            {

                switch (input[1])
                {
                    
                    case "create":
                        string name = input[0];
                        int health = int.Parse(input[2]);
                        int damage = int.Parse(input[3]);
                        string warEffectName = input[4];
                        WarEffectType effectType;
                        if (!System.Enum.TryParse(warEffectName, out effectType))
                        {
                            throw new ArgumentException("Could not parse string to Enum!");
                        }
                        string attackType = input[5];
                        Attack attack;
                        if (!System.Enum.TryParse(attackType, out attack))
                        {
                            throw new ArgumentException("Could not parse string to Enum type!");
                        }
                        var effect = warEffectFactory.CreateWarEffect(effectType, false, false);
                        var  hackerGroup = hacherGroupFactory.CreateGacherGroup(name, health, damage, true, effect, attack);
                        this.gameData.AddGameData(name, hackerGroup);
                        break;
                    case "attack":
                        // Implement attacks ..... //
                        string attacker = input[0];
                        string attacked = input[2];
                        if (IsHacherGroupsAlive(attacker) && IsHacherGroupsAlive(attacked))
                        {
                            var attacherGroup = FindHacherGroupByName(attacker);
                            var victimGroup = FindHacherGroupByName(attacked);

                            if (!attacherGroup.WarEffect.IsWarEffectTogled)
                            {
                                ShouldTriggerAttackerWarEffect(attacherGroup);
                            }
                            if (!victimGroup.WarEffect.IsWarEffectTogled)
                            {

                                ShouldTrigerVictimWarEffect(attacherGroup, victimGroup);
                            }
                            else
                            {
                                PerformAttack(attacherGroup, victimGroup);
                            }
              
                        }
                        break;
                    case "status":
                        GetGameStatus();
                        UpdateHackerGroups();
                        break;
                    case "akbar":
                        UpdateHackerGroups();
                        break;
                    default:
                        throw new AggregateException("Input cannot be understood!");                                     
                }

                input = reader.Reader();
            }        
        }

        public bool IsHacherGroupsAlive(string groupName)
        {
            if (this.gameData.Data.ContainsKey(groupName))
            {
               var  group = this.gameData.Data[groupName];
                return group.IsAlive;
            }
            else
            {
                throw new KeyNotFoundException("Such Key in Dictionary not found!");
            }
        }

        private IHacherGroup FindHacherGroupByName(string groupName)
        {
            var group = gameData.Data[groupName];
            return group;
        }

        private void ShouldTriggerAttackerWarEffect(IHacherGroup group)
        {
            if (group.Attack == Attack.SU24 ) // loses half the health 
            {
                if (group.Health % 2 == 0)
                {
                 ApplyWarEffect(group);
                }
            }         
        }

        private void ShouldTrigerVictimWarEffect(IHacherGroup attacker, IHacherGroup attacked)
        {
            double halfHealth = Math.Ceiling(((double)attacked.Health/2));
            if (attacker.Attack == Attack.Paris)
            {
                attacked.Health -= attacker.Damage;
                if (attacked.Health < 0)
                {
                    attacked.Health = 0;
                }
                if (attacked.Health <= halfHealth)
                {
                    ApplyWarEffect(attacked);
                }
            }
            else if(attacker.Attack == Attack.SU24)
            {
                attacked.Health -= attacker.Damage*2;
                // here
                double halfhealth = Math.Ceiling((double)attacker.Health / 2);
                attacker.Health = (int)halfhealth;

                if (attacked.Health < 0)
                {
                    attacked.Health = 0;
                }
                if (attacked.Health <= halfHealth)
                {
                    ApplyWarEffect(attacked);
                }
          
            }

        }

        private void ApplyWarEffect(IHacherGroup hacherGroup)
        {
            if (hacherGroup.WarEffect.WarEffectType == WarEffectType.Jihad)
            {
                hacherGroup.Damage *= 2;
                hacherGroup.WarEffect.IsEffectActive = true;
                hacherGroup.WarEffect.IsWarEffectTogled = true;
            }
            else
            {
    
                hacherGroup.Health += 50;
                hacherGroup.WarEffect.IsEffectActive = true;
                hacherGroup.WarEffect.IsWarEffectTogled = true;
            }
        }

        public void PerformAttack(IHacherGroup attacker, IHacherGroup attacked)
        {
            if (attacker.Attack == Attack.Paris)
            {
                attacked.Health -= attacker.Damage;
            }
            else
            {
                double halfhealth = Math.Ceiling((double)attacker.Health / 2);
                attacker.Health = (int)halfhealth;
                attacked.Health -= (attacker.Damage*2);
            }
        }

        public void UpdateHackerGroups()
        {
            foreach (var group in gameData.Data)
            {
                if (group.Value.Health <= 0)
                {
                    group.Value.IsAlive = false;
                }
                else
                {
                    if (group.Value.WarEffect.IsEffectActive == true &&
                        group.Value.WarEffect.WarEffectType == WarEffectType.Jihad)
                    {
                        if (group.Value.InitialDamage < group.Value.Damage)
                        {
                            group.Value.Damage -= 5;
                        }
                        else
                        {
                            group.Value.WarEffect.IsEffectActive = false;
                        }
                    }
                    else if (group.Value.WarEffect.IsEffectActive == true &&
                        group.Value.WarEffect.WarEffectType == WarEffectType.Kamikaze)
                    {
                        group.Value.Health -= 10;
                        if (group.Value.Health <= 0)
                        {
                            group.Value.IsAlive = false;
                        }
                    }
               
                }
            }
        }

        public void GetGameStatus()
        {
         //   this.gameData.Data
            var newData = gameData.Data.OrderByDescending(x => x.Value.Damage)
                .ThenByDescending(y => y.Value.Health).ToDictionary(x => x.Key, y => y.Value);
            foreach (var group in gameData.Data)
            {

                if (group.Value.IsAlive)
                {
                    Console.WriteLine("Group {0}: {1} HP {2} Damage", group.Key, group.Value.Health,
                      group.Value.Damage);
                }
                else
                {
                    Console.WriteLine("Group {0} AMEN", group.Key, group.Value.Health);

            }
            }     
        }

    }
}