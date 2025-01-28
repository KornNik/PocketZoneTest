using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class GameStateInputsController : StateInputsController
    {
        public override void UpdateInputs()
        {
            var isMoving = _inputs.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].IsPressed();
            var movement = _inputs.PlayerActionList
                [InputActionManagerPlayer.MOVEMENT].ReadValue<Vector2>();
            var isInventory = _inputs.PlayerActionList
                [InputActionManagerPlayer.INVENTORY].triggered;

            if (isMoving)
            {
                _controller.Move(movement);
            }
            if (isInventory)
            {
                ChangeGameStateEvent.Trigger(GameStateType.InventoryState);
            }
        }
    }
}
