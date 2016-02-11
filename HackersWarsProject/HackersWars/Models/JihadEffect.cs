using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackersWars.Interfaces;

namespace HackersWars.Models
{
    class JihadEffect : IWarEffect
    {
        private string warEffectType;
        private bool isWarEffectTogged;
        private bool isEffectActive;

        public JihadEffect(string warEffectType, bool isWarEffectTogged, bool isEffectActive)
        {
            this.WarEffectType = warEffectType;
            this.IsWarEffectTogged = isWarEffectTogged;
            this.IsEffectActive = isEffectActive;
        }

        public string WarEffectType { get; set; }
        public bool IsWarEffectTogged { get; set; }
        public bool IsEffectActive { get; set; }
    }
}
