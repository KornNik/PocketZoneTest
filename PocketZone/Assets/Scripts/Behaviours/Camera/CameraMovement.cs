using Behaviours;
using Data;
using DG.Tweening;
using UnityEngine;

namespace CameraScripts
{
    sealed class CameraMovement : IMovable
    {
        private Transform _transform;
        private CameraData _data;

        public CameraMovement(Transform transform, CameraData cameraData)
        {
            _transform = transform;
            _data = cameraData;
        }

        public void Move(Vector2 endValue)
        {
            var finalMovement = new Vector3(endValue.x, endValue.y, _data.OffsetDistance);
            _transform.DOMove(finalMovement, _data.MovementDuration);
        }
    }
}
