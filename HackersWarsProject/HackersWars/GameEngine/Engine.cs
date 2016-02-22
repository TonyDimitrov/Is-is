using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using HackersWars.Enum;
using HackersWars.Interfaces;

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
                        hacherGroupFactory.CreateGacherGroup(name, health, damage, true, effect, attack);
                        break;
                    case "attack":
                        // Implement attacks ..... //

                        break;
                    case "status":
                        break;
                    default:
                        throw new AggregateException("Input cannot be understood!");                                     
                }

                input = reader.Reader();
            }

        }

















        public bool IsHacherGroupsAlive()
        {
            throw new NotImplementedException();
        }

        public void UpdateAttacherWarEffectState()
        {
            throw new NotImplementedException();
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
    }
}
