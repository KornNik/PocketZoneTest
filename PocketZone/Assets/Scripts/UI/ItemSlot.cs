using Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Behaviours
{
    class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private Sprite _emptySlotSprite;
        [SerializeField] private Button _removeItemButton;
        [SerializeField] private Button _selectItemButton;

        [SerializeField] private TMP_Text _itemName;
        [SerializeField] private TMP_Text _itemQuantity;

        private ItemInfo _itemData;
        private bool _isEmpty;

        public ItemInfo ItemData => _itemData;
        public bool IsEmpty => _isEmpty;

        private void OnEnable()
        {
            _removeItemButton.onClick.AddListener(OnRemoveButtonDown);
            _selectItemButton.onClick.AddListener(OnSelectButtonDown);
            SetButtonStatus(_removeItemButton, false);
        }
        private void OnDisable()
        {
            _removeItemButton.onClick.RemoveListener(OnRemoveButtonDown);
            _selectItemButton.onClick.RemoveListener(OnSelectButtonDown);
        }

        public void FillSlot(ItemInfo itemInfo)
        {
            _itemData = itemInfo;
            _itemIcon.sprite = itemInfo.ItemData.Icon;
            _itemName.text = itemInfo.ItemData.Name;
            _isEmpty = false;
            if (itemInfo.ItemData.IsQuantity)
            {
                _itemQuantity.text = ItemData.Quantity.ToString();
            }
        }
        public void ClearSlot()
        {
            _itemData = null;
            _itemIcon.sprite = _emptySlotSprite;
            _itemName.text = null;
            _itemQuantity.text = null;
            _isEmpty = true;
        }

        public void ActivateSlot()
        {
            gameObject.SetActive(true);
            ClearSlot();
        }
        public void DeactivateSlot()
        {
            gameObject.SetActive(false);
        }

        protected virtual void OnRemoveButtonDown()
        {
            SlotEvent.Trigger(_itemData, SlotEventType.ItemDroped);
            SetButtonStatus(_removeItemButton, false);
        }
        protected virtual void OnSelectButtonDown()
        {
            if (_isEmpty) return;
            SetButtonStatus(_removeItemButton, true);
        }

        private void SetButtonStatus(Button button, bool status)
        {
            var btnCanvasGroup = button.GetComponent<CanvasGroup>();
            btnCanvasGroup.interactable = status;
            btnCanvasGroup.blocksRaycasts = status;
            btnCanvasGroup.alpha = status ? 1 : 0;
        }
    }

}
