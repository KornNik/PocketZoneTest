using Data;
using Helpers.Managers;
using UnityEngine;

namespace Behaviours.Items
{
    abstract class Item : MonoBehaviour, IItem, IInteractable
    {
        [SerializeField] private Collider2D _interactionCollider;
        [SerializeField] private ItemInfo _itemDataInfo;

        private bool _isAllowInteract = false;

        public ItemData ItemData => ItemDataInfo.ItemData;
        public ItemInfo ItemDataInfo => _itemDataInfo;

        protected virtual void Awake()
        {
            
        }
        protected virtual void OnEnable()
        {

        }
        protected virtual void OnDisable()
        {
            
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer(LayersManager.PLAYER) && _isAllowInteract)
            {
                GrabItem();
            }
        }

        public void SetItemDataInfo(ItemInfo itemDataInfo)
        {
            _itemDataInfo.Quantity = itemDataInfo.Quantity;
            _itemDataInfo.Condition = itemDataInfo.Condition;
        }
        public void DropItem()
        {
            _isAllowInteract = true;
            _interactionCollider.enabled = true;
        }
        public void GrabItem()
        {
            _isAllowInteract = false;
            _interactionCollider.enabled = false;
            Destroy(gameObject);
        }
        public void Interact(IInteracter interacter)
        {

        }
    }
}
