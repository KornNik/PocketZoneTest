using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerFabric : UnitsFabric
    {
        private GameObject _playerPrefab;
        private Level _level;

        public PlayerFabric()
        {
            _playerPrefab = Services.Instance.DataResourcePrefabs.ServicesObject.GetPlayerPrefab();
        }

        public override GameObject CreateUnit()
        {
            _level = Services.Instance.Level.ServicesObject;
            var unit = GameObject.Instantiate(_playerPrefab);
            unit.transform.position = _level.PlayerSpawn.position;
            unit.transform.rotation = _level.PlayerSpawn.rotation;
            Services.Instance.PlayerController.SetObject(unit.GetComponent<UnitController>());
            return unit;
        }
    }
}
