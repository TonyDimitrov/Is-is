using System.Collections.Generic;

namespace HackersWars.Interfaces
{
    public interface IEngine
    {
        

        bool IsHacherGroupsAlive();

        void UpdateAttacherWarEffectState();

        void PerformAttack();

        void UpdateHackerGroups();

        void GetGameStatus();
    }
}