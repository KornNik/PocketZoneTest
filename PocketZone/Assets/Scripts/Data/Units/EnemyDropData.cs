using Helpers.Extensions;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyDropData", menuName = "Data/Enemy/EnemyDropData")]
    sealed class EnemyDropData : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<EnemyType, ItemData[]> _enemiesDrops;

        public ItemData[] GetDropByType(EnemyType enemyType)
        {
            ItemData[] enemyDrop = default;
            if (_enemiesDrops.Contains(enemyType))
            {
                enemyDrop = _enemiesDrops[enemyType];
            }
            return enemyDrop;
        }
        public ItemData GetRandomDropByType(EnemyType enemyType)
        {
            ItemData[] enemyDrop = default;
            if (_enemiesDrops.Contains(enemyType))
            {
                enemyDrop = _enemiesDrops[enemyType];
            }

            var randomNumber = Random.Range(0, enemyDrop.Length);
            var randomItem = enemyDrop[randomNumber];
            return randomItem;
        }
    }
}
