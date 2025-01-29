using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Unit/EnemyData")]
    sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private float _stopingDistance;
        [SerializeField, Range(1.1f, 3f)] float _slowDownDistanceMultiplier;

        public float StopingDistance => _stopingDistance;
        public float SlowDownDistance => _stopingDistance * _slowDownDistanceMultiplier;
    }
}
