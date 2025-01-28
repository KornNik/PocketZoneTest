using System;
using UnityEngine;
using Data;
using Helpers;

namespace Behaviours
{
    abstract class Combat : MonoBehaviour, IAttacker, IDetector, IDamager
    {
        public event Action AttackEnded;
        public event Action AttackStarted;
        public event Action TargetNull;

        [SerializeField] private LayerMask _targetLayers;
        [SerializeField] private Color _gizmosColor;
        [SerializeField] private bool _isFastFire = false;
        [SerializeField, Range(0, 1f)] private float _combatVolume = 0.45f;

        protected bool _isEvenShot;

        private ITarget _currentTarget;

        #region detector

        private Vector2 _detectorSize;
        private Vector2 _detectorOffset = Vector2.zero;
        private Collider2D _hitCollider;
        private Collider2D[] _hitColliders;
        private bool _isAttack;

        #endregion

        public ITarget CurrentTarget => _currentTarget;
        public LayerMask TargetLayer => _targetLayers;

        public bool IsAttack => _isAttack;
        public bool IsFastFire => _isFastFire;

        protected virtual void OnEnable()
        {
            _isEvenShot = false;
        }
        private void Awake()
        {
            _hitColliders = new Collider2D[3];
        }
        public virtual void Initilize()
        {

        }

        public bool DetectTarget()
        {
            var hits = Physics2D.OverlapBoxNonAlloc((Vector2)transform.position + _detectorOffset * transform.right.x,
                _detectorSize, 0f, _hitColliders, _targetLayers.value);
            _hitCollider = Physics2D.OverlapBox((Vector2)transform.position + _detectorOffset * transform.right.x,
                _detectorSize, 0, _targetLayers.value);

            if (hits > 0)
            {
                ITarget target = null;
                ITarget baseTarget = null;
                for (int i = 0; i < hits; i++)
                {
                    target = _hitColliders[i].gameObject.GetComponent<ITarget>();
                    //if (target is Unit)
                    //{
                    //    _currentTarget = target.GetTarget(this);
                    //    return true;
                    //}
                    //else
                    //{
                    //    baseTarget = target;
                    //}
                    if (i == hits - 1)
                    {
                        if (baseTarget != null)
                        {
                            _currentTarget = baseTarget.GetTarget(this);
                            return true;
                        }
                    }
                }
            }
            TargetNull?.Invoke();
            return false;
        }

        public void SetTargetLayer(LayerMask targetLayers)
        {
            _targetLayers = targetLayers;
        }
        public virtual void StartAttack()
        {
            _isAttack = true;
            AttackStarted?.Invoke();
        }
        public virtual void EndAttack()
        {
            _isAttack = false;
            AttackEnded?.Invoke();
        }
        public virtual void PerformAttack()
        {
        }
        public void InflictDamage(DamagerInfo damageable)
        {

        }

        protected void MakeSoundShot(AudioClip actionAudio)
        {
            if (_isFastFire)
            {
                if (_isEvenShot)
                {
                    MakeSoundEvent.Trigger(new SoundEventInfo(actionAudio, transform.position, 0.25f, true));
                }
                else
                {
                    MakeSoundEvent.Trigger(new SoundEventInfo(actionAudio, transform.position, _combatVolume, true));
                }
                _isEvenShot = !_isEvenShot;
            }
            else
            {
                MakeSoundEvent.Trigger(new SoundEventInfo(actionAudio, transform.position, _combatVolume));
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = _gizmosColor;
            Gizmos.DrawCube((Vector2)transform.position + _detectorOffset * transform.right.x, _detectorSize);
        }
    }
}