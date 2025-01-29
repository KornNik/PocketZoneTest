using Data;
using Pathfinding;
using UnityEngine;

namespace Behaviours
{
    sealed class AstarMovement : Movement
    {
        private AIPath _pathfinding;
        private UnitData _data;
        private EnemyData _enemyData;

        public AstarMovement(Rigidbody2D rigidbody, Transform transform,
            AIPath aiPath, EnemyData enemyData, UnitData unitData) : base(rigidbody, transform)
        {
            _pathfinding = aiPath;
            _data = unitData;
            _enemyData = enemyData;
            Configuration();
        }
        private void Configuration()
        {
            _pathfinding.endReachedDistance = _enemyData.StopingDistance;
            _pathfinding.slowdownDistance = _enemyData.SlowDownDistance;
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
