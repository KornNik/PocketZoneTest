using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemyData")]
    sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _stopingDistance;
        [SerializeField] private float _health;
        [SerializeField, Range(1.1f, 3f)] float _slowDownDistanceMultiplier;

        public float MovingSpeed => _movingSpeed;
        public float StopingDistance => _stopingDistance;
        public float SlowDownDistance => _stopingDistance * _slowDownDistanceMultiplier;
        public float Health  => _health;
    }
}
