using Data;
using UnityEngine;

namespace Behaviours.Items
{
    abstract class Weapon : Item, IWeapon
    {
        [SerializeField] private Transform _aimPoint;
        [SerializeField] private WeaponData _weaponData;

        public Transform AimPoint => _aimPoint;

        protected override void Awake()
        {
            base.Awake();
        }
        public virtual void Attack()
        {

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
    }
}
