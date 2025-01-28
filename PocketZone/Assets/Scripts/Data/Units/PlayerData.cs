using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData")]
    sealed class PlayerData : ScriptableObject
    {
        [SerializeField] private float _movingSpeed;
        [SerializeField] private float _health;

        public float MovingSpeed => _movingSpeed;
        public float Health => _health;

    }
}
