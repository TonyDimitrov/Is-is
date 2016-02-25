using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using HackersWars.Factories;
using HackersWars.GameEngine;
using HackersWars.Interfaces;
using HackersWars.Models;

namespace HackersWars
{
    internal class MainEntry
    {
        private static void Main(string[] args)
        {
         IHacherGroupFactory hacherGroupFactory = new HackerGroupFactory();
         IWarEffectFactory warEffectFactory = new WarEffectFactory();
            IReader reader = new ConsoleReader();
       IWriter writer = new Writer();
        IGameData gameData = new GameData();
        Engine engine = new Engine(hacherGroupFactory, warEffectFactory, reader, writer, gameData);

            engine.Run();

        }
    }
}