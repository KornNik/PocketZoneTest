using System;
using Behaviours.Items;

namespace Behaviours
{
    class Combat : IAttacker
    {
        public event Action AttackEnded;
        public event Action AttackStarted;

        private ITarget _currentTarget;
        private IWeapon _weapon;
        private bool _isAttack;

        public ITarget CurrentTarget => _currentTarget;
        public bool IsAttack => _isAttack;

        public Combat()
        {

        }
        public virtual void Initilize()
        {

        }

        public virtual void StartAttack()
        {
            _isAttack = true;
            AttackStarted?.Invoke();
            _weapon.Aim();
            _weapon.Attack();
        }
        public virtual void EndAttack()
        {
            _isAttack = false;
            AttackEnded?.Invoke();
        }
        public virtual void PerformAttack()
        {

        }
    }
}