using HackersWars.Enum;
using HackersWars.Interfaces;

namespace HackersWars.Models
{
    class WarEffect : IWarEffect
    {
        private WarEffectType warEffectType;
        private bool isWarEffectTogged;
        private bool isEffectActive;

        public WarEffect(WarEffectType warEffectType, bool isWarEffectTogled, bool isEffectActive)
        {
            this.WarEffectType = warEffectType;
            this.IsWarEffectTogled = isWarEffectTogled;
            this.IsEffectActive = isEffectActive;
        }

        public WarEffectType WarEffectType { get; set; }
        public bool IsWarEffectTogled { get; set; }
        public bool IsEffectActive { get; set; }
    }
}
