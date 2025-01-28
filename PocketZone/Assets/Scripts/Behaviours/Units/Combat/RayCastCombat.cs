using UnityEngine;

namespace Behaviours
{
    class RayCastCombat : Combat
    {
        [SerializeField] private AudioClip _hittingAudio;
        public override void PerformAttack()
        {
            base.PerformAttack();
            var damageable = CurrentTarget as IDamageable;
            if (damageable != null)
            {
                //InflictDamage(new DamagerInfo(damageable,));
                MakeSoundShot(_hittingAudio);
            }
            else
            {
                EndAttack();
            }
        }

    }
}
