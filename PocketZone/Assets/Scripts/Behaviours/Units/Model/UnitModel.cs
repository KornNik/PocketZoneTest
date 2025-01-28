using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D),
        typeof(Collider2D))]
    abstract class UnitModel : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _transform;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private UnitAnimation _unitAnimation;

        protected Combat _combat;
        protected Movement _movement;
        protected UnitEvents _events;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => _transform;
        public Collider2D Collider => _collider;
        public UnitEvents Events => _events;
        public Movement Movement => _movement;

        protected virtual void Awake()
        {
            _events = new UnitEvents();
        }
    }
}
