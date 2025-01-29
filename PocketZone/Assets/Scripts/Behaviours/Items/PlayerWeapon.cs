using Data;
using UnityEngine;

namespace Behaviours.Items
{
    sealed class PlayerWeapon : Weapon
    {
        private int _ammo;

        public override void Attack()
        {
            base.Attack();
            GetAmmo(WeaponData.AmmoConsumtion);
        }
        protected override bool IsCanShoot()
        {
            var isCanShoot = base.IsCanShoot() && IsHaveAmmo();
            return isCanShoot;
        }
        private void GetAmmo(int value)
        {
            var changedValue = _ammo - value;
            if (changedValue > 0)
            {
                _ammo = changedValue;
            }
            else
            {
                _ammo = 0;
            }
        }
        private bool IsHaveAmmo()
        {
            var isHaveAmmo = _ammo > 0 ? true : false;
            return isHaveAmmo;
        }
    }
}
