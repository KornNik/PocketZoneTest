using Helpers.Managers;
using UnityEngine;

namespace Behaviours
{
    sealed class UnitAnimation : MonoBehaviour, IEventSubscription
    {
        [SerializeField] private Animator _unitAnimator;

        private UnitEvents _unitEvents;
        private Combat _combat;

        private readonly int _attack = Animator.StringToHash(AnimationsName.ATTACK);
        private readonly int _move = Animator.StringToHash(AnimationsName.MOVE);

        private void OnEnable()
        {
            Subscribe();
        }
        private void OnDisable()
        {
            Unsubscribe();
        }

        public void SetSpeed(float speed)
        {
            _unitAnimator.speed = speed;
        }
        public void OnExecuteAttack()
        {
            _combat.StartAttack();
        }

        private void OnMove(bool isMoving)
        {
            _unitAnimator.SetBool(_move, isMoving);
        }
        private void OnAttack()
        {
            _unitAnimator.SetTrigger(_attack);
        }


        #region IEventSubscription

        public void Subscribe()
        {
            _unitEvents.Moving += OnMove;
            _unitEvents.Attacking += OnAttack;
        }

        public void Unsubscribe()
        {
            _unitEvents.Moving -= OnMove;
            _unitEvents.Attacking -= OnAttack;
        }

        #endregion

    }
}
