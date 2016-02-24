using System.Collections.Generic;

namespace HackersWars.Interfaces
{
    public interface IEngine
    {
        

        bool IsHacherGroupsAlive(string groupName);

        void UpdateAttacherWarEffectState(string groupName);

        void PerformAttack();

        void UpdateHackerGroups();

        void GetGameStatus();
    }
}