using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HackersWars.Interfaces;

namespace HackersWars.Models
{
    public class ConsoleReader : IReader
    {
        public List<string> Reader()
        {
            string input = Console.ReadLine();
            Regex pattern = new Regex("(\\w+)");
            MatchCollection matches = pattern.Matches(input);
            List<string> elements = new List<string>();
            foreach (var w in matches)
            {
                elements.Add(w.ToString());
            }
            return elements;
        }
    }
}