using Behaviours;
using Helpers.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class GameMenu : BaseUI
    {
        [SerializeField] private Button _inventoryButton;
        [SerializeField] private Button _shootButton;
        [SerializeField] private Joystick _joystick;

        private void OnEnable()
        {
            _inventoryButton.onClick.AddListener(OnInventoryButtonDown);
            _shootButton.onClick.AddListener(OnShootButtonDown);
        }
        private void OnDisable()
        {
            _inventoryButton.onClick.RemoveListener(OnInventoryButtonDown);
            _shootButton.onClick.RemoveListener(OnShootButtonDown);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void OnInventoryButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.InventoryState);
        }
        private void OnShootButtonDown()
        {

        }
        private void OnJoystickDrag()
        {
            if(MathExtender.IsVectorVariableNotZero(_joystick.Direction))
            {
                ///Send direction to inputs
            }
        }
    }
}