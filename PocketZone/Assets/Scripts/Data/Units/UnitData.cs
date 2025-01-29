using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "UnitData", menuName = "Data/Unit/UnitData")]
    sealed class UnitData : ScriptableObject
    {
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _health;

        public float MovingSpeed => _movingSpeed;
        public float Health => _health;
    }
}
