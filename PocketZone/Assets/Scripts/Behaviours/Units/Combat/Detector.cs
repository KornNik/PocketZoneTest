using Helpers.Managers;
using System;
using UnityEngine;

namespace Behaviours
{
    class Detector : IDetector
    {
        public event Action TargetNull;

        private LayerMask _targetLayers;
        private ITarget _currentTarget;
        private Transform _transform;

        #region Detector

        private Vector2 _detectorSize;
        private Vector2 _detectorOffset = Vector2.zero;
        private Collider2D _hitCollider;
        private Collider2D[] _hitColliders;

        public Detector(Transform transform)
        {
            _transform = transform;
            _targetLayers = LayerMask.GetMask(LayersManager.PLAYER, LayersManager.ENEMY);
            _hitColliders = new Collider2D[3];
        }

        #endregion

        public LayerMask TargetLayer => _targetLayers;

        public bool DetectTarget()
        {
            var hits = Physics2D.OverlapBoxNonAlloc((Vector2)_transform.position + _detectorOffset * _transform.right.x,
                _detectorSize, 0f, _hitColliders, _targetLayers.value);

            if (hits > 0)
            {
                ITarget target = null;
                ITarget baseTarget = null;
                for (int i = 0; i < hits; i++)
                {
                    target = _hitColliders[i].gameObject.GetComponent<ITarget>();
                    if (target != null)
                    {
                        _currentTarget = target.GetTarget();
                        return true;
                    }
                    else
                    {
                        baseTarget = target;
                    }
                    if (i == hits - 1)
                    {
                        if (baseTarget != null)
                        {
                            _currentTarget = baseTarget.GetTarget();
                            return true;
                        }
                    }
                }
            }
            TargetNull?.Invoke();
            return false;
        }
    }
}