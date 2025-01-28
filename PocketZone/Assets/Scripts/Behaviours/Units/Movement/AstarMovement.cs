using Data;
using Pathfinding;
using UnityEngine;

namespace Behaviours
{
    sealed class AstarMovement : Movement
    {
        private AIPath _pathfinding;
        private EnemyData _data;

        public AstarMovement(Rigidbody2D rigidbody, Transform transform,
            AIPath aiPath, EnemyData enemyData) : base(rigidbody, transform)
        {
            _pathfinding = aiPath;
            _data = enemyData;
            Configuration();
        }
        private void Configuration()
        {
            _pathfinding.endReachedDistance = _data.StopingDistance;
            _pathfinding.slowdownDistance = _data.SlowDownDistance;
        }

        public override void Move(Vector2 inputVector)
        {
            base.Move(inputVector);
            _pathfinding.canMove = true;
            _pathfinding.maxSpeed = _data.MovingSpeed;
        }
        public override void Stop()
        {
            base.Stop();
            _pathfinding.maxSpeed = 0f;
            _pathfinding.canMove = false;
        }
    }
}
