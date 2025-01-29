using Data;
using Helpers.Managers;
using UnityEngine;

namespace Behaviours.Items
{
    class Weapon : Item, IWeapon, IDamager
    {
        [SerializeField] private Transform _aimPoint;
        [SerializeField] private WeaponData _weaponData;

        private ParticleSystem _muzzleFlash;
        private LayerMask _shootableMask;

        public Transform AimPoint => _aimPoint;
        public WeaponData WeaponData => _weaponData;

        protected override void Awake()
        {
            base.Awake();
            _muzzleFlash = Instantiate(_weaponData.ParticleSystemPrefab, Vector3.zero, Quaternion.identity, AimPoint);
            _shootableMask = LayerMask.GetMask(LayersManager.PLAYER, LayersManager.ENEMY);
        }
        public virtual void Attack()
        {
            if(!IsCanShoot()) return;

            Vector2 shootDirection = AimPoint.right;

            MakeSoundShot(_weaponData.FireAudio);
            CreateMuzzleFlash();

            RaycastHit2D hit = Physics2D.Raycast
            (
                AimPoint.position,
                shootDirection,
                _weaponData.Range,
                _shootableMask
            );
            Debug.DrawRay(AimPoint.position, shootDirection * _weaponData.Range, Color.red, 0.5f);

            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);

                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    InflictDamage(new DamagerInfo(damageable, hit.point, shootDirection));
                }
            }
        }

        public virtual void Recharge()
        {

        }

        public virtual void Reload()
        {
        }

        public virtual void Aim()
        {

        }

        public void Equiped()
        {
        }

        public void UnEquiped()
        {

        }

        private void MakeSoundShot(AudioClip actionAudio)
        {
            if (IsFastFire())
            {
                MakeSoundEvent.Trigger(new SoundEventInfo(actionAudio, transform.position, _weaponData.AudioVolume, true));
            }
            else
            {
                MakeSoundEvent.Trigger(new SoundEventInfo(actionAudio, transform.position, _weaponData.AudioVolume));
            }
        }
        private void CreateMuzzleFlash()
        {
            _muzzleFlash.Play();
        }

        protected virtual bool IsCanShoot()
        {
            var isCan = true;
            return isCan;
        }

        private bool IsFastFire()
        {
            var isFastFire = _weaponData.FireRate < 0.8f ? true : false;
            return isFastFire;
        }

        public void InflictDamage(DamagerInfo damageable)
        {
            damageable.Damageable.TakeDamage(new DamageableInfo
                (_weaponData.Damage, damageable.DamagePoint, damageable.DamageDirection));
        }
    }
}
