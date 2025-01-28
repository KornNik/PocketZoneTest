using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class EnemyFabric : UnitsFabric
    {
        private EnemiesBundle _bundle;
        private Level _level;

        public EnemyFabric()
        {
            _bundle = Services.Instance.DataResourcePrefabs.ServicesObject.GetEnemiesBundle();
        }

        public override GameObject CreateUnit()
        {
            _level = Services.Instance.Level.ServicesObject;
            for (int i = 0; i < _level.EnemiesSpawn.Length; i++)
            {
                var unit = GameObject.Instantiate(_bundle.GetEnemyByType(EnemyType.BasicEnemy));
                unit.transform.position = _level.EnemiesSpawn[i].position;
                unit.transform.rotation = _level.EnemiesSpawn[i].rotation;
            }
            return null;
        }
    }
}
