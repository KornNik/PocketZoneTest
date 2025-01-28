using Data;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerModel : UnitModel
    {
        [SerializeField] private PlayerData _playerData;

        private Inventory _inventory;

        protected override void Awake()
        {
            base.Awake();
            _combat = new RayCastCombat();
            _movement = new PlayerMovement(Rigidbody, Transform, _playerData);
            _inventory = new Inventory();
        }
    }
}
