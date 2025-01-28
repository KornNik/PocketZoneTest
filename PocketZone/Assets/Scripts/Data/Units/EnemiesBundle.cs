using Helpers.Extensions;
using UnityEngine;

namespace Data
{
    enum EnemyType
    {
        None,
        BasicEnemy,
        RangedEnemy,
    }
    [CreateAssetMenu(fileName = "EnemyBundle", menuName = "Data/Enemy/EnemyBundle")]
    sealed class EnemiesBundle : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<EnemyType, GameObject> _enemiesPrefabs;

        public GameObject GetEnemyByType(EnemyType enemyType)
        {
            GameObject enemyPrefab = default;
            if (_enemiesPrefabs.Contains(enemyType))
            {
                enemyPrefab = _enemiesPrefabs[enemyType];
            }
            return enemyPrefab;
        }
    }
}
