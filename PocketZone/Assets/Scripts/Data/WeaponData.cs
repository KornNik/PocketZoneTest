using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon/WeaponData")]
    sealed class WeaponData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private ParticleSystem _particleSystemPrefab;
        [SerializeField] private AudioClip _fireAudio;

        public float Damage => _damage;
        public ParticleSystem ParticleSystemPrefab => _particleSystemPrefab;
    }
}
