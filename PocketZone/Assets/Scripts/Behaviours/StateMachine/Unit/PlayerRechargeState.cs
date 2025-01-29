using Helpers;

namespace Behaviours
{
    sealed class PlayerRechargeState : RechargeState
    {
        private float _rechargeTimeExtra;
        private PlayerStateController _playerStateController;
        public PlayerRechargeState(PlayerStateController stateController) : base(stateController)
        {
            _playerStateController = stateController;
        }
        public override void EnterState()
        {
            base.EnterState();
        }
        public override void ExitState()
        {
            base.ExitState();
        }
    }
}
