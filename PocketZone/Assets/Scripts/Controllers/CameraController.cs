using CameraScripts;
using UnityEngine;

namespace Controllers
{
    sealed class CameraController : MonoBehaviour, ICameraController
    {
        [SerializeField] private CameraModel _model;

        public Camera Camera => _model.Camera;

        private void Awake()
        {

        }

        public void SetDefaultCameraPosition()
        {
            _model.Movement.Move(Vector2.zero);
        }
        public void Move(Vector2 newCameraPosition)
        {
            _model.Movement.Move(newCameraPosition);
        }
    }

    interface ICameraController
    {
        Camera Camera { get; }
        void Move(Vector2 newCameraPosition);
        void SetDefaultCameraPosition();
    }
}
