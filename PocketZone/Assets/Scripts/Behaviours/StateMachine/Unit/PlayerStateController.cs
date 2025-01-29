namespace Behaviours
{
    sealed class PlayerStateController : UnitStateController
    {
        public PlayerStateController(UnitController unitStateObject) : base(unitStateObject)
        {

        }

        protected override void InitializeStates()
        {
            base.InitializeStates();
            _states.Add(UnitStateType.PlayerAttack, new PlayerAttackState(this));
            _states.Add(UnitStateType.PlayerRecharge, new PlayerRechargeState(this));
        }
    }
}
