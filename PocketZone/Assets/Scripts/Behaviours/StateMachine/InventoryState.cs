using Helpers;
using UI;
using Helpers.Extensions;

namespace Behaviours
{
    sealed class InventoryState : BaseState
    {
        private InputActions _inputs;

        public InventoryState(GameStateController stateController) : base(stateController)
        {
            _inputs = Services.Instance.Inputs.ServicesObject;
        }
        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.InventoryScreen);
            Services.Instance.SettingsController.ServicesObject.UnLockedCursor();
        }

        public override void ExitState()
        {

        }

        public override void LogicFixedUpdate()
        {

        }

        public override void LogicUpdate()
        {
            var isInventory = _inputs.PlayerActionList
                [InputActionManagerPlayer.INVENTORY].triggered;

            if (isInventory)
            {
                ChangeGameStateEvent.Trigger(GameStateType.GameState);
            }
        }
    }
}
