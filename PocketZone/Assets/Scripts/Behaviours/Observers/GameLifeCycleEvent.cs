using UnityEngine;
using Helpers;

namespace Behaviours
{
    enum GameCycleType
    {
        None,
        EndGame,
        StartGame,
        PlayerDead
    }
    struct GameLifeCycleEvent
    {
        private static GameLifeCycleEvent _lifeCycleEvent;

        private GameCycleType _type;

        public GameCycleType Type => _type;

        public static void Trigger(GameCycleType gameCycleType)
        {
            _lifeCycleEvent._type = gameCycleType;
            EventManager.TriggerEvent(_lifeCycleEvent);
        }
    }
}
