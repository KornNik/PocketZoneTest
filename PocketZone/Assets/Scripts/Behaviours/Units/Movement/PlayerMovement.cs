using Data;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerMovement : Movement
    {
        private PlayerData _data;
        public PlayerMovement(Rigidbody2D rigidbody, Transform transform, PlayerData playerData) : base(rigidbody, transform)
        {
            _data = playerData;
        }

        public override void Move(Vector2 inputVector)
        {
            base.Move(inputVector);
            var movementValue = inputVector * _data.MovingSpeed * Time.deltaTime;
            var finalValue = new Vector3(movementValue.x, movementValue.y, 0f);
            Rigidbody.MovePosition(Rigidbody.position + movementValue);
        }
        public override void Stop()
        {
            base.Stop();
            Rigidbody.velocity = Vector2.zero;
        }
    }
}
