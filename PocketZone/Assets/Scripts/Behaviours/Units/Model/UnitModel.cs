using Data;
using System;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D),
        typeof(Collider2D))]
    abstract class UnitModel : MonoBehaviour, ITarget
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private UnitAnimation _unitAnimation;
        [SerializeField] private UnitData _data;

        protected Combat _combat;
        protected Detector _detector;
        protected Movement _movement;
        protected UnitEvents _events;
        protected UnitDeath _death;
        protected Health _health;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => _transform;
        public Collider2D Collider => _collider;
        public UnitEvents Events => _events;
        public Movement Movement => _movement;
        public UnitData Data  => _data;

        protected virtual void Awake()
        {
            _events = new UnitEvents();
            _health = new Health(_data,Events);
        }

        public ITarget GetTarget()
        {
            return this;
        }
    }

    abstract class UnitDeath : IDisposable
    {
        private UnitEvents _unitEvents;

        public UnitDeath(UnitEvents unitEvents)
        {
            _unitEvents = unitEvents;
            _unitEvents.HealthIsEnd += UnitDie;
        }
        public void Dispose()
        {
            _unitEvents.HealthIsEnd -= UnitDie;
        }

        protected virtual void UnitDie()
        {
            _unitEvents.Died?.Invoke();
        }
        protected virtual void UnitRevived()
        {
            _unitEvents.Revived?.Invoke();
        }
    }
}
