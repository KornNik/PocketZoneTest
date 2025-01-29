using System.Collections.Generic;

namespace Behaviours
{
    enum UnitStateType
    {
        None,
        Default,
        Attack,
        Recharge,
        PlayerRecharge,
        PlayerAttack
    }
    class UnitStateController : BaseStateController
    {
        protected UnitController _stateObject;
        protected Dictionary<UnitStateType, IState> _states = new Dictionary<UnitStateType, IState>(5);

        public UnitStateController(UnitController unitStateObject) : base()
        {
            _stateObject = unitStateObject;
            StartState(GetState(UnitStateType.Default));
        }

        public UnitController StateObject => _stateObject;

        protected override void InitializeStates()
        {
            _states.Clear();
            _states.Add(UnitStateType.Default, new DefaultState(this));
            _states.Add(UnitStateType.Attack, new AttackState(this));
            _states.Add(UnitStateType.Recharge, new RechargeState(this));
        }

        private IState GetState(UnitStateType unitStateType)
        {
            if (_states.ContainsKey(unitStateType))
            {
                var state = _states[unitStateType];
                return state;
            }
            return null;
        }
    }
}
