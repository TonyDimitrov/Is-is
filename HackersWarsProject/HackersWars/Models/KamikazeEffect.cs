using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackersWars.Interfaces;

namespace HackersWars.Models
{
    class KamikazeEffect : IWarEffect
    {
        private string warEffectType;
        private bool iswarEffectTogged;
        private bool isEffectActive;

        public KamikazeEffect(string warEffectType, bool iswarEffectTogged, bool isEffectActive)
        {
            this.WarEffectType = warEffectType;
            this.IsWarEffectTogged = iswarEffectTogged;
            this.IsEffectActive = isEffectActive;
        }

        public string WarEffectType { get; set; }
        public bool IsWarEffectTogged { get; set; }
        public bool IsEffectActive { get; set; }
    }
}
