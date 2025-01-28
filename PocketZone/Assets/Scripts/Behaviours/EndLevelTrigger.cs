using UnityEngine;

namespace Behaviours
{
    sealed class EndLevelTrigger : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private LayerMask _collisionLayer;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _collisionLayer)
            {
                GameLifeCycleEvent.Trigger(GameCycleType.EndGame);
            }
        }
    }
}
