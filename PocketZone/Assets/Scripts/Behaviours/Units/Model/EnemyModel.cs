using UnityEngine;
using Data;
using Pathfinding;

namespace Behaviours
{
    sealed class  EnemyModel : UnitModel
    {
        [SerializeField] private AIPath _aiPath;
        [SerializeField] private EnemyData _enemyData;

        private EnemyType _type;
        private EnemyDrop _drop;

        protected override void Awake()
        {
            base.Awake();
            _combat = new RayCastCombat();
            _movement = new AstarMovement(Rigidbody, Transform, _aiPath, _enemyData);
            _drop = new EnemyDrop(_type);
        }
    }
}
