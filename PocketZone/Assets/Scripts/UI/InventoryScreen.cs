using UnityEngine;

namespace UI
{
    sealed class InventoryScreen : BaseUI
    {
        [SerializeField] private InventoryUI _inventoryUI;

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
    }
}
