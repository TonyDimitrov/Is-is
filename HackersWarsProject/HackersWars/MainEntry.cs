﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace HackersWars
{
    internal class MainEntry
    {
        private static void Main(string[] args)
        {
            // Hacher group has a name, health, damage, war effect and attack type //
            // War effect JihadEffect and Kamikaze
            // Attack Type Paris and SU24
            Console.WriteLine("Tony");
            string input = Console.ReadLine();
            Regex pattern = new Regex("(\\w+)");
            MatchCollection matches = pattern.Matches(input);
            List<string> elements = new List<string>();
            foreach (var w in matches)
            {
                elements.Add(w.ToString());
            }
        }
    }
}