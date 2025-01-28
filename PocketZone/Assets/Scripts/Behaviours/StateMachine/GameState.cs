using Controllers;
using Helpers;
using UI;
using UnityEngine;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private Transform _playerTransform;
        private StateInputsController _gameInputController;
        private ICameraController _cameraController;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _gameInputController = new GameStateInputsController();
            _cameraController = Services.Instance.CameraController.ServicesObject;
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
            _gameInputController.Initialization();
            _playerTransform = Services.Instance.PlayerController.ServicesObject.transform;
        }

        public override void ExitState()
        {
            _cameraController.SetDefaultCameraPosition();
        }

        public override void LogicFixedUpdate()
        {
            base.LogicFixedUpdate();
        }
        public override void LogicUpdate()
        {
            base.LogicUpdate();
            _gameInputController.UpdateInputs();
        }
        public override void LogicLateUpdate()
        {
            base.LogicLateUpdate();
            _cameraController.Move(_playerTransform.position);
        }
    }
}
