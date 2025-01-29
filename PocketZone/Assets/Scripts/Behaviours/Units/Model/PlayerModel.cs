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
            _combat = new Combat();
            _movement = new PlayerMovement(Rigidbody, Transform, Data);
            _inventory = new Inventory();
        }
    }
}
