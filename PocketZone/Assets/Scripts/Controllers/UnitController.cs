using UI;
using UnityEngine;

namespace Behaviours
{
    sealed class UnitController : MonoBehaviour
    {
        [SerializeField] private UnitModel _model;
        [SerializeField] private UnitView _view;

        public void Move(Vector2 movement)
        {
            _model.Movement.Move(movement);
        }
    }
}
