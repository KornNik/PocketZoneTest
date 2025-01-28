using UnityEngine;
using Pathfinding;

namespace Behaviours
{
    sealed class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerSpawn;
        [SerializeField] private Transform[] _enemiesSpawn;
        [SerializeField] private AstarPath _pathfinding;

        public Transform[] EnemiesSpawn => _enemiesSpawn;
        public Transform PlayerSpawn => _playerSpawn;

        private void Awake()
        {
            _pathfinding.Scan();
        }
    }
}
