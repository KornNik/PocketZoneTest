using UnityEngine;

namespace Behaviours
{
    abstract class Movement : IMovable
    {
        private Rigidbody2D _rigidbody;
        private Transform _transform;

        protected Movement(Rigidbody2D rigidbody, Transform transform)
        {
            _rigidbody = rigidbody;
            _transform = transform;
        }

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => _transform;

        public virtual void Move(Vector2 inputVector)
        {
            FlipUnit(inputVector.x);
        }
        public virtual void Stop()
        {

        }
        protected virtual void FlipUnit(float movingInput)
        {

        }
    }
}
