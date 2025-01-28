using Data;
using UnityEngine;

namespace Behaviours.Items
{
    abstract class Item : MonoBehaviour, IItem, IMovable, IInteractable
    {
        [SerializeField] private Rigidbody2D _rigidbody;
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

        public void SetItemDataInfo(ItemInfo itemDataInfo)
        {
            _itemDataInfo.Quantity = itemDataInfo.Quantity;
            _itemDataInfo.Condition = itemDataInfo.Condition;
        }
        public void DropItem()
        {
            _isAllowInteract = true;
            _rigidbody.isKinematic = false;
            _interactionCollider.enabled = true;
            Move(gameObject.transform.forward);
        }
        public void GrabItem()
        {
            _isAllowInteract = false;
            _rigidbody.isKinematic = true;
            _interactionCollider.enabled = false;
            Destroy(gameObject);
        }
        public void Interact(IInteracter interacter)
        {
            //GrabItem
        }
        public void Move(Vector2 movement)
        {
            _rigidbody.AddForce(transform.forward);
        }
        public void StopMovement()
        {

        }
    }
}
