using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Data/Weapon/WeaponData")]
    sealed class WeaponData : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _fireRate;
        [SerializeField] private float _audioVolume;
        [SerializeField] private int _ammoConsumtion;
        [SerializeField] private ParticleSystem _particleSystemPrefab;
        [SerializeField] private AudioClip _fireAudio;

        public float Damage => _damage;
        public float Range => _range;
        public float FireRate => _fireRate;
        public AudioClip FireAudio => _fireAudio;
        public float AudioVolume => _audioVolume;
        public int AmmoConsumtion => _ammoConsumtion;
        public ParticleSystem ParticleSystemPrefab => _particleSystemPrefab;
    }
}
