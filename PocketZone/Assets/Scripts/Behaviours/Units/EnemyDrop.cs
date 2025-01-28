using Data;
using Helpers;

namespace Behaviours
{
    sealed class EnemyDrop
    {
        private EnemyDropData _dropData;
        private EnemyType _enemyType;

        public EnemyDrop(EnemyType enemyType)
        {
            _dropData = Services.Instance.DatasBundle.ServicesObject.GetData<EnemyDropData>();
            _enemyType = enemyType;
        }

        public void OnEnemyDie()
        {
            _dropData.GetRandomDropByType(_enemyType);
        }
    }
}
