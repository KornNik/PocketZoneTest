﻿using Cysharp.Threading.Tasks;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class PlayerAttackState : AttackState
    {
        private UniTask _waitForEndAttack;
        private bool _isNextWeaponSwap;
        private PlayerStateController _playerStateController;

        public PlayerAttackState(PlayerStateController stateController) : base(stateController)
        {
            _playerStateController = stateController;
        }
        public override void EnterState()
        {
            base.EnterState();
            _isNextWeaponSwap = false;
        }
        public override void ExitState()
        {
            base.ExitState();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
        }

        protected override void AttackLogick()
        {
            //if (_currentAttackTimeLeft > 0)
            //{
            //    _currentAttackTimeLeft -= Time.deltaTime;
            //    _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
            //        (new UnitStateInfo(_attackTime, _currentAttackTimeLeft, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().AttackSprite));
            //}
            //else
            //{
            //    if (_isNextWeaponSwap)
            //    {
            //        _isNextWeaponSwap = false;
            //        _stateController.ChangeState(_playerStateController.WeaponSwapState);
            //    }
            //    else
            //    {
            //        _stateController.StateObject.UnitEvents.RechargeTick?.Invoke
            //            (new UnitStateInfo(_attackTime, 0, Services.Instance.DatasBundle.ServicesObject.GetData<UnitStateImages>().AttackSprite));
            //        _stateController.ChangeState(_stateController.RechargeState);
            //    }
            //}
        }
    }
}
