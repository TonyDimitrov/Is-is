using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using HackersWars.Enum;
using HackersWars.Interfaces;
using HackersWars.Models;

namespace HackersWars.GameEngine
{
    class Engine : IEngine
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
                            ShouldTriggerAttackerWarEffect(attacherGroup);
                            ShouldTrigerVictimWarEffect(attacherGroup, victimGroup);
                        }
                        break;
                    case "status":
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

        public void UpdateAttacherWarEffectState(string groupName)
        {
            if (this.gameData.Data.ContainsKey(groupName))
            {
                var group = this.gameData.Data[groupName];
                if (!group.WarEffect.IsWarEffectTogled)
                {
                    
                }
            }
            else
            {
                throw new KeyNotFoundException("Such Key in Dictionary not found!");
            }
        }

        public void PerformAttack()
        {
            throw new NotImplementedException();
        }

        public void UpdateHackerGroups()
        {
            throw new NotImplementedException();
        }

        public void GetGameStatus()
        {
            throw new NotImplementedException();
        }

        private IHacherGroup FindHacherGroupByName(string groupName)
        {
            var group = gameData.Data[groupName];
            return group;
        }
        private void ShouldTriggerAttackerWarEffect(IHacherGroup group)
        {
            if (group.Attack == Attack.SU24 )
            {
                if (group.Health != 1)
                {
                    double halfhealth = Math.Ceiling((double)group.InitialHealth / 2);
                    group.Health = (int)halfhealth;
                    group.WarEffect.IsEffectActive = true;
                    group.WarEffect.IsWarEffectTogled = true;
                    if (group.WarEffect.WarEffectType == WarEffectType.Jihad)
                    {
                        group.Damage *= 2;
                    }
                    else
                    {
                        group.Health += 50;
                    }
                }
            }         
        }

        private void ShouldTrigerVictimWarEffect(IHacherGroup attacker, IHacherGroup attacked)
        {
            // TODO 
        }
    }
}
