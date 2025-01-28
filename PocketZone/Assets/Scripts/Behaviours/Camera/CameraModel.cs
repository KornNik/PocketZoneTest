using UnityEngine;
using Data;

namespace CameraScripts
{
    sealed class CameraModel : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private CameraData _data;

        private CameraMovement _movement;

        public Camera Camera => _camera;
        public CameraData Data => _data;
        public CameraMovement Movement => _movement;

        private void Awake()
        {
            _movement = new CameraMovement(transform, _data);
        }
    }
}